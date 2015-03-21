namespace Prison_Architect_Prison_Manager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configiniFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSavesFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBackupFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pAWikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAllSaves = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnMap = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastBackup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGo = new System.Windows.Forms.Button();
            this.tabBackups = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewBackups = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSavedGroup = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRestoreAllGroup = new System.Windows.Forms.Button();
            this.comboBoxGroups = new System.Windows.Forms.ComboBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.btnCleanup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbthumbsize = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbBackup_loc = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tBoxAppPath = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupAsGroupABCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupAsGroupABCAndRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAllSaves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabBackups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackups)).BeginInit();
            this.tabSavedGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(548, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logFileToolStripMenuItem,
            this.configiniFileToolStripMenuItem,
            this.openSavesFolderToolStripMenuItem,
            this.openBackupFolderToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // logFileToolStripMenuItem
            // 
            this.logFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logFileToolStripMenuItem.Image")));
            this.logFileToolStripMenuItem.Name = "logFileToolStripMenuItem";
            this.logFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.logFileToolStripMenuItem.Text = "Log File";
            this.logFileToolStripMenuItem.Click += new System.EventHandler(this.logFileToolStripMenuItem_Click);
            // 
            // configiniFileToolStripMenuItem
            // 
            this.configiniFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configiniFileToolStripMenuItem.Image")));
            this.configiniFileToolStripMenuItem.Name = "configiniFileToolStripMenuItem";
            this.configiniFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.configiniFileToolStripMenuItem.Text = "Config.ini File";
            this.configiniFileToolStripMenuItem.Click += new System.EventHandler(this.configiniFileToolStripMenuItem_Click);
            // 
            // openSavesFolderToolStripMenuItem
            // 
            this.openSavesFolderToolStripMenuItem.Name = "openSavesFolderToolStripMenuItem";
            this.openSavesFolderToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.openSavesFolderToolStripMenuItem.Text = "Open saves folder";
            this.openSavesFolderToolStripMenuItem.Click += new System.EventHandler(this.openSavesFolderToolStripMenuItem_Click);
            // 
            // openBackupFolderToolStripMenuItem
            // 
            this.openBackupFolderToolStripMenuItem.Name = "openBackupFolderToolStripMenuItem";
            this.openBackupFolderToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.openBackupFolderToolStripMenuItem.Text = "Open backup folder";
            this.openBackupFolderToolStripMenuItem.Click += new System.EventHandler(this.openBackupFolderToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readMeToolStripMenuItem,
            this.pAWikiToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // readMeToolStripMenuItem
            // 
            this.readMeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("readMeToolStripMenuItem.Image")));
            this.readMeToolStripMenuItem.Name = "readMeToolStripMenuItem";
            this.readMeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.readMeToolStripMenuItem.Text = "ReadMe";
            this.readMeToolStripMenuItem.Click += new System.EventHandler(this.readMeToolStripMenuItem_Click_1);
            // 
            // pAWikiToolStripMenuItem
            // 
            this.pAWikiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pAWikiToolStripMenuItem.Image")));
            this.pAWikiToolStripMenuItem.Name = "pAWikiToolStripMenuItem";
            this.pAWikiToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.pAWikiToolStripMenuItem.Text = "PA Recent Wiki Activity";
            this.pAWikiToolStripMenuItem.Click += new System.EventHandler(this.pAWikiToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAllSaves);
            this.tabControl1.Controls.Add(this.tabBackups);
            this.tabControl1.Controls.Add(this.tabSavedGroup);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(536, 446);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabAllSaves
            // 
            this.tabAllSaves.Controls.Add(this.progressBar1);
            this.tabAllSaves.Controls.Add(this.dataGridView1);
            this.tabAllSaves.Controls.Add(this.btnGo);
            this.tabAllSaves.Location = new System.Drawing.Point(4, 22);
            this.tabAllSaves.Name = "tabAllSaves";
            this.tabAllSaves.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllSaves.Size = new System.Drawing.Size(528, 420);
            this.tabAllSaves.TabIndex = 0;
            this.tabAllSaves.Text = "AllSaves";
            this.tabAllSaves.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(306, 392);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(203, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMap,
            this.ColumnName,
            this.ColumnLastBackup,
            this.ColumnFilename});
            this.dataGridView1.Location = new System.Drawing.Point(8, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(501, 379);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // ColumnMap
            // 
            this.ColumnMap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnMap.FillWeight = 30.45685F;
            this.ColumnMap.HeaderText = "Map";
            this.ColumnMap.Name = "ColumnMap";
            this.ColumnMap.ReadOnly = true;
            this.ColumnMap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnMap.Width = 53;
            // 
            // ColumnName
            // 
            this.ColumnName.FillWeight = 123.181F;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnLastBackup
            // 
            this.ColumnLastBackup.FillWeight = 123.181F;
            this.ColumnLastBackup.HeaderText = "Last Backup";
            this.ColumnLastBackup.Name = "ColumnLastBackup";
            this.ColumnLastBackup.ReadOnly = true;
            // 
            // ColumnFilename
            // 
            this.ColumnFilename.FillWeight = 123.181F;
            this.ColumnFilename.HeaderText = "Filename";
            this.ColumnFilename.Name = "ColumnFilename";
            this.ColumnFilename.ReadOnly = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(207, 391);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tabBackups
            // 
            this.tabBackups.Controls.Add(this.groupBox1);
            this.tabBackups.Controls.Add(this.dataGridViewBackups);
            this.tabBackups.Location = new System.Drawing.Point(4, 22);
            this.tabBackups.Name = "tabBackups";
            this.tabBackups.Size = new System.Drawing.Size(528, 420);
            this.tabBackups.TabIndex = 3;
            this.tabBackups.Text = "Backups";
            this.tabBackups.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(14, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 48);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Group...";
            // 
            // dataGridViewBackups
            // 
            this.dataGridViewBackups.AllowUserToAddRows = false;
            this.dataGridViewBackups.AllowUserToDeleteRows = false;
            this.dataGridViewBackups.AllowUserToOrderColumns = true;
            this.dataGridViewBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBackups.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBackups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewBackups.Location = new System.Drawing.Point(14, 67);
            this.dataGridViewBackups.MultiSelect = false;
            this.dataGridViewBackups.Name = "dataGridViewBackups";
            this.dataGridViewBackups.ReadOnly = true;
            this.dataGridViewBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBackups.Size = new System.Drawing.Size(501, 333);
            this.dataGridViewBackups.TabIndex = 6;
            this.dataGridViewBackups.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewBackups_MouseDown);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewImageColumn1.FillWeight = 30.45685F;
            this.dataGridViewImageColumn1.HeaderText = "Map";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 53;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 123.181F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 123.181F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Last Backup";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 123.181F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Filename";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // tabSavedGroup
            // 
            this.tabSavedGroup.Controls.Add(this.groupBox2);
            this.tabSavedGroup.Location = new System.Drawing.Point(4, 22);
            this.tabSavedGroup.Name = "tabSavedGroup";
            this.tabSavedGroup.Size = new System.Drawing.Size(528, 420);
            this.tabSavedGroup.TabIndex = 2;
            this.tabSavedGroup.Text = "Saves Group";
            this.tabSavedGroup.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewGroups);
            this.groupBox2.Controls.Add(this.btnRestoreAllGroup);
            this.groupBox2.Controls.Add(this.comboBoxGroups);
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 397);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Existing Backup Groups...";
            // 
            // dataGridViewGroups
            // 
            this.dataGridViewGroups.AllowUserToAddRows = false;
            this.dataGridViewGroups.AllowUserToDeleteRows = false;
            this.dataGridViewGroups.AllowUserToOrderColumns = true;
            this.dataGridViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGroups.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridViewGroups.Location = new System.Drawing.Point(6, 52);
            this.dataGridViewGroups.MultiSelect = false;
            this.dataGridViewGroups.Name = "dataGridViewGroups";
            this.dataGridViewGroups.ReadOnly = true;
            this.dataGridViewGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroups.Size = new System.Drawing.Size(503, 339);
            this.dataGridViewGroups.TabIndex = 6;
            this.dataGridViewGroups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGroups_CellDoubleClick);
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewImageColumn2.FillWeight = 30.45685F;
            this.dataGridViewImageColumn2.HeaderText = "Map";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 53;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 123.181F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 123.181F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Last Backup";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 123.181F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Filename";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // btnRestoreAllGroup
            // 
            this.btnRestoreAllGroup.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestoreAllGroup.Location = new System.Drawing.Point(254, 20);
            this.btnRestoreAllGroup.Name = "btnRestoreAllGroup";
            this.btnRestoreAllGroup.Size = new System.Drawing.Size(257, 26);
            this.btnRestoreAllGroup.TabIndex = 1;
            this.btnRestoreAllGroup.Text = "Restore All Prisons in Group";
            this.btnRestoreAllGroup.UseVisualStyleBackColor = true;
            this.btnRestoreAllGroup.Click += new System.EventHandler(this.btnRestoreAllGroup_Click);
            // 
            // comboBoxGroups
            // 
            this.comboBoxGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroups.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGroups.FormattingEnabled = true;
            this.comboBoxGroups.Location = new System.Drawing.Point(6, 20);
            this.comboBoxGroups.Name = "comboBoxGroups";
            this.comboBoxGroups.Size = new System.Drawing.Size(242, 26);
            this.comboBoxGroups.TabIndex = 0;
            this.comboBoxGroups.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroups_SelectedIndexChanged);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.btnCleanup);
            this.tabSettings.Controls.Add(this.label2);
            this.tabSettings.Controls.Add(this.cbthumbsize);
            this.tabSettings.Controls.Add(this.btnBrowse);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.txtbBackup_loc);
            this.tabSettings.Controls.Add(this.numericUpDown1);
            this.tabSettings.Controls.Add(this.label10);
            this.tabSettings.Controls.Add(this.bSave);
            this.tabSettings.Controls.Add(this.label7);
            this.tabSettings.Controls.Add(this.tBoxAppPath);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(528, 420);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // btnCleanup
            // 
            this.btnCleanup.Location = new System.Drawing.Point(13, 220);
            this.btnCleanup.Name = "btnCleanup";
            this.btnCleanup.Size = new System.Drawing.Size(258, 23);
            this.btnCleanup.TabIndex = 72;
            this.btnCleanup.Text = "Manually delete  temp folder";
            this.btnCleanup.UseVisualStyleBackColor = true;
            this.btnCleanup.Click += new System.EventHandler(this.btnCleanup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Thumbnail size (default=64x64):";
            // 
            // cbthumbsize
            // 
            this.cbthumbsize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbthumbsize.FormattingEnabled = true;
            this.cbthumbsize.Items.AddRange(new object[] {
            "32x32",
            "64x64",
            "128x128"});
            this.cbthumbsize.Location = new System.Drawing.Point(172, 175);
            this.cbthumbsize.Name = "cbthumbsize";
            this.cbthumbsize.Size = new System.Drawing.Size(99, 21);
            this.cbthumbsize.TabIndex = 70;
            this.cbthumbsize.SelectedIndexChanged += new System.EventHandler(this.cbthumbsize_SelectedIndexChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(442, 114);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 69;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Backup Location:";
            // 
            // txtbBackup_loc
            // 
            this.txtbBackup_loc.AcceptsReturn = true;
            this.txtbBackup_loc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbBackup_loc.Location = new System.Drawing.Point(103, 116);
            this.txtbBackup_loc.Name = "txtbBackup_loc";
            this.txtbBackup_loc.ReadOnly = true;
            this.txtbBackup_loc.Size = new System.Drawing.Size(333, 20);
            this.txtbBackup_loc.TabIndex = 67;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Location = new System.Drawing.Point(238, 71);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            364,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown1.TabIndex = 66;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Cleanup days (days to examine for purging):";
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Location = new System.Drawing.Point(190, 380);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(148, 34);
            this.bSave.TabIndex = 38;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Application Path:";
            // 
            // tBoxAppPath
            // 
            this.tBoxAppPath.AcceptsReturn = true;
            this.tBoxAppPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxAppPath.Location = new System.Drawing.Point(113, 29);
            this.tBoxAppPath.Name = "tBoxAppPath";
            this.tBoxAppPath.ReadOnly = true;
            this.tBoxAppPath.Size = new System.Drawing.Size(333, 20);
            this.tBoxAppPath.TabIndex = 36;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.backupRemoveToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.backupAsGroupABCToolStripMenuItem,
            this.backupAsGroupABCAndRemoveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(259, 114);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // backupRemoveToolStripMenuItem
            // 
            this.backupRemoveToolStripMenuItem.Name = "backupRemoveToolStripMenuItem";
            this.backupRemoveToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.backupRemoveToolStripMenuItem.Text = "Backup and Remove";
            this.backupRemoveToolStripMenuItem.Click += new System.EventHandler(this.backupRemoveToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // backupAsGroupABCToolStripMenuItem
            // 
            this.backupAsGroupABCToolStripMenuItem.Name = "backupAsGroupABCToolStripMenuItem";
            this.backupAsGroupABCToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.backupAsGroupABCToolStripMenuItem.Text = "Backup as Group ABC";
            this.backupAsGroupABCToolStripMenuItem.Click += new System.EventHandler(this.backupAsGroupABCToolStripMenuItem_Click);
            // 
            // backupAsGroupABCAndRemoveToolStripMenuItem
            // 
            this.backupAsGroupABCAndRemoveToolStripMenuItem.Name = "backupAsGroupABCAndRemoveToolStripMenuItem";
            this.backupAsGroupABCAndRemoveToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.backupAsGroupABCAndRemoveToolStripMenuItem.Text = "Backup as Group ABC and Remove";
            this.backupAsGroupABCAndRemoveToolStripMenuItem.Click += new System.EventHandler(this.backupAsGroupABCAndRemoveToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.deleteToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(114, 48);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click_1);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 463);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(548, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(548, 485);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabAllSaves.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabBackups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackups)).EndInit();
            this.tabSavedGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAllSaves;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBoxAppPath;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logFileToolStripMenuItem;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ToolStripMenuItem configiniFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbBackup_loc;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ToolStripMenuItem openSavesFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBackupFolderToolStripMenuItem;
        private System.Windows.Forms.TabPage tabSavedGroup;
        private System.Windows.Forms.TabPage tabBackups;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastBackup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFilename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbthumbsize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewBackups;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem backupRemoveToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem backupAsGroupABCToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem backupAsGroupABCAndRemoveToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxGroups;
        private System.Windows.Forms.Button btnRestoreAllGroup;
        private System.Windows.Forms.DataGridView dataGridViewGroups;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnCleanup;
        private System.Windows.Forms.ToolStripMenuItem readMeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem pAWikiToolStripMenuItem;

    }
}

