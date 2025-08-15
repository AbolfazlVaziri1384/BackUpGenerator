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
            ini = new IniFile(iniPath);

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
                if (chkAutomatic.Checked && chkObj.Checked)
                {
                    MessageBox.Show("حواستان باشد که هنگام استفاده از پروژه به مشکل برنخورید چون هر دو گزینه پاک کردن و اتوماتیک فعال است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (chkBin.Checked || chkObj.Checked || chkVs.Checked)
                {
                    CleanSelectedFolders();
                }
                // ساخت نام فایل
                string fileName = txtName.Text;

                if (chkBackUp.Checked)
                    fileName += "_BackUp";

                if (chkPersianTime.Checked)
                    fileName += GetPersianDateTime();

                if (chkEnglishTime.Checked)
                    fileName += GetEnglishDateTime();

                string outputPath = Path.Combine(txtPath.Text, fileName);


                outputPath += ".rar";
                CreateRarArchive(outputPath, txtPassword.Text);

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
        private string GetEnglishDateTime()
        {
            DateTime now = DateTime.Now;
            return $"{now.Year}{now.Month:00}{now.Day:00}" +
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
                    throw new Exception("WinRAR یافت نشد.");
                }

                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }

                string baseDir = FindCommonRootDirectory(selectedFiles);
                if (string.IsNullOrEmpty(baseDir))
                {
                    throw new Exception("مسیر مشترکی بین فایل‌ها یافت نشد.");
                }

                string tempListFile = Path.GetTempFileName();
                try
                {
                    File.WriteAllLines(tempListFile, selectedFiles.Select(f => MakeRelativePath(baseDir, f)));

                    string arguments = $"a -r -ep1 \"{outputPath}\" -w\"{baseDir}\" -@\"{tempListFile}\"";
                    if (!string.IsNullOrEmpty(password))
                    {
                        arguments += $" -p{password} -hp";
                    }

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
                        if (!process.WaitForExit(30000))
                        {
                            process.Kill();
                            throw new Exception("زمان ساخت فایل به پایان رسید.");
                        }
                        if (process.ExitCode != 0)
                        {
                            throw new Exception($"خطای WinRAR: {error}");
                        }
                    }
                }
                finally
                {
                    if (File.Exists(tempListFile))
                    {
                        File.Delete(tempListFile);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطا در ساخت فایل RAR: {ex.Message}");
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
            try
            {
                if (string.IsNullOrEmpty(fromPath))
                    return Path.GetFileName(toPath);

                // نرمال کردن مسیرها
                fromPath = Path.GetFullPath(fromPath).TrimEnd('\\') + "\\";
                toPath = Path.GetFullPath(toPath);

                // بررسی اینکه آیا مسیرها در یک درایو هستند
                if (!string.Equals(Path.GetPathRoot(fromPath), Path.GetPathRoot(toPath), StringComparison.OrdinalIgnoreCase))
                    return Path.GetFileName(toPath);

                Uri fromUri = new Uri(fromPath);
                Uri toUri = new Uri(toPath);

                Uri relativeUri = fromUri.MakeRelativeUri(toUri);
                string relativePath = Uri.UnescapeDataString(relativeUri.ToString())
                    .Replace('/', Path.DirectorySeparatorChar);

                return string.IsNullOrEmpty(relativePath) ? "." : relativePath;
            }
            catch
            {
                // اگر خطایی رخ داد، نام فایل را برگردان
                return Path.GetFileName(toPath);
            }
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
        private void CleanSelectedFolders()
        {
            try
            {
                // ساخت متن هشدار بر اساس انتخاب‌ها
                var selectedTargets = new List<string>();
                if (chkBin.Checked) selectedTargets.Add("bin");
                if (chkObj.Checked) selectedTargets.Add("obj");
                if (chkVs.Checked) selectedTargets.Add(".vs");

                if (selectedTargets.Count > 0)
                {
                    string targets = string.Join(" , ", selectedTargets);
                    MessageBox.Show(
                        $"توجه: شما انتخاب کرده‌اید پوشه‌های زیر حذف شوند:\n{targets}\n\nلطفاً مطمئن شوید که در حال استفاده از پروژه مشکلی ایجاد نمی‌شود.",
                        "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }

                // شروع پاکسازی
                foreach (var path in selectedFiles)
                {
                    if (Directory.Exists(path))
                    {
                        if (chkBin.Checked) CleanDirectory(path, "bin");
                        if (chkObj.Checked) CleanDirectory(path, "obj");
                        if (chkVs.Checked) CleanDirectory(path, ".vs");
                    }
                    else if (File.Exists(path))
                    {
                        string parentDir = Path.GetDirectoryName(path);
                        if (Directory.Exists(parentDir))
                        {
                            if (chkBin.Checked) CleanDirectory(parentDir, "bin");
                            if (chkObj.Checked) CleanDirectory(parentDir, "obj");
                            if (chkVs.Checked) CleanDirectory(parentDir, ".vs");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در پاکسازی پوشه‌ها:\n{ex.Message}",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CleanDirectory(string rootDir, string folderName)
        {
            var directories = Directory.GetDirectories(rootDir, folderName, SearchOption.AllDirectories);
            foreach (var dir in directories)
            {
                try
                {
                    var accessTest = new DirectoryInfo(dir);
                    if ((accessTest.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        accessTest.Attributes &= ~FileAttributes.ReadOnly;
                    }

                    Directory.Delete(dir, true); // حذف بازگشتی پوشه
                    Debug.WriteLine($"پوشه {dir} حذف شد.");
                }
                catch (UnauthorizedAccessException)
                {
                    Debug.WriteLine($"عدم دسترسی به پوشه {dir}");
                    continue;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSavedBackupsToGrid();
        }
        private void LoadSavedBackupsToGrid()
        {
            dgvSave.Rows.Clear();

            var sections = GetIniSections(iniPath);
            foreach (var section in sections.Where(s => s.StartsWith("Backup_")))
            {
                string name = ini.Read(section, "Name", "");
                string files = ini.Read(section, "SelectedFiles", "");
                string date = ini.Read(section, "Date", "");

                // اگر تاریخ قبلاً ذخیره نشده بود، مقدار پیش‌فرض بده
                if (string.IsNullOrEmpty(date))
                    date = "Unknown";

                dgvSave.Rows.Add(section, name, files.Replace("|", ";"), date);
            }
        }
        public class IniFile
        {
            private string path;
            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section,
                string key, string val, string filePath);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section,
                string key, string def, StringBuilder retVal,
                int size, string filePath);

            public IniFile(string iniPath)
            {
                path = iniPath;
            }

            public void Write(string section, string key, string value)
            {
                WritePrivateProfileString(section, key, value, path);
            }

            public string Read(string section, string key, string defaultVal = "")
            {
                StringBuilder temp = new StringBuilder(255);
                GetPrivateProfileString(section, key, defaultVal, temp, 255, path);
                return temp.ToString();
            }

            public void DeleteSection(string section)
            {
                WritePrivateProfileString(section, null, null, path);
            }
        }
        private string iniPath = Path.Combine(Application.StartupPath, "LastSave.ini");
        private IniFile ini;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string section = "Backup_" + Guid.NewGuid().ToString();
                string baseDir = FindCommonRootDirectory(selectedFiles);

                // ذخیره مسیر پایه و مسیرهای نسبی
                ini.Write(section, "BaseDirectory", baseDir);
                ini.Write(section, "SelectedFiles",
                    string.Join("|", selectedFiles.Select(f => MakeRelativePath(baseDir, f))));

                ini.Write(section, "Name", txtName.Text);
                ini.Write(section, "Password", txtPassword.Text);
                ini.Write(section, "ChkBackUp", chkBackUp.Checked.ToString());
                ini.Write(section, "ChkPersianTime", chkPersianTime.Checked.ToString());
                ini.Write(section, "ChkEnglishTime", chkEnglishTime.Checked.ToString());
                ini.Write(section, "ChkBin", chkBin.Checked.ToString());
                ini.Write(section, "ChkObj", chkObj.Checked.ToString());
                ini.Write(section, "ChkVs", chkVs.Checked.ToString());
                ini.Write(section, "ChkAutomatic", chkAutomatic.Checked.ToString());
                ini.Write(section, "NumTime", numTime.Value.ToString());
                ini.Write(section, "ChkMessage", chkMessage.Checked.ToString());
                ini.Write(section, "Date", DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

                dgvSave.Rows.Add(section, txtName.Text, string.Join(";", selectedFiles), DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ذخیره تنظیمات: {ex.Message}");
            }
        }



        private void btnLoadSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSave.SelectedRows.Count == 0)
                {
                    MessageBox.Show("لطفاً یک مورد را انتخاب کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string section = dgvSave.SelectedRows[0].Cells[0].Value.ToString();
                string baseDir = ini.Read(section, "BaseDirectory");

                selectedFiles.Clear();
                string files = ini.Read(section, "SelectedFiles");
                if (!string.IsNullOrEmpty(files))
                {
                    selectedFiles = files.Split('|')
                        .Where(f => !string.IsNullOrEmpty(f))
                        .Select(f => Path.Combine(baseDir, f)) // تبدیل مسیرهای نسبی به مطلق
                        .ToList();
                }

                var invalidPaths = selectedFiles
                    .Where(f => !File.Exists(f) && !Directory.Exists(f))
                    .ToList();

                if (invalidPaths.Any())
                {
                    MessageBox.Show($"مسیرهای نامعتبر:\n{string.Join("\n", invalidPaths.Take(3))}" +
                                  (invalidPaths.Count > 3 ? "\n..." : ""),
                                  "هشدار");
                    selectedFiles = selectedFiles.Except(invalidPaths).ToList();
                }

                if (selectedFiles.Count == 0)
                {
                    MessageBox.Show("هیچ یک از مسیرهای ذخیره شده وجود ندارند");
                    return;
                }

                // بارگذاری سایر تنظیمات
                txtName.Text = ini.Read(section, "Name");
                txtPassword.Text = ini.Read(section, "Password");
                chkBackUp.Checked = bool.Parse(ini.Read(section, "ChkBackUp", "False"));
                chkPersianTime.Checked = bool.Parse(ini.Read(section, "ChkPersianTime", "False"));
                chkEnglishTime.Checked = bool.Parse(ini.Read(section, "ChkEnglishTime", "False"));
                chkBin.Checked = bool.Parse(ini.Read(section, "ChkBin", "False"));
                chkObj.Checked = bool.Parse(ini.Read(section, "ChkObj", "False"));
                chkVs.Checked = bool.Parse(ini.Read(section, "ChkVs", "False"));
                chkAutomatic.Checked = bool.Parse(ini.Read(section, "ChkAutomatic", "False"));
                chkMessage.Checked = bool.Parse(ini.Read(section, "ChkMessage", "False"));

                decimal val;
                if (decimal.TryParse(ini.Read(section, "NumTime", "0"), out val))
                    numTime.Value = val;

                UpdateFilesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری تنظیمات: {ex.Message}");
            }
        }


        private void btnDeleteLastSave_Click(object sender, EventArgs e)
        {
            if (dgvSave.SelectedRows.Count == 0)
            {
                MessageBox.Show("لطفاً یک مورد را انتخاب کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string section = dgvSave.SelectedRows[0].Cells[0].Value.ToString();

            // حذف از ini
            ini.DeleteSection(section);

            // حذف از dgv
            dgvSave.Rows.RemoveAt(dgvSave.SelectedRows[0].Index);

            MessageBox.Show("ذخیره انتخاب‌شده حذف شد.", "موفقیت",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnCleanPage_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPassword.Clear();
            chkBackUp.Checked = false;
            chkPersianTime.Checked = false;
            chkEnglishTime.Checked = false;
            chkBin.Checked = false;
            chkObj.Checked = false;
            chkVs.Checked = false;
            chkAutomatic.Checked = false;
            chkMessage.Checked = false;
            numTime.Value = 0;

            selectedFiles.Clear();
            UpdateFilesList();
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileSectionNames(
            IntPtr lpszReturnBuffer,
            uint nSize,
            string lpFileName);

        private List<string> GetIniSections(string iniPath)
        {
            List<string> result = new List<string>();
            IntPtr pReturnedString = Marshal.AllocCoTaskMem(32767);

            try
            {
                uint bytesReturned = (uint)GetPrivateProfileSectionNames(pReturnedString, 32767, iniPath);
                if (bytesReturned == 0) return result;

                string local = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);
                string[] sections = (local ?? string.Empty)
                    .Split(new[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);

                result.AddRange(sections);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pReturnedString);
            }

            return result;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

