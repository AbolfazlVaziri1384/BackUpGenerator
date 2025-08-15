namespace BackUpGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkBackUp = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextSelect = new System.Windows.Forms.RichTextBox();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPersianTime = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEnglishTime = new System.Windows.Forms.CheckBox();
            this.chkVs = new System.Windows.Forms.CheckBox();
            this.chkBin = new System.Windows.Forms.CheckBox();
            this.chkObj = new System.Windows.Forms.CheckBox();
            this.chkAutomatic = new System.Windows.Forms.CheckBox();
            this.BackUpTimer = new System.Windows.Forms.Timer(this.components);
            this.grpAutomatic = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkMessage = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.lblTimer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSave = new System.Windows.Forms.DataGridView();
            this.btnDeleteSave = new System.Windows.Forms.Button();
            this.btnCleanPage = new System.Windows.Forms.Button();
            this.btnLoadSave = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Files = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpAutomatic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSave)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name : ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(136, 27);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(385, 42);
            this.txtName.TabIndex = 2;
            // 
            // chkBackUp
            // 
            this.chkBackUp.AutoSize = true;
            this.chkBackUp.Location = new System.Drawing.Point(15, 180);
            this.chkBackUp.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.chkBackUp.Name = "chkBackUp";
            this.chkBackUp.Size = new System.Drawing.Size(331, 38);
            this.chkBackUp.TabIndex = 6;
            this.chkBackUp.Text = "Set _Backup at end file name";
            this.chkBackUp.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(214, 329);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(307, 84);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "GENERATE BACKUP";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("B Koodak", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPath.Location = new System.Drawing.Point(136, 129);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(385, 37);
            this.txtPath.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(9, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 34);
            this.label4.TabIndex = 10;
            this.label4.Text = "Path : ";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(381, 171);
            this.btnPath.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(140, 143);
            this.btnPath.TabIndex = 4;
            this.btnPath.Text = "Choose Path";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(13, 375);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(298, 42);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Delete Selected File";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextSelect);
            this.groupBox1.Controls.Add(this.btnAddFolder);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.groupBox1.Size = new System.Drawing.Size(317, 426);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Back Up Files:";
            // 
            // richTextSelect
            // 
            this.richTextSelect.Location = new System.Drawing.Point(13, 30);
            this.richTextSelect.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.richTextSelect.Name = "richTextSelect";
            this.richTextSelect.Size = new System.Drawing.Size(298, 292);
            this.richTextSelect.TabIndex = 8;
            this.richTextSelect.Text = "Selected Files:";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(13, 329);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(298, 42);
            this.btnAddFolder.TabIndex = 7;
            this.btnAddFolder.Text = "Select Folder";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(136, 78);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(385, 42);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 34);
            this.label2.TabIndex = 15;
            this.label2.Text = "Password : ";
            // 
            // chkPersianTime
            // 
            this.chkPersianTime.AutoSize = true;
            this.chkPersianTime.Location = new System.Drawing.Point(15, 220);
            this.chkPersianTime.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.chkPersianTime.Name = "chkPersianTime";
            this.chkPersianTime.Size = new System.Drawing.Size(301, 38);
            this.chkPersianTime.TabIndex = 7;
            this.chkPersianTime.Text = "Use persian date and time\r\n";
            this.chkPersianTime.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEnglishTime);
            this.groupBox2.Controls.Add(this.chkVs);
            this.groupBox2.Controls.Add(this.chkBin);
            this.groupBox2.Controls.Add(this.chkObj);
            this.groupBox2.Controls.Add(this.chkAutomatic);
            this.groupBox2.Controls.Add(this.chkPersianTime);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkBackUp);
            this.groupBox2.Controls.Add(this.btnPath);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.btnGenerate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(334, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.groupBox2.Size = new System.Drawing.Size(529, 426);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // chkEnglishTime
            // 
            this.chkEnglishTime.AutoSize = true;
            this.chkEnglishTime.Location = new System.Drawing.Point(15, 253);
            this.chkEnglishTime.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.chkEnglishTime.Name = "chkEnglishTime";
            this.chkEnglishTime.Size = new System.Drawing.Size(301, 38);
            this.chkEnglishTime.TabIndex = 19;
            this.chkEnglishTime.Text = "Use English date and time\r\n";
            this.chkEnglishTime.UseVisualStyleBackColor = true;
            // 
            // chkVs
            // 
            this.chkVs.AutoSize = true;
            this.chkVs.Location = new System.Drawing.Point(15, 384);
            this.chkVs.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.chkVs.Name = "chkVs";
            this.chkVs.Size = new System.Drawing.Size(126, 38);
            this.chkVs.TabIndex = 18;
            this.chkVs.Text = "Clean vs";
            this.chkVs.UseVisualStyleBackColor = true;
            // 
            // chkBin
            // 
            this.chkBin.AutoSize = true;
            this.chkBin.Location = new System.Drawing.Point(15, 351);
            this.chkBin.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.chkBin.Name = "chkBin";
            this.chkBin.Size = new System.Drawing.Size(134, 38);
            this.chkBin.TabIndex = 17;
            this.chkBin.Text = "Clean bin";
            this.chkBin.UseVisualStyleBackColor = true;
            // 
            // chkObj
            // 
            this.chkObj.AutoSize = true;
            this.chkObj.Location = new System.Drawing.Point(15, 315);
            this.chkObj.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.chkObj.Name = "chkObj";
            this.chkObj.Size = new System.Drawing.Size(134, 38);
            this.chkObj.TabIndex = 16;
            this.chkObj.Text = "Clean obj";
            this.chkObj.UseVisualStyleBackColor = true;
            // 
            // chkAutomatic
            // 
            this.chkAutomatic.AutoSize = true;
            this.chkAutomatic.Location = new System.Drawing.Point(15, 284);
            this.chkAutomatic.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.chkAutomatic.Name = "chkAutomatic";
            this.chkAutomatic.Size = new System.Drawing.Size(141, 38);
            this.chkAutomatic.TabIndex = 10;
            this.chkAutomatic.Text = "Automatic";
            this.chkAutomatic.UseVisualStyleBackColor = true;
            this.chkAutomatic.CheckedChanged += new System.EventHandler(this.chkAutomatic_CheckedChanged);
            // 
            // BackUpTimer
            // 
            this.BackUpTimer.Interval = 1000;
            this.BackUpTimer.Tick += new System.EventHandler(this.BackUpTimer_Tick);
            // 
            // grpAutomatic
            // 
            this.grpAutomatic.Controls.Add(this.btnStop);
            this.grpAutomatic.Controls.Add(this.chkMessage);
            this.grpAutomatic.Controls.Add(this.label5);
            this.grpAutomatic.Controls.Add(this.numTime);
            this.grpAutomatic.Controls.Add(this.lblTimer);
            this.grpAutomatic.Controls.Add(this.label3);
            this.grpAutomatic.Enabled = false;
            this.grpAutomatic.Location = new System.Drawing.Point(871, 11);
            this.grpAutomatic.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.grpAutomatic.Name = "grpAutomatic";
            this.grpAutomatic.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.grpAutomatic.Size = new System.Drawing.Size(229, 426);
            this.grpAutomatic.TabIndex = 19;
            this.grpAutomatic.TabStop = false;
            this.grpAutomatic.Text = "Automatic";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(14, 333);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(207, 84);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkMessage
            // 
            this.chkMessage.AutoSize = true;
            this.chkMessage.Location = new System.Drawing.Point(28, 208);
            this.chkMessage.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.chkMessage.Name = "chkMessage";
            this.chkMessage.Size = new System.Drawing.Size(135, 106);
            this.chkMessage.TabIndex = 16;
            this.chkMessage.Text = "Show\r\n success\r\n massege";
            this.chkMessage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(9, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 34);
            this.label5.TabIndex = 19;
            this.label5.Text = "Time ( Seconde ) :";
            // 
            // numTime
            // 
            this.numTime.Location = new System.Drawing.Point(6, 72);
            this.numTime.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.numTime.Maximum = new decimal(new int[] {
            7200,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.Size = new System.Drawing.Size(209, 42);
            this.numTime.TabIndex = 18;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTimer.Location = new System.Drawing.Point(108, 171);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(26, 34);
            this.lblTimer.TabIndex = 17;
            this.lblTimer.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(22, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 34);
            this.label3.TabIndex = 16;
            this.label3.Text = "Remain Time :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 24);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(298, 60);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvSave);
            this.groupBox3.Controls.Add(this.btnDeleteSave);
            this.groupBox3.Controls.Add(this.btnCleanPage);
            this.groupBox3.Controls.Add(this.btnLoadSave);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(12, 443);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.groupBox3.Size = new System.Drawing.Size(1088, 284);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // dgvSave
            // 
            this.dgvSave.AllowUserToAddRows = false;
            this.dgvSave.AllowUserToDeleteRows = false;
            this.dgvSave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name,
            this.Files,
            this.Date});
            this.dgvSave.Location = new System.Drawing.Point(13, 99);
            this.dgvSave.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvSave.Name = "dgvSave";
            this.dgvSave.ReadOnly = true;
            this.dgvSave.RowHeadersWidth = 51;
            this.dgvSave.RowTemplate.Height = 24;
            this.dgvSave.Size = new System.Drawing.Size(1070, 173);
            this.dgvSave.TabIndex = 21;
            // 
            // btnDeleteSave
            // 
            this.btnDeleteSave.Location = new System.Drawing.Point(623, 24);
            this.btnDeleteSave.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btnDeleteSave.Name = "btnDeleteSave";
            this.btnDeleteSave.Size = new System.Drawing.Size(227, 60);
            this.btnDeleteSave.TabIndex = 22;
            this.btnDeleteSave.Text = "Delete";
            this.btnDeleteSave.UseVisualStyleBackColor = true;
            this.btnDeleteSave.Click += new System.EventHandler(this.btnDeleteLastSave_Click);
            // 
            // btnCleanPage
            // 
            this.btnCleanPage.Location = new System.Drawing.Point(858, 24);
            this.btnCleanPage.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btnCleanPage.Name = "btnCleanPage";
            this.btnCleanPage.Size = new System.Drawing.Size(225, 60);
            this.btnCleanPage.TabIndex = 21;
            this.btnCleanPage.Text = "Clean";
            this.btnCleanPage.UseVisualStyleBackColor = true;
            this.btnCleanPage.Click += new System.EventHandler(this.btnCleanPage_Click);
            // 
            // btnLoadSave
            // 
            this.btnLoadSave.Location = new System.Drawing.Point(317, 24);
            this.btnLoadSave.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btnLoadSave.Name = "btnLoadSave";
            this.btnLoadSave.Size = new System.Drawing.Size(298, 60);
            this.btnLoadSave.TabIndex = 20;
            this.btnLoadSave.Text = "Load";
            this.btnLoadSave.UseVisualStyleBackColor = true;
            this.btnLoadSave.Click += new System.EventHandler(this.btnLoadSave_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 104;
            // 
            // Files
            // 
            this.Files.HeaderText = "Files";
            this.Files.MinimumWidth = 6;
            this.Files.Name = "Files";
            this.Files.ReadOnly = true;
            this.Files.Width = 125;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 93;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1108, 736);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpAutomatic);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Backup Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpAutomatic.ResumeLayout(false);
            this.grpAutomatic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkBackUp;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkPersianTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer BackUpTimer;
        private System.Windows.Forms.GroupBox grpAutomatic;
        private System.Windows.Forms.CheckBox chkAutomatic;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkMessage;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.RichTextBox richTextSelect;
        private System.Windows.Forms.CheckBox chkObj;
        private System.Windows.Forms.CheckBox chkVs;
        private System.Windows.Forms.CheckBox chkBin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeleteSave;
        private System.Windows.Forms.Button btnCleanPage;
        private System.Windows.Forms.Button btnLoadSave;
        private System.Windows.Forms.DataGridView dgvSave;
        private System.Windows.Forms.CheckBox chkEnglishTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Files;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}

