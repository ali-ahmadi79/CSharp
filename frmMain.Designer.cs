namespace TCCIM_DB_Update
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label1 = new System.Windows.Forms.Label();
            this.DDB_IP = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTargetDB = new System.Windows.Forms.Label();
            this.lblTargetIP = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstLogs = new System.Windows.Forms.ListBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkLstSourceDB = new System.Windows.Forms.CheckedListBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSourceDBName = new System.Windows.Forms.Label();
            this.lblSourceIP = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ClearEvents = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkScheduleDisable = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtScheduleInterval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkQueries = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleDisableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryVariablesDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryTablesDefinitionTipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LstListOfQueriesTargetDelete = new System.Windows.Forms.ListBox();
            this.LstListOfQueriesTargetDeleteField = new System.Windows.Forms.ListBox();
            this.picWorking = new System.Windows.Forms.PictureBox();
            this.LstListOfQueriesTargetTables = new System.Windows.Forms.ListBox();
            this.chkTablesSelectAll = new System.Windows.Forms.CheckBox();
            this.chkSelectAllQueries = new System.Windows.Forms.CheckBox();
            this.StatusStrip1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWorking)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 679);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(982, 22);
            this.StatusStrip1.TabIndex = 25;
            this.StatusStrip1.Text = "StatusStrip1";
            this.StatusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.StatusStrip1_ItemClicked);
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 68);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(111, 14);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Source DB Name:";
            // 
            // DDB_IP
            // 
            this.DDB_IP.AutoSize = true;
            this.DDB_IP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DDB_IP.Location = new System.Drawing.Point(6, 34);
            this.DDB_IP.Name = "DDB_IP";
            this.DDB_IP.Size = new System.Drawing.Size(24, 14);
            this.DDB_IP.TabIndex = 2;
            this.DDB_IP.Text = "IP:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.lblTargetDB);
            this.GroupBox2.Controls.Add(this.lblTargetIP);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Location = new System.Drawing.Point(445, 37);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(315, 111);
            this.GroupBox2.TabIndex = 17;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Target DB Info:";
            // 
            // lblTargetDB
            // 
            this.lblTargetDB.AutoSize = true;
            this.lblTargetDB.Location = new System.Drawing.Point(122, 70);
            this.lblTargetDB.Name = "lblTargetDB";
            this.lblTargetDB.Size = new System.Drawing.Size(63, 13);
            this.lblTargetDB.TabIndex = 6;
            this.lblTargetDB.Text = "lblTargetDB";
            // 
            // lblTargetIP
            // 
            this.lblTargetIP.AutoSize = true;
            this.lblTargetIP.Location = new System.Drawing.Point(47, 35);
            this.lblTargetIP.Name = "lblTargetIP";
            this.lblTargetIP.Size = new System.Drawing.Size(58, 13);
            this.lblTargetIP.TabIndex = 5;
            this.lblTargetIP.Text = "lblTargetIP";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(7, 69);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(109, 14);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Target DB Name:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(7, 35);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(24, 14);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "IP:";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("PictureBox1.InitialImage")));
            this.PictureBox1.Location = new System.Drawing.Point(344, 50);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(95, 98);
            this.PictureBox1.TabIndex = 15;
            this.PictureBox1.TabStop = false;
            // 
            // lstLogs
            // 
            this.lstLogs.FormattingEnabled = true;
            this.lstLogs.Location = new System.Drawing.Point(321, 181);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(646, 407);
            this.lstLogs.TabIndex = 26;
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTransfer.Location = new System.Drawing.Point(321, 601);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(358, 66);
            this.btnTransfer.TabIndex = 24;
            this.btnTransfer.Text = "Start Transfer (Update Jobs)";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(318, 165);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(52, 14);
            this.Label5.TabIndex = 23;
            this.Label5.Text = "Events:";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.Location = new System.Drawing.Point(207, 262);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 26);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete Target Data";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkLstSourceDB
            // 
            this.chkLstSourceDB.CheckOnClick = true;
            this.chkLstSourceDB.FormattingEnabled = true;
            this.chkLstSourceDB.Location = new System.Drawing.Point(12, 180);
            this.chkLstSourceDB.Name = "chkLstSourceDB";
            this.chkLstSourceDB.Size = new System.Drawing.Size(303, 79);
            this.chkLstSourceDB.TabIndex = 18;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblSourceDBName);
            this.GroupBox1.Controls.Add(this.lblSourceIP);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.DDB_IP);
            this.GroupBox1.Location = new System.Drawing.Point(12, 33);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(303, 111);
            this.GroupBox1.TabIndex = 16;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Source DB Info:";
            // 
            // lblSourceDBName
            // 
            this.lblSourceDBName.AutoSize = true;
            this.lblSourceDBName.Location = new System.Drawing.Point(123, 69);
            this.lblSourceDBName.Name = "lblSourceDBName";
            this.lblSourceDBName.Size = new System.Drawing.Size(94, 13);
            this.lblSourceDBName.TabIndex = 5;
            this.lblSourceDBName.Text = "lblSourceDBName";
            // 
            // lblSourceIP
            // 
            this.lblSourceIP.AutoSize = true;
            this.lblSourceIP.Location = new System.Drawing.Point(36, 35);
            this.lblSourceIP.Name = "lblSourceIP";
            this.lblSourceIP.Size = new System.Drawing.Size(61, 13);
            this.lblSourceIP.TabIndex = 4;
            this.lblSourceIP.Text = "lblSourceIP";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(454, 547);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(10, 29);
            this.progressBar1.TabIndex = 27;
            this.progressBar1.Visible = false;
            // 
            // ClearEvents
            // 
            this.ClearEvents.AutoEllipsis = true;
            this.ClearEvents.AutoSize = true;
            this.ClearEvents.Location = new System.Drawing.Point(936, 166);
            this.ClearEvents.Name = "ClearEvents";
            this.ClearEvents.Size = new System.Drawing.Size(31, 13);
            this.ClearEvents.TabIndex = 28;
            this.ClearEvents.TabStop = true;
            this.ClearEvents.Text = "Clear";
            this.ClearEvents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClearEvents_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkScheduleDisable);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtScheduleInterval);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(766, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 111);
            this.panel1.TabIndex = 32;
            // 
            // chkScheduleDisable
            // 
            this.chkScheduleDisable.AutoSize = true;
            this.chkScheduleDisable.Location = new System.Drawing.Point(16, 67);
            this.chkScheduleDisable.Name = "chkScheduleDisable";
            this.chkScheduleDisable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkScheduleDisable.Size = new System.Drawing.Size(109, 17);
            this.chkScheduleDisable.TabIndex = 35;
            this.chkScheduleDisable.Text = "Schedule Disable";
            this.chkScheduleDisable.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Minutes";
            // 
            // txtScheduleInterval
            // 
            this.txtScheduleInterval.Location = new System.Drawing.Point(38, 33);
            this.txtScheduleInterval.Name = "txtScheduleInterval";
            this.txtScheduleInterval.Size = new System.Drawing.Size(49, 20);
            this.txtScheduleInterval.TabIndex = 33;
            this.txtScheduleInterval.Text = "1440";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Schedule Interval:";
            // 
            // chkQueries
            // 
            this.chkQueries.CheckOnClick = true;
            this.chkQueries.FormattingEnabled = true;
            this.chkQueries.Location = new System.Drawing.Point(12, 303);
            this.chkQueries.Name = "chkQueries";
            this.chkQueries.Size = new System.Drawing.Size(303, 364);
            this.chkQueries.TabIndex = 34;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleDisableToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // scheduleDisableToolStripMenuItem
            // 
            this.scheduleDisableToolStripMenuItem.Name = "scheduleDisableToolStripMenuItem";
            this.scheduleDisableToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.scheduleDisableToolStripMenuItem.Text = "Schedule Disable";
            this.scheduleDisableToolStripMenuItem.Click += new System.EventHandler(this.scheduleDisableToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryVariablesDefinitionToolStripMenuItem,
            this.queryTablesDefinitionTipsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // queryVariablesDefinitionToolStripMenuItem
            // 
            this.queryVariablesDefinitionToolStripMenuItem.Name = "queryVariablesDefinitionToolStripMenuItem";
            this.queryVariablesDefinitionToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.queryVariablesDefinitionToolStripMenuItem.Text = "Query Variables Definition";
            this.queryVariablesDefinitionToolStripMenuItem.Click += new System.EventHandler(this.queryVariablesDefinitionToolStripMenuItem_Click);
            // 
            // queryTablesDefinitionTipsToolStripMenuItem
            // 
            this.queryTablesDefinitionTipsToolStripMenuItem.Name = "queryTablesDefinitionTipsToolStripMenuItem";
            this.queryTablesDefinitionTipsToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.queryTablesDefinitionTipsToolStripMenuItem.Text = "Query Tables Definition in Config file Tips";
            this.queryTablesDefinitionTipsToolStripMenuItem.Click += new System.EventHandler(this.queryTablesDefinitionTipsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // LstListOfQueriesTargetDelete
            // 
            this.LstListOfQueriesTargetDelete.FormattingEnabled = true;
            this.LstListOfQueriesTargetDelete.Location = new System.Drawing.Point(469, 546);
            this.LstListOfQueriesTargetDelete.Name = "LstListOfQueriesTargetDelete";
            this.LstListOfQueriesTargetDelete.Size = new System.Drawing.Size(124, 17);
            this.LstListOfQueriesTargetDelete.TabIndex = 38;
            this.LstListOfQueriesTargetDelete.Visible = false;
            // 
            // LstListOfQueriesTargetDeleteField
            // 
            this.LstListOfQueriesTargetDeleteField.FormattingEnabled = true;
            this.LstListOfQueriesTargetDeleteField.Location = new System.Drawing.Point(599, 546);
            this.LstListOfQueriesTargetDeleteField.Name = "LstListOfQueriesTargetDeleteField";
            this.LstListOfQueriesTargetDeleteField.Size = new System.Drawing.Size(181, 17);
            this.LstListOfQueriesTargetDeleteField.TabIndex = 39;
            this.LstListOfQueriesTargetDeleteField.Visible = false;
            // 
            // picWorking
            // 
            this.picWorking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWorking.Image = ((System.Drawing.Image)(resources.GetObject("picWorking.Image")));
            this.picWorking.Location = new System.Drawing.Point(904, 601);
            this.picWorking.Name = "picWorking";
            this.picWorking.Size = new System.Drawing.Size(63, 66);
            this.picWorking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWorking.TabIndex = 40;
            this.picWorking.TabStop = false;
            this.picWorking.Visible = false;
            // 
            // LstListOfQueriesTargetTables
            // 
            this.LstListOfQueriesTargetTables.FormattingEnabled = true;
            this.LstListOfQueriesTargetTables.Location = new System.Drawing.Point(786, 546);
            this.LstListOfQueriesTargetTables.Name = "LstListOfQueriesTargetTables";
            this.LstListOfQueriesTargetTables.Size = new System.Drawing.Size(184, 17);
            this.LstListOfQueriesTargetTables.TabIndex = 41;
            this.LstListOfQueriesTargetTables.Visible = false;
            // 
            // chkTablesSelectAll
            // 
            this.chkTablesSelectAll.AutoSize = true;
            this.chkTablesSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTablesSelectAll.Location = new System.Drawing.Point(15, 159);
            this.chkTablesSelectAll.Name = "chkTablesSelectAll";
            this.chkTablesSelectAll.Size = new System.Drawing.Size(194, 19);
            this.chkTablesSelectAll.TabIndex = 42;
            this.chkTablesSelectAll.Text = "Source DB Tables / Views:";
            this.chkTablesSelectAll.UseVisualStyleBackColor = true;
            this.chkTablesSelectAll.CheckedChanged += new System.EventHandler(this.chkTablesSelectAll_CheckedChanged);
            // 
            // chkSelectAllQueries
            // 
            this.chkSelectAllQueries.AutoSize = true;
            this.chkSelectAllQueries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAllQueries.Location = new System.Drawing.Point(15, 280);
            this.chkSelectAllQueries.Name = "chkSelectAllQueries";
            this.chkSelectAllQueries.Size = new System.Drawing.Size(125, 19);
            this.chkSelectAllQueries.TabIndex = 43;
            this.chkSelectAllQueries.Text = "Source Queries";
            this.chkSelectAllQueries.UseVisualStyleBackColor = true;
            this.chkSelectAllQueries.CheckedChanged += new System.EventHandler(this.chkSelectAllQueries_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(982, 701);
            this.Controls.Add(this.chkSelectAllQueries);
            this.Controls.Add(this.chkTablesSelectAll);
            this.Controls.Add(this.LstListOfQueriesTargetTables);
            this.Controls.Add(this.picWorking);
            this.Controls.Add(this.LstListOfQueriesTargetDeleteField);
            this.Controls.Add(this.LstListOfQueriesTargetDelete);
            this.Controls.Add(this.chkQueries);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ClearEvents);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.lstLogs);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.chkLstSourceDB);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETL Export Data";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWorking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label DDB_IP;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.ListBox lstLogs;
        internal System.Windows.Forms.Button btnTransfer;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.CheckedListBox chkLstSourceDB;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label lblSourceDBName;
        private System.Windows.Forms.Label lblSourceIP;
        private System.Windows.Forms.Label lblTargetDB;
        private System.Windows.Forms.Label lblTargetIP;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.LinkLabel ClearEvents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtScheduleInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkScheduleDisable;
        internal System.Windows.Forms.CheckedListBox chkQueries;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleDisableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryVariablesDefinitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryTablesDefinitionTipsToolStripMenuItem;
        private System.Windows.Forms.ListBox LstListOfQueriesTargetDelete;
        private System.Windows.Forms.ListBox LstListOfQueriesTargetDeleteField;
        private System.Windows.Forms.PictureBox picWorking;
        private System.Windows.Forms.ListBox LstListOfQueriesTargetTables;
        private System.Windows.Forms.CheckBox chkTablesSelectAll;
        private System.Windows.Forms.CheckBox chkSelectAllQueries;
    }
}

