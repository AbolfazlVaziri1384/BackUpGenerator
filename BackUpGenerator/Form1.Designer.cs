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
            this.radRar = new System.Windows.Forms.RadioButton();
            this.radZip = new System.Windows.Forms.RadioButton();
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
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.chkBin = new System.Windows.Forms.CheckBox();
            this.chkVs = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpAutomatic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(399, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(127, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام فایل خروجی :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(385, 42);
            this.txtName.TabIndex = 2;
            // 
            // chkBackUp
            // 
            this.chkBackUp.AutoSize = true;
            this.chkBackUp.Location = new System.Drawing.Point(150, 172);
            this.chkBackUp.Name = "chkBackUp";
            this.chkBackUp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBackUp.Size = new System.Drawing.Size(294, 38);
            this.chkBackUp.TabIndex = 6;
            this.chkBackUp.Text = "استفاده از Backup_ در نام خروجی";
            this.chkBackUp.UseVisualStyleBackColor = true;
            // 
            // radRar
            // 
            this.radRar.AutoSize = true;
            this.radRar.Location = new System.Drawing.Point(308, 296);
            this.radRar.Name = "radRar";
            this.radRar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radRar.Size = new System.Drawing.Size(83, 38);
            this.radRar.TabIndex = 8;
            this.radRar.TabStop = true;
            this.radRar.Text = "RAR";
            this.radRar.UseVisualStyleBackColor = true;
            // 
            // radZip
            // 
            this.radZip.AutoSize = true;
            this.radZip.Location = new System.Drawing.Point(231, 296);
            this.radZip.Name = "radZip";
            this.radZip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radZip.Size = new System.Drawing.Size(71, 38);
            this.radZip.TabIndex = 9;
            this.radZip.TabStop = true;
            this.radZip.Text = "ZIP";
            this.radZip.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(6, 337);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(385, 83);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "GENERATE BACKUP";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("B Koodak", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPath.Location = new System.Drawing.Point(94, 129);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(297, 37);
            this.txtPath.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(399, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(113, 34);
            this.label4.TabIndex = 10;
            this.label4.Text = "مسیر خروجی :";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(6, 127);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(82, 96);
            this.btnPath.TabIndex = 4;
            this.btnPath.Text = "انتخاب مسیر";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(13, 377);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(298, 43);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "حذف فایل های انتخابی";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextSelect);
            this.groupBox1.Controls.Add(this.btnAddFolder);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 426);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Back Up Files:";
            // 
            // richTextSelect
            // 
            this.richTextSelect.Location = new System.Drawing.Point(13, 30);
            this.richTextSelect.Name = "richTextSelect";
            this.richTextSelect.Size = new System.Drawing.Size(298, 292);
            this.richTextSelect.TabIndex = 8;
            this.richTextSelect.Text = "Selected Files:";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(13, 328);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(298, 43);
            this.btnAddFolder.TabIndex = 7;
            this.btnAddFolder.Text = "انتخاب پوشه";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(6, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(385, 42);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(399, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(124, 34);
            this.label2.TabIndex = 15;
            this.label2.Text = "رمز ( اختیاری ) :";
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Location = new System.Drawing.Point(239, 208);
            this.chkTime.Name = "chkTime";
            this.chkTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTime.Size = new System.Drawing.Size(189, 38);
            this.chkTime.TabIndex = 7;
            this.chkTime.Text = "استفاده از تاریخ و زمان";
            this.chkTime.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkVs);
            this.groupBox2.Controls.Add(this.chkBin);
            this.groupBox2.Controls.Add(this.chkObj);
            this.groupBox2.Controls.Add(this.chkAutomatic);
            this.groupBox2.Controls.Add(this.chkTime);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkBackUp);
            this.groupBox2.Controls.Add(this.radRar);
            this.groupBox2.Controls.Add(this.btnPath);
            this.groupBox2.Controls.Add(this.radZip);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.btnGenerate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(335, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 426);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // chkObj
            // 
            this.chkObj.AutoSize = true;
            this.chkObj.Location = new System.Drawing.Point(230, 252);
            this.chkObj.Name = "chkObj";
            this.chkObj.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkObj.Size = new System.Drawing.Size(69, 38);
            this.chkObj.TabIndex = 16;
            this.chkObj.Text = "obj";
            this.chkObj.UseVisualStyleBackColor = true;
            // 
            // chkAutomatic
            // 
            this.chkAutomatic.AutoSize = true;
            this.chkAutomatic.Location = new System.Drawing.Point(71, 293);
            this.chkAutomatic.Name = "chkAutomatic";
            this.chkAutomatic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
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
            this.grpAutomatic.Location = new System.Drawing.Point(871, 12);
            this.grpAutomatic.Name = "grpAutomatic";
            this.grpAutomatic.Size = new System.Drawing.Size(229, 426);
            this.grpAutomatic.TabIndex = 19;
            this.grpAutomatic.TabStop = false;
            this.grpAutomatic.Text = "Automatic";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 337);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(207, 83);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkMessage
            // 
            this.chkMessage.AutoSize = true;
            this.chkMessage.Location = new System.Drawing.Point(58, 216);
            this.chkMessage.Name = "chkMessage";
            this.chkMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMessage.Size = new System.Drawing.Size(165, 38);
            this.chkMessage.TabIndex = 16;
            this.chkMessage.Text = "نمایش پیام موفقیت";
            this.chkMessage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(79, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(142, 34);
            this.label5.TabIndex = 19;
            this.label5.Text = "مدت زمان به ثانیه :";
            // 
            // numTime
            // 
            this.numTime.Location = new System.Drawing.Point(6, 72);
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
            this.lblTimer.Location = new System.Drawing.Point(107, 172);
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
            this.label3.Location = new System.Drawing.Point(23, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(202, 34);
            this.label3.TabIndex = 16;
            this.label3.Text = "مدت زمان تا بک آپ بعدی :";
            // 
            // chkBin
            // 
            this.chkBin.AutoSize = true;
            this.chkBin.Location = new System.Drawing.Point(308, 252);
            this.chkBin.Name = "chkBin";
            this.chkBin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBin.Size = new System.Drawing.Size(69, 38);
            this.chkBin.TabIndex = 17;
            this.chkBin.Text = "bin";
            this.chkBin.UseVisualStyleBackColor = true;
            // 
            // chkVs
            // 
            this.chkVs.AutoSize = true;
            this.chkVs.Location = new System.Drawing.Point(383, 252);
            this.chkVs.Name = "chkVs";
            this.chkVs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVs.Size = new System.Drawing.Size(64, 38);
            this.chkVs.TabIndex = 18;
            this.chkVs.Text = "Vs";
            this.chkVs.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1112, 450);
            this.Controls.Add(this.grpAutomatic);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Backup Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpAutomatic.ResumeLayout(false);
            this.grpAutomatic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkBackUp;
        private System.Windows.Forms.RadioButton radRar;
        private System.Windows.Forms.RadioButton radZip;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTime;
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
    }
}

