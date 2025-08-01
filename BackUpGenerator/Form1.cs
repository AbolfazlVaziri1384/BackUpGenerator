using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
namespace BackUpGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<string> selectedFiles = new List<string>();
        int Timer = 0;
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }
        private void Generate()
        {
            try
            {
                if (!radRar.Checked && !radZip.Checked)
                {
                    MessageBox.Show("لطفا یک حالت برای خروجی انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (chkAutomatic.Checked && numTime.Value == 0)
                {
                    MessageBox.Show("لطفا مدت زمان بک آپ گیری اتوماتیک را مشخص کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // اعتبارسنجی ورودی‌ها
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("لطفاً نام فایل را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPath.Text))
                {
                    MessageBox.Show("لطفاً مسیر ذخیره‌سازی را انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (selectedFiles.Count == 0)
                {
                    MessageBox.Show("لطفاً حداقل یک فایل برای پشتیبان‌گیری انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (chkAutomatic.Checked && chkClean.Checked)
                {
                    MessageBox.Show("حواستان باشد که هنگام استفاده از پروژه به مشکل برنخورید چون هر دو گزینه پاک کردن و اتوماتیک فعال است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (chkClean.Checked)
                {
                    CleanBinObjFolders();
                }
                // ساخت نام فایل
                string fileName = txtName.Text;

                if (chkBackUp.Checked)
                    fileName += "_BackUp";

                if (chkTime.Checked)
                    fileName += GetPersianDateTime();

                string outputPath = Path.Combine(txtPath.Text, fileName);

                if (radZip.Checked)
                {
                    outputPath += ".zip";
                    CreateZipArchive(outputPath, txtPassword.Text);
                }
                else if (radRar.Checked)
                {
                    outputPath += ".rar";
                    CreateRarArchive(outputPath, txtPassword.Text);
                }
                if (chkAutomatic.Checked)
                {
                    Timer = (int)numTime.Value;
                    lblTimer.Text = Timer.ToString();
                    BackUpTimer.Enabled = true;
                }


                if (chkAutomatic.Checked && chkMessage.Checked)
                {
                    MessageBox.Show($"فایل پشتیبان با موفقیت ایجاد شد:\n{outputPath}", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!chkAutomatic.Checked)
                {
                    MessageBox.Show($"فایل پشتیبان با موفقیت ایجاد شد:\n{outputPath}", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ایجاد فایل پشتیبان:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetPersianDateTime()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;
            return $"{pc.GetYear(now)}{pc.GetMonth(now):00}{pc.GetDayOfMonth(now):00}" +
                   $"{now.Hour:00}{now.Minute:00}{now.Second:00}";
        }


        private void btnPath_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "فایل‌ها و پوشه‌ها را انتخاب کنید";
                dialog.Multiselect = true;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.ValidateNames = false;
                dialog.FileName = "Folder Selection.";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // فقط مسیرهای مستقیم انتخاب شده را اضافه کنید
                    selectedFiles.AddRange(dialog.FileNames
                        .Where(item => Directory.Exists(item) || File.Exists(item)));

                    UpdateFilesList();
                }
            }
        }
        private void UpdateFilesList()
        {
            richTextSelect.Text = "موارد انتخاب شده:\n";
            var topLevelItems = new List<string>();

            foreach (var path in selectedFiles.Distinct())
            {
                try
                {
                    // بررسی وجود مسیر و معتبر بودن آن
                    bool isDirectory = false;
                    bool isFile = false;

                    // بررسی بدون خطا برای مسیرهای نامعتبر
                    try
                    {
                        isDirectory = Directory.Exists(path);
                        isFile = !isDirectory && File.Exists(path);
                    }
                    catch
                    {
                        // مسیر نامعتبر - از نمایش آن صرفنظر می‌کنیم
                        continue;
                    }

                    if (isDirectory)
                    {
                        // بررسی آیا این پوشه زیرمجموعه پوشه دیگری در لیست نیست
                        bool isSubfolder = selectedFiles.Any(p =>
                            !string.Equals(p, path, StringComparison.OrdinalIgnoreCase) &&
                            IsParentDirectory(p, path));

                        if (!isSubfolder)
                        {
                            topLevelItems.Add($"📁 {Path.GetFileName(path)}");
                        }
                    }
                    else if (isFile)
                    {
                        // بررسی آیا فایل درون یکی از پوشه‌های انتخاب شده است
                        bool isInsideSelectedFolder = selectedFiles.Any(p =>
                            !string.Equals(p, path, StringComparison.OrdinalIgnoreCase) &&
                            IsParentDirectory(p, path));

                        if (!isInsideSelectedFolder)
                        {
                            topLevelItems.Add($"📄 {Path.GetFileName(path)}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing path {path}: {ex.Message}");
                }
            }

            // نمایش نتایج
            richTextSelect.Text = "موارد انتخاب شده:\n" + string.Join("\n", topLevelItems);
            richTextSelect.Text += $"\n\nتعداد: {topLevelItems.Count} مورد";
        }

        // متد کمکی برای بررسی رابطه والد-فرزندی بین مسیرها
        private bool IsParentDirectory(string parentPath, string childPath)
        {
            try
            {
                if (!Directory.Exists(parentPath)) return false;

                var parentUri = new Uri(parentPath + Path.DirectorySeparatorChar);
                var childUri = new Uri(childPath);

                return parentUri.IsBaseOf(childUri);
            }
            catch
            {
                return false;
            }
        }
        private void CreateZipArchive(string outputPath, string password)
        {
            try
            {
                // پیدا کردن پوشه ریشه مشترک برای حفظ ساختار
                string baseDir = FindCommonRootDirectory(selectedFiles);

                using (var zip = new Ionic.Zip.ZipFile(Encoding.UTF8))
                {
                    // تنظیم رمز عبور اگر وجود دارد
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        zip.Password = password;
                        zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                        zip.Password = password; // تنظیم مجدد برای اطمینان
                    }

                    // اضافه کردن فایل‌ها با حفظ ساختار پوشه‌ها
                    foreach (var path in selectedFiles)
                    {
                        try
                        {
                            if (Directory.Exists(path))
                            {
                                // اضافه کردن کل پوشه با ساختار داخلی
                                string relativePath = MakeRelativePath(baseDir, path);
                                zip.AddDirectory(path, relativePath);
                            }
                            else if (File.Exists(path))
                            {
                                // اضافه کردن فایل با مسیر نسبی
                                string relativePath = MakeRelativePath(baseDir, Path.GetDirectoryName(path));
                                zip.AddFile(path, relativePath);
                            }
                        }
                        catch (PathTooLongException)
                        {
                            // استفاده از مسیرهای کوتاه شده اگر مسیر طولانی است
                            string shortPath = GetShortPath(path);
                            if (Directory.Exists(shortPath))
                            {
                                zip.AddDirectory(shortPath, Path.GetFileName(path));
                            }
                            else
                            {
                                zip.AddFile(shortPath, "");
                            }
                        }
                    }

                    // ذخیره فایل ZIP با مدیریت خطا
                    try
                    {
                        zip.Save(outputPath);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"خطا در ذخیره فایل ZIP: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطا در ایجاد فایل ZIP: {ex.Message}");
            }
        }

        // متد برای تبدیل مسیر طولانی به مسیر کوتاه (8.3)
        private string GetShortPath(string longPath)
        {
            if (longPath.Length < 260) return longPath;

            StringBuilder shortPath = new StringBuilder(260);
            GetShortPathName(longPath, shortPath, shortPath.Capacity);
            return shortPath.ToString();
        }


        private void CreateRarArchive(string outputPath, string password)
        {
            try
            {
                string winRarPath = FindWinRarPath();
                if (string.IsNullOrEmpty(winRarPath))
                {
                    throw new Exception("WinRAR در سیستم یافت نشد.");
                }

                string passwordArg = string.IsNullOrEmpty(password) ? "" : $"-p{password} -hp";
                string baseDir = FindCommonRootDirectory(selectedFiles);

                // تقسیم فایل‌ها به گروه‌های کوچک با حفظ ساختار
                var fileBatches = SplitIntoBatches(selectedFiles, 10);

                foreach (var batch in fileBatches)
                {
                    string tempList = null;
                    try
                    {
                        // ایجاد فایل لیست موقت
                        tempList = Path.GetTempFileName();
                        File.WriteAllLines(tempList, batch.Select(f => MakeRelativePath(baseDir, f)));

                        // ساخت دستور RAR
                        string arguments = $"a -r -ep1 {passwordArg} -w\"{baseDir}\" -@\"{tempList}\" \"{outputPath}\"";

                        var processInfo = new ProcessStartInfo
                        {
                            FileName = winRarPath,
                            Arguments = arguments,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            RedirectStandardError = true,
                            WorkingDirectory = baseDir
                        };

                        using (var process = Process.Start(processInfo))
                        {
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            if (process.ExitCode != 0)
                            {
                                throw new Exception($"خطا در ایجاد فایل RAR: {error}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"خطا در پردازش دسته فایل‌ها: {ex.Message}");
                    }
                    finally
                    {
                        // حذف فایل موقت در هر حال
                        try
                        {
                            if (tempList != null && File.Exists(tempList))
                                File.Delete(tempList);
                        }
                        catch { /* در صورت خطا در حذف، نادیده گرفته شود */ }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطا در ایجاد فایل RAR: {ex.Message}");
            }
        }

        // پیدا کردن پوشه ریشه مشترک
        private string FindCommonRootDirectory(List<string> paths)
        {
            string commonRoot = Path.GetDirectoryName(paths.First());

            foreach (var path in paths)
            {
                while (!path.StartsWith(commonRoot))
                {
                    commonRoot = Path.GetDirectoryName(commonRoot);
                    if (string.IsNullOrEmpty(commonRoot))
                        return Path.GetPathRoot(paths.First()) ?? "";
                }
            }

            return commonRoot;
        }

        // ساخت مسیر نسبی
        private string MakeRelativePath(string fromPath, string toPath)
        {
            if (string.IsNullOrEmpty(fromPath)) return toPath;

            Uri fromUri = new Uri(fromPath.EndsWith("\\") ? fromPath : fromPath + "\\");
            Uri toUri = new Uri(toPath);

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            return Uri.UnescapeDataString(relativeUri.ToString()).Replace('/', '\\');
        }

        // تقسیم به دسته‌های کوچک
        private List<List<string>> SplitIntoBatches(List<string> items, int batchSize)
        {
            return items
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / batchSize)
                .Select(g => g.Select(x => x.Value).ToList())
                .ToList();
        }



        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetShortPathName(
            [MarshalAs(UnmanagedType.LPTStr)] string path,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder shortPath,
            int shortPathLength);
        // متد برای یافتن مسیر اجرایی WinRAR
        private string FindWinRarPath()
        {
            // مسیرهای احتمالی WinRAR
            var possiblePaths = new[]
            {
        @"C:\Program Files\WinRAR\Rar.exe",
        @"C:\Program Files (x86)\WinRAR\Rar.exe",
        Environment.ExpandEnvironmentVariables(@"%ProgramW6432%\WinRAR\Rar.exe"),
        Environment.ExpandEnvironmentVariables(@"%ProgramFiles(x86)%\WinRAR\Rar.exe")
    };

            return possiblePaths.FirstOrDefault(File.Exists);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedFiles.Clear();
            richTextSelect.Text = "Selected Files:";
        }

        private void chkAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            grpAutomatic.Enabled = chkAutomatic.Checked;
        }

        private void BackUpTimer_Tick(object sender, EventArgs e)
        {
            Timer--;
            lblTimer.Text = Timer.ToString();
            if (Timer == 0)
            {
                Timer = (int)numTime.Value;
                Generate();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            BackUpTimer.Enabled = false;
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to add all its contents";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    AddFilesFromDirectory(folderDialog.SelectedPath);
                    UpdateFilesList();
                }
            }
        }
        private void AddFilesFromDirectory(string directoryPath)
        {
            try
            {
                // اضافه کردن تمام فایل‌های داخل پوشه (به صورت بازگشتی)
                var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
                selectedFiles.AddRange(files);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در خواندن پوشه {directoryPath}:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CleanBinObjFolders()
        {
            try
            {
                foreach (var path in selectedFiles)
                {
                    if (Directory.Exists(path))
                    {
                        // پاکسازی پوشه‌های bin و obj در مسیرهای انتخاب شده
                        CleanDirectory(path, "bin");
                        CleanDirectory(path, "obj");
                    }
                    else if (File.Exists(path))
                    {
                        // اگر فایل انتخاب شده است، پوشه والد آن را بررسی می‌کنیم
                        string parentDir = Path.GetDirectoryName(path);
                        if (Directory.Exists(parentDir))
                        {
                            CleanDirectory(parentDir, "bin");
                            CleanDirectory(parentDir, "obj");
                        }
                    }
                }
                MessageBox.Show("پوشه‌های bin و obj با موفقیت پاکسازی شدند.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در پاکسازی پوشه‌های bin و obj:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CleanDirectory(string rootDir, string folderName)
        {
            var directories = Directory.GetDirectories(rootDir, folderName, SearchOption.AllDirectories);
            foreach (var dir in directories)
            {
                try
                {
                    Directory.Delete(dir, true); // حذف بازگشتی پوشه
                    Debug.WriteLine($"پوشه {dir} حذف شد.");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"خطا در حذف {dir}: {ex.Message}");
                }
            }
        }
    }
}

