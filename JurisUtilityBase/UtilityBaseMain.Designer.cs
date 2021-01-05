namespace JurisUtilityBase
{
    partial class UtilityBaseMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilityBaseMain));
            this.JurisLogoImageBox = new System.Windows.Forms.PictureBox();
            this.LexisNexisLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxCompanies = new System.Windows.Forms.ListBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.labelCurrentStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelPercentComplete = new System.Windows.Forms.Label();
            this.OpenFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.buttonExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxClient = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.listViewClient = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonClient = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxOrig = new System.Windows.Forms.ComboBox();
            this.radioButtonOrig = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxBill = new System.Windows.Forms.ComboBox();
            this.radioButtonBill = new System.Windows.Forms.RadioButton();
            this.checkBoxNbrCopies = new System.Windows.Forms.CheckBox();
            this.checkBoxPrintBill = new System.Windows.Forms.CheckBox();
            this.checkBoxPrintARStmt = new System.Windows.Forms.CheckBox();
            this.checkBoxEmailType = new System.Windows.Forms.CheckBox();
            this.checkBoxExportType = new System.Windows.Forms.CheckBox();
            this.checkBoxComment = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.JurisLogoImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LexisNexisLogoPictureBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // JurisLogoImageBox
            // 
            this.JurisLogoImageBox.Image = ((System.Drawing.Image)(resources.GetObject("JurisLogoImageBox.Image")));
            this.JurisLogoImageBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("JurisLogoImageBox.InitialImage")));
            this.JurisLogoImageBox.Location = new System.Drawing.Point(0, 1);
            this.JurisLogoImageBox.Name = "JurisLogoImageBox";
            this.JurisLogoImageBox.Size = new System.Drawing.Size(104, 336);
            this.JurisLogoImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.JurisLogoImageBox.TabIndex = 0;
            this.JurisLogoImageBox.TabStop = false;
            // 
            // LexisNexisLogoPictureBox
            // 
            this.LexisNexisLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LexisNexisLogoPictureBox.Image")));
            this.LexisNexisLogoPictureBox.Location = new System.Drawing.Point(8, 343);
            this.LexisNexisLogoPictureBox.Name = "LexisNexisLogoPictureBox";
            this.LexisNexisLogoPictureBox.Size = new System.Drawing.Size(96, 28);
            this.LexisNexisLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LexisNexisLogoPictureBox.TabIndex = 1;
            this.LexisNexisLogoPictureBox.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 434);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(853, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(134, 17);
            this.toolStripStatusLabel.Text = "Status: Ready to Execute";
            // 
            // listBoxCompanies
            // 
            this.listBoxCompanies.FormattingEnabled = true;
            this.listBoxCompanies.Location = new System.Drawing.Point(111, 1);
            this.listBoxCompanies.Name = "listBoxCompanies";
            this.listBoxCompanies.Size = new System.Drawing.Size(192, 56);
            this.listBoxCompanies.TabIndex = 0;
            this.listBoxCompanies.SelectedIndexChanged += new System.EventHandler(this.listBoxCompanies_SelectedIndexChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDescription.Location = new System.Drawing.Point(309, 1);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(217, 56);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Updates Bill Copy Settings for every matter associated with the selected clients." +
    " Closed matters cannot be changed.";
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.labelCurrentStatus);
            this.statusGroupBox.Controls.Add(this.progressBar);
            this.statusGroupBox.Controls.Add(this.labelPercentComplete);
            this.statusGroupBox.Location = new System.Drawing.Point(532, 1);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Size = new System.Drawing.Size(309, 56);
            this.statusGroupBox.TabIndex = 5;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "Utility Status:";
            // 
            // labelCurrentStatus
            // 
            this.labelCurrentStatus.AutoSize = true;
            this.labelCurrentStatus.Location = new System.Drawing.Point(7, 39);
            this.labelCurrentStatus.Name = "labelCurrentStatus";
            this.labelCurrentStatus.Size = new System.Drawing.Size(77, 13);
            this.labelCurrentStatus.TabIndex = 2;
            this.labelCurrentStatus.Text = "Current Status:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 16);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(296, 20);
            this.progressBar.TabIndex = 0;
            // 
            // labelPercentComplete
            // 
            this.labelPercentComplete.AutoSize = true;
            this.labelPercentComplete.Location = new System.Drawing.Point(241, 39);
            this.labelPercentComplete.Name = "labelPercentComplete";
            this.labelPercentComplete.Size = new System.Drawing.Size(62, 13);
            this.labelPercentComplete.TabIndex = 0;
            this.labelPercentComplete.Text = "% Complete";
            // 
            // OpenFileDialogOpen
            // 
            this.OpenFileDialogOpen.FileName = "openFileDialog1";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.LightGray;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonExit.Location = new System.Drawing.Point(133, 384);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(148, 38);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(489, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 38);
            this.button1.TabIndex = 17;
            this.button1.Text = "Review Data";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxClient
            // 
            this.checkBoxClient.AutoSize = true;
            this.checkBoxClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBoxClient.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxClient.Location = new System.Drawing.Point(372, 16);
            this.checkBoxClient.Name = "checkBoxClient";
            this.checkBoxClient.Size = new System.Drawing.Size(144, 20);
            this.checkBoxClient.TabIndex = 20;
            this.checkBoxClient.Text = "Select All Clients";
            this.checkBoxClient.UseVisualStyleBackColor = true;
            this.checkBoxClient.Visible = false;
            this.checkBoxClient.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "No",
            "Yes (Default)"});
            this.comboBox1.Location = new System.Drawing.Point(655, 127);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 21);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "No (Default)",
            "Yes"});
            this.comboBox2.Location = new System.Drawing.Point(655, 180);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(180, 21);
            this.comboBox2.TabIndex = 23;
            this.comboBox2.Click += new System.EventHandler(this.comboBox2_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "None (Default)",
            "XLS",
            "HTML",
            "Text",
            "RTF",
            "PDF",
            "TIFF",
            "LEDES"});
            this.comboBox3.Location = new System.Drawing.Point(655, 238);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(180, 21);
            this.comboBox3.TabIndex = 24;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            this.comboBox3.Click += new System.EventHandler(this.comboBox3_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "None (Default)",
            "XLS",
            "HTML",
            "Text",
            "RTF",
            "PDF",
            "TIFF",
            "LEDES"});
            this.comboBox4.Location = new System.Drawing.Point(655, 300);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(180, 21);
            this.comboBox4.TabIndex = 25;
            this.comboBox4.Click += new System.EventHandler(this.comboBox4_Click);
            // 
            // listViewClient
            // 
            this.listViewClient.HideSelection = false;
            this.listViewClient.Location = new System.Drawing.Point(12, 45);
            this.listViewClient.Name = "listViewClient";
            this.listViewClient.Size = new System.Drawing.Size(510, 173);
            this.listViewClient.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewClient.TabIndex = 26;
            this.listViewClient.UseCompatibleStateImageBehavior = false;
            this.listViewClient.View = System.Windows.Forms.View.Details;
            this.listViewClient.Visible = false;
            this.listViewClient.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView2_ColumnClick);
            this.listViewClient.Click += new System.EventHandler(this.listViewClient_Click);
            this.listViewClient.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(655, 363);
            this.textBox1.MaxLength = 30;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 33;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(655, 82);
            this.textBox2.MaxLength = 6;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(62, 20);
            this.textBox2.TabIndex = 35;
            this.textBox2.Text = "1";
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonClient);
            this.groupBox1.Controls.Add(this.listViewClient);
            this.groupBox1.Controls.Add(this.checkBoxClient);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(121, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 226);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By Client";
            // 
            // radioButtonClient
            // 
            this.radioButtonClient.AutoSize = true;
            this.radioButtonClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioButtonClient.Location = new System.Drawing.Point(12, 19);
            this.radioButtonClient.Name = "radioButtonClient";
            this.radioButtonClient.Size = new System.Drawing.Size(182, 20);
            this.radioButtonClient.TabIndex = 0;
            this.radioButtonClient.TabStop = true;
            this.radioButtonClient.Text = "Copy settings by client";
            this.radioButtonClient.UseVisualStyleBackColor = true;
            this.radioButtonClient.Click += new System.EventHandler(this.radioButtonClient_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxOrig);
            this.groupBox2.Controls.Add(this.radioButtonOrig);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(121, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 84);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "By Orig Tkpr";
            // 
            // comboBoxOrig
            // 
            this.comboBoxOrig.FormattingEnabled = true;
            this.comboBoxOrig.Location = new System.Drawing.Point(12, 44);
            this.comboBoxOrig.Name = "comboBoxOrig";
            this.comboBoxOrig.Size = new System.Drawing.Size(229, 21);
            this.comboBoxOrig.TabIndex = 28;
            this.comboBoxOrig.Visible = false;
            this.comboBoxOrig.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrig_SelectedIndexChanged);
            // 
            // radioButtonOrig
            // 
            this.radioButtonOrig.AutoSize = true;
            this.radioButtonOrig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioButtonOrig.Location = new System.Drawing.Point(12, 19);
            this.radioButtonOrig.Name = "radioButtonOrig";
            this.radioButtonOrig.Size = new System.Drawing.Size(210, 20);
            this.radioButtonOrig.TabIndex = 27;
            this.radioButtonOrig.TabStop = true;
            this.radioButtonOrig.Text = "Copy settings by Orig Tkpr";
            this.radioButtonOrig.UseVisualStyleBackColor = true;
            this.radioButtonOrig.Click += new System.EventHandler(this.radioButtonOrig_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxBill);
            this.groupBox3.Controls.Add(this.radioButtonBill);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(386, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 84);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "By Billing Tkpr";
            // 
            // comboBoxBill
            // 
            this.comboBoxBill.FormattingEnabled = true;
            this.comboBoxBill.Location = new System.Drawing.Point(13, 44);
            this.comboBoxBill.Name = "comboBoxBill";
            this.comboBoxBill.Size = new System.Drawing.Size(229, 21);
            this.comboBoxBill.TabIndex = 30;
            this.comboBoxBill.Visible = false;
            this.comboBoxBill.SelectedIndexChanged += new System.EventHandler(this.comboBoxBill_SelectedIndexChanged);
            // 
            // radioButtonBill
            // 
            this.radioButtonBill.AutoSize = true;
            this.radioButtonBill.BackColor = System.Drawing.SystemColors.Window;
            this.radioButtonBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioButtonBill.Location = new System.Drawing.Point(13, 19);
            this.radioButtonBill.Name = "radioButtonBill";
            this.radioButtonBill.Size = new System.Drawing.Size(220, 20);
            this.radioButtonBill.TabIndex = 29;
            this.radioButtonBill.TabStop = true;
            this.radioButtonBill.Text = "Copy settings by BillingTkpr";
            this.radioButtonBill.UseVisualStyleBackColor = false;
            this.radioButtonBill.Click += new System.EventHandler(this.radioButtonBill_Click);
            // 
            // checkBoxNbrCopies
            // 
            this.checkBoxNbrCopies.AutoSize = true;
            this.checkBoxNbrCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBoxNbrCopies.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxNbrCopies.Location = new System.Drawing.Point(655, 62);
            this.checkBoxNbrCopies.Name = "checkBoxNbrCopies";
            this.checkBoxNbrCopies.Size = new System.Drawing.Size(151, 20);
            this.checkBoxNbrCopies.TabIndex = 27;
            this.checkBoxNbrCopies.Text = "Number of Copies";
            this.checkBoxNbrCopies.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrintBill
            // 
            this.checkBoxPrintBill.AutoSize = true;
            this.checkBoxPrintBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBoxPrintBill.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxPrintBill.Location = new System.Drawing.Point(655, 107);
            this.checkBoxPrintBill.Name = "checkBoxPrintBill";
            this.checkBoxPrintBill.Size = new System.Drawing.Size(84, 20);
            this.checkBoxPrintBill.TabIndex = 39;
            this.checkBoxPrintBill.Text = "Print Bill";
            this.checkBoxPrintBill.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrintARStmt
            // 
            this.checkBoxPrintARStmt.AutoSize = true;
            this.checkBoxPrintARStmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBoxPrintARStmt.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxPrintARStmt.Location = new System.Drawing.Point(655, 159);
            this.checkBoxPrintARStmt.Name = "checkBoxPrintARStmt";
            this.checkBoxPrintARStmt.Size = new System.Drawing.Size(156, 20);
            this.checkBoxPrintARStmt.TabIndex = 40;
            this.checkBoxPrintARStmt.Text = "Print AR Statement";
            this.checkBoxPrintARStmt.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmailType
            // 
            this.checkBoxEmailType.AutoSize = true;
            this.checkBoxEmailType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBoxEmailType.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxEmailType.Location = new System.Drawing.Point(655, 217);
            this.checkBoxEmailType.Name = "checkBoxEmailType";
            this.checkBoxEmailType.Size = new System.Drawing.Size(106, 20);
            this.checkBoxEmailType.TabIndex = 28;
            this.checkBoxEmailType.Text = "Email Type";
            this.checkBoxEmailType.UseVisualStyleBackColor = true;
            // 
            // checkBoxExportType
            // 
            this.checkBoxExportType.AutoSize = true;
            this.checkBoxExportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBoxExportType.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxExportType.Location = new System.Drawing.Point(655, 280);
            this.checkBoxExportType.Name = "checkBoxExportType";
            this.checkBoxExportType.Size = new System.Drawing.Size(111, 20);
            this.checkBoxExportType.TabIndex = 28;
            this.checkBoxExportType.Text = "Export Type";
            this.checkBoxExportType.UseVisualStyleBackColor = true;
            // 
            // checkBoxComment
            // 
            this.checkBoxComment.AutoSize = true;
            this.checkBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBoxComment.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxComment.Location = new System.Drawing.Point(655, 343);
            this.checkBoxComment.Name = "checkBoxComment";
            this.checkBoxComment.Size = new System.Drawing.Size(200, 20);
            this.checkBoxComment.TabIndex = 28;
            this.checkBoxComment.Text = "Comment (30 Characters)";
            this.checkBoxComment.UseVisualStyleBackColor = true;
            // 
            // UtilityBaseMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(853, 456);
            this.Controls.Add(this.checkBoxComment);
            this.Controls.Add(this.checkBoxExportType);
            this.Controls.Add(this.checkBoxEmailType);
            this.Controls.Add(this.checkBoxPrintARStmt);
            this.Controls.Add(this.checkBoxPrintBill);
            this.Controls.Add(this.checkBoxNbrCopies);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.statusGroupBox);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.listBoxCompanies);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.LexisNexisLogoPictureBox);
            this.Controls.Add(this.JurisLogoImageBox);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UtilityBaseMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JPS - Bill Copy Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.JurisLogoImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LexisNexisLogoPictureBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox JurisLogoImageBox;
        private System.Windows.Forms.PictureBox LexisNexisLogoPictureBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ListBox listBoxCompanies;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.Label labelCurrentStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelPercentComplete;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogOpen;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxClient;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ListView listViewClient;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonClient;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxOrig;
        private System.Windows.Forms.RadioButton radioButtonOrig;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxBill;
        private System.Windows.Forms.RadioButton radioButtonBill;
        private System.Windows.Forms.CheckBox checkBoxNbrCopies;
        private System.Windows.Forms.CheckBox checkBoxPrintBill;
        private System.Windows.Forms.CheckBox checkBoxPrintARStmt;
        private System.Windows.Forms.CheckBox checkBoxEmailType;
        private System.Windows.Forms.CheckBox checkBoxExportType;
        private System.Windows.Forms.CheckBox checkBoxComment;
    }
}

