// Prison Architect Prison Manager v1.8.1.0
// by Joe Socoloski
// Copyright 2015. All Rights Reserved
// To Do:   - Read .prison file to display stats.
//          - Fix restoreToolStripMenuItem_Click to overwrite all files well prompt the user to make certain.
// What's New: - Restore from Group files
//
/////////////////////////////////////////////////////////
//LICENSE 
//BY DOWNLOADING AND USING, YOU AGREE TO THE FOLLOWING TERMS: 
//If it is your intent to use this software for non-commercial purposes,  
//such as in academic research, this software is free and is covered under  
//the GNU GPL License, given here: <http://www.gnu.org/licenses/gpl.txt>  
//You agree with 3RDPARTY's Terms Of Service 
//given here: <http://3RDPARTY.com> 
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;
using Microsoft.VisualBasic.FileIO;


namespace Prison_Architect_Prison_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public IniFile Ini = new IniFile();
        public ImageList ImageListWorlds = new ImageList();
        public DirectoryInfo savedDir = null;
        public DirectoryInfo backedupDir = null;
        public List<DirectoryInfo> CleanUpDirs = new List<DirectoryInfo>();

        private void CreateLogFile()
        {
            //Create log file if not there
            if (!File.Exists(Common.gLogFile))
            {
                FileStream fs = File.Create(Common.gLogFile);
                fs.Close();
            }
        }

        private void Log(string logline)
        {
            File.AppendAllText(Common.gLogFile, DateTime.Now.ToString() + ", " + logline + "\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Update the Title bar text
            this.Text = Application.ProductName + " " + Application.ProductVersion;
            toolTip1.SetToolTip(this.dataGridView1, "Right-Click for menu. Double-click to open map.");
            ReadSettings();
            CreateLogFile();

            //DEBUG
            //MessageBox.Show(Common.savesDir);

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 12.00F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                col.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.HotTrack;
            }

            //make sure the top row is selected
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = true;
            this.tabAllSaves.BringToFront();//make sure to bring to front, this also forces the selection above.
            this.tabAllSaves.Focus();

            LoadSavedWorlds();
        }

        #region Settings Read and Save
        private void ReadSettings()
        {
            try
            {
                //Read the Config file and display in the textboxes
                if (Properties.Settings.Default.AppPath == "")
                {
                    tBoxAppPath.Text = Application.StartupPath;
                }
                else
                    tBoxAppPath.Text = Properties.Settings.Default.AppPath;

                //INI
                if (File.Exists(Common.ConfigIniFile))
                {
                    Ini.Load(Common.ConfigIniFile);
                }
                else
                {
                    //File.Create(Common.ConfigIniFile);
                    Ini.AddSection("settings").AddKey("thumbsize").SetValue("64x64");
                    Ini.AddSection("settings").AddKey("cleanupdays").SetValue("7");
                    Ini.AddSection("settings").AddKey("pa_saves").SetValue(Common.savesDir);
                    Ini.AddSection("settings").AddKey("map_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnMap"].Width));
                    Ini.AddSection("settings").AddKey("name_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnName"].Width));
                    Ini.AddSection("settings").AddKey("lastbackup_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnLastBackup"].Width));
                    Ini.AddSection("settings").AddKey("filename_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnFilename"].Width));
                    Ini.AddSection("settings").AddKey("backup_loc").SetValue("");
                    MessageBox.Show("In the settings tab, please browse out to your Prison Architect backup folder to let the manager know where to store your backups.", "No Backup Location Set", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    //Ini.GetSection("settings").AddKey("removeeasies").SetValue("true");
                    Ini.Save(Common.ConfigIniFile);
                }

                //Execute settings
                if (Ini.HasSection("settings"))
                {
                    //select the correct dropdown selection
                    numericUpDown1.Value = Convert.ToDecimal(Ini.GetKeyValue("settings", "cleanupdays"));
                    dataGridView1.Columns["ColumnMap"].Width = Convert.ToInt16(Ini.GetKeyValue("settings", "map_col_width"));
                    dataGridView1.Columns["ColumnName"].Width = Convert.ToInt16(Ini.GetKeyValue("settings", "name_col_width"));
                    dataGridView1.Columns["ColumnLastBackup"].Width = Convert.ToInt16(Ini.GetKeyValue("settings", "lastbackup_col_width"));
                    dataGridView1.Columns["ColumnFilename"].Width = Convert.ToInt16(Ini.GetKeyValue("settings", "filename_col_width"));
                    //cbthumbsize.SelectedIndex = 
                    switch (Ini.GetKeyValue("settings", "thumbsize"))       
                    {
                        case "128x128":
                            cbthumbsize.SelectedIndex = 2;
                            break;
                        case "64x64":
                            cbthumbsize.SelectedIndex = 1;
                            break;
                        case "32x32":
                            cbthumbsize.SelectedIndex = 0;
                            break;
                        default:
                            break;
                    }
                    txtbBackup_loc.Text = Ini.GetKeyValue("settings", "backup_loc");
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.AppPath = tBoxAppPath.Text;
                Properties.Settings.Default.Save();

                //read the controls and save the selections
                Ini.AddSection("settings").AddKey("cleanupdays").SetValue(Convert.ToString(numericUpDown1.Value));
                Ini.GetSection("settings").AddKey("map_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnMap"].Width));
                Ini.GetSection("settings").AddKey("name_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnName"].Width));
                Ini.GetSection("settings").AddKey("lastbackup_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnLastBackup"].Width));
                Ini.GetSection("settings").AddKey("filename_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnFilename"].Width));
                Ini.GetSection("settings").AddKey("backup_loc").SetValue(txtbBackup_loc.Text.Trim());
                switch (cbthumbsize.SelectedIndex)
                {
                    case 0:
                        Ini.GetSection("settings").AddKey("thumbsize").SetValue("32x32");
                        break;
                    case 1:
                         Ini.GetSection("settings").AddKey("thumbsize").SetValue("64x64");
                        break;
                    case 2:
                        Ini.GetSection("settings").AddKey("thumbsize").SetValue("128x128");
                        break;
                    default:
                        break;
                }
                Ini.Save(Common.ConfigIniFile);
                bSave.Enabled = false;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Settings Read and Save

        #region MenuStrip Items

        private void readMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Common.ReadMe);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readMeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Common.ReadMe);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pAWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://prison-architect.wikia.com/wiki/Special:WikiActivity");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DoBackup(false);
            }
            catch (Exception ex)
            {
                Log("backupToolStripMenuItem_Click: " + ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Common.gLogFile);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();
        }

        private void configiniFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Common.ConfigIniFile);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #endregion MenuStrip Items

        #region Sound
        /// <summary>
        /// Play local copy 
        /// </summary>
        private void PlaySound()
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer();
            //sound.SoundLocation = Common.sound_wav_correct4;
            sound.Play();
        }

        /// <summary>
        /// Play local copy 
        /// </summary>
        private void PlayRandomSound(bool IsCorrect)
        {
            if (IsCorrect)
            {
                System.Media.SoundPlayer sound = new System.Media.SoundPlayer();
                Random rand = new Random();//rand.Next(1, 12)
                int iChoose = rand.Next(1, 4);
                /*
                switch (iChoose)
                {
                    case 1:
                        sound.SoundLocation = Common.sound_wav_correct1;
                        break;
                    case 2:
                        sound.SoundLocation = Common.sound_wav_correct2;
                        break;
                    case 3:
                        sound.SoundLocation = Common.sound_wav_correct3;
                        break;
                    case 4:
                        sound.SoundLocation = Common.sound_wav_correct4;
                        break;
                    default:
                        sound.SoundLocation = Common.sound_wav_correct4;
                        break;
                }
                 */
                sound.Play();
            }
            else
            {

            }

        }
        #endregion Sound

        #region Misc
        private int PickRandomNumber(bool removeeasies)
        {
            Cursor.Current = Cursors.WaitCursor;
            int i = 1;
            try
            {
                if (!removeeasies)
                {
                    Random rand = new Random();//rand.Next(1, 12)
                    i = rand.Next(1, 12);
                }
                else
                {
                    //don't pick any easy ones 1,2,5,10,11
                    while (i == 1 || i == 2 || i == 5 || i == 10 || i == 11)
                    {
                        Random rand = new Random();
                        i = rand.Next(1, 12);
                    }
                }
                System.Threading.Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
            return i;
        }
        #endregion Misc

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            bSave.Enabled = true;
        }

        /// <summary>
        /// Reads the ini path for the "pa_saves"
        /// and learns all the world names.
        /// </summary>
        /// <returns>List of Strings</returns>
        private List<String> GetWorldNames()
        {
            List<String> WORLDNAMESLIST = new List<string>();
            //Now list each saved World and then match a rendered image
            DirectoryInfo savedDirectory = new DirectoryInfo(Ini.GetKeyValue("settings", "pa_saves"));
            FileInfo[] filesaved0 = savedDirectory.GetFiles();
            if (filesaved0.Length > 0)
            {
                foreach (FileInfo world in filesaved0)
                {
                    if (world.Name.EndsWith(".png"))
                    {
                        string NAME = world.Name.Replace(".png", "");
                        //if (NAME != "")//causing offness on the list?
                            WORLDNAMESLIST.Add(NAME);
                    }
                    else
                    {
                        //nothing; do not add to list
                    }
                }
            }
            return WORLDNAMESLIST;
        }

        /// <summary>
        /// Reads the ini file for previous column settings (if found)
        /// it saves them or it saves the current widths to the ini file
        /// </summary>
        public void ReadColumnSettings()
        {
            try
            {
                //GET COLUMN SETTINGS
                //Ini.AddSection("settings").AddKey("map_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnMap"].Width));
                if (!String.IsNullOrEmpty(Ini.GetKeyValue("settings", "map_col_width")))
                {
                    dataGridView1.Columns["ColumnMap"].Width = Convert.ToInt32(Ini.GetKeyValue("settings", "map_col_width"));
                }
                else
                    Ini.AddSection("settings").AddKey("map_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnMap"].Width));
                //Ini.AddSection("settings").AddKey("name_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnName"].Width));
                if (!String.IsNullOrEmpty(Ini.GetKeyValue("settings", "name_col_width")))
                {
                    dataGridView1.Columns["ColumnName"].Width = Convert.ToInt32(Ini.GetKeyValue("settings", "name_col_width"));
                }
                else
                    Ini.AddSection("settings").AddKey("name_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnName"].Width));
                //Ini.AddSection("settings").AddKey("lastbackup_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnLastBackup"].Width));
                if (!String.IsNullOrEmpty(Ini.GetKeyValue("settings", "lastbackup_col_width")))
                {
                    dataGridView1.Columns["ColumnLastBackup"].Width = Convert.ToInt32(Ini.GetKeyValue("settings", "lastbackup_col_width"));
                }
                else
                    Ini.AddSection("settings").AddKey("lastbackup_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnLastBackup"].Width));
                //Ini.AddSection("settings").AddKey("filename_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnFilename"].Width));
                if (!String.IsNullOrEmpty(Ini.GetKeyValue("settings", "filename_col_width")))
                {
                    dataGridView1.Columns["ColumnFilename"].Width = Convert.ToInt32(Ini.GetKeyValue("settings", "filename_col_width"));
                }
                else
                    Ini.AddSection("settings").AddKey("filename_col_width").SetValue(Convert.ToString(dataGridView1.Columns["ColumnFilename"].Width));

                Ini.Save(Common.ConfigIniFile);

            }
            catch (Exception ex)
            {
                Log("ReadColumnSettings" + ex.Message);
            }
        }

        private String BrowseTo(string[] filetype, string default_path)
        {
            String path = "";
            String filesfilterstring = "";

            OpenFileDialog ofd = new OpenFileDialog();

            foreach (string extension in filetype)
            {
                filesfilterstring += "(*." + extension + ")|*." + extension + "|";
            }

            String prettyprint = "Common Files|";
            foreach (string item in filetype)
            {
                prettyprint += "*." + item + ";";
            }
            prettyprint = prettyprint.Remove(prettyprint.Length - 1);//remove the last ';'

            ofd.Filter = prettyprint + "|All files (*.*)|*.*";
            ofd.InitialDirectory = default_path;//System.Windows.Forms.Application.StartupPath;
            ofd.ShowDialog();
            try
            {
                //Make sure user didn't cancel
                if (ofd.FileName != string.Empty)
                {
                    path = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return path;
        }

        private String BrowseTo(string filetype, string default_path)
        {
            String path = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filetype + " files (*." + filetype + ")|*." + filetype + "|All files (*.*)|*.*";
            ofd.InitialDirectory = default_path;//System.Windows.Forms.Application.StartupPath;
            ofd.ShowDialog();
            try
            {
                //Make sure user didn't cancel
                if (ofd.FileName != string.Empty)
                {
                    path = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return path;
        }

        private String BrowseToFolder(string default_path)
        {
            String path = "";
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.SelectedPath = default_path;
                // Show the FolderBrowserDialog.
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    path = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return path;
        }

        private String BrowseToFolder(Environment.SpecialFolder default_path)
        {
            String path = "";
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.RootFolder = default_path;
                // Show the FolderBrowserDialog.
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    path = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return path;
        }

        private string FindLastBackup(string WorldName, out FileInfo theFile)
        {
            theFile = null;
            string str_DateTime = "";
            try
            {
                //look in the current archive folder for all the filenames that begin with this world
                FileInfo YoungestFile = null;
                if (Directory.Exists(Ini.GetKeyValue("settings", "backup_loc")))
                {
                    foreach (string file in Directory.GetFiles(Ini.GetKeyValue("settings", "backup_loc")))
                    {
                        FileInfo curFile = new FileInfo(file);
                        if (curFile.Name.StartsWith(WorldName))
                        {
                            //we found a world that matches search; if younest is null then this search is the youngest
                            if (YoungestFile == null)
                            {
                                YoungestFile = curFile;
                                str_DateTime = YoungestFile.CreationTime.ToString("MM/dd/yyyy HH:mm");
                                theFile = YoungestFile;
                            }
                            else
                            {
                                if (curFile.CreationTime > YoungestFile.CreationTime)
                                {
                                    YoungestFile = curFile;
                                    str_DateTime = YoungestFile.CreationTime.ToString("MM/dd/yyyy HH:mm");
                                    theFile = YoungestFile;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please define a backup location in the settings.");
                    btnBrowse_Click(null, null);
                    //Close();
                }
                //what is that latest?
            }
            catch (Exception ex)
            {
                Log("ERROR FindLastBackup(): " + ex.Message);
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return str_DateTime;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                String pa_saves_path = BrowseToFolder(Environment.SpecialFolder.UserProfile);
                if (!String.IsNullOrEmpty(pa_saves_path))
                {
                    txtbBackup_loc.Text = pa_saves_path;
                    Ini.SetKeyValue("settings", "backup_loc", pa_saves_path);
                    Ini.Save(Common.ConfigIniFile);
                    bSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Log("btnBrowse_Click: " + ex.Message);
            }
        }

        private void openSavesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(savedDir.FullName);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openBackupFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Ini.GetKeyValue("settings", "backup_loc"));
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenRenderingForSelected()
        {
            //lets try to open the rendering
            string filetoopen = dataGridView1.CurrentRow.Cells["ColumnFilename"].Value.ToString().Replace(".prison", ".png");
            try
            {
                if (File.Exists(filetoopen))
                    System.Diagnostics.Process.Start(filetoopen);
                else
                    MessageBox.Show(filetoopen + "\r\nFile not found. Run mcmapGUI2 for this map.", "Map not Rendered by mcmap", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenRenderingForSelected(String filetoopen)
        {
            //lets try to open the rendering
            try
            {
                if (File.Exists(filetoopen))
                    System.Diagnostics.Process.Start(filetoopen);
                else
                    MessageBox.Show(filetoopen + "\r\nFile not found. ", "Image not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenRenderingForSelected();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                //if (this.WindowState == FormWindowState.Normal)
                //{
                //    // Console.WriteLine("FormWindowState.Normal");
                //    col.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 12.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //dataGridView1.RowTemplate.Heigh
                //}
                //if (this.WindowState == FormWindowState.Maximized)
                //{
                //    // Console.WriteLine("FormWindowState.Maximized");
                //    col.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    // dataGridView1.RowTemplate.Height = 129;
                //}
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    row.Cells["ColumnMap"].Value = ((Bitmap)row.Cells["ColumnMap"].Value).GetThumbnailImage(32, 32, null, IntPtr.Zero);
                }
                if (this.WindowState == FormWindowState.Maximized)
                {
                    row.Cells["ColumnMap"].Value = ((Bitmap)row.Cells["ColumnMap"].Value).GetThumbnailImage(64, 64, null, IntPtr.Zero);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //unlock any images
                //Save Column widths
                Ini.Load(Common.ConfigIniFile);
                Ini.SetKeyValue("settings", "map_col_width", Convert.ToString(dataGridView1.Columns["ColumnMap"].Width));
                Ini.SetKeyValue("settings", "name_col_width", Convert.ToString(dataGridView1.Columns["ColumnName"].Width));
                Ini.SetKeyValue("settings", "lastbackup_col_width", Convert.ToString(dataGridView1.Columns["ColumnLastBackup"].Width));
                Ini.SetKeyValue("settings", "filename_col_width", Convert.ToString(dataGridView1.Columns["ColumnFilename"].Width));
                switch (cbthumbsize.SelectedIndex)
                {
                    case 0:
                        Ini.GetSection("settings").AddKey("thumbsize").SetValue("32x32");
                        break;
                    case 1:
                        Ini.GetSection("settings").AddKey("thumbsize").SetValue("64x64");
                        break;
                    case 2:
                        Ini.GetSection("settings").AddKey("thumbsize").SetValue("128x128");
                        break;
                    default:
                        break;
                }
                Ini.Save(Common.ConfigIniFile);

                TempCleanUp();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void dataGridViewBackups_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                #region If RIGHT-CLICK...
                //If RIGHT-CLICK...
                if (e.Button == MouseButtons.Right)
                {
                    this.ContextMenuStrip = contextMenuStrip2;
                    //}
                }
                #endregion If RIGHT-CLICK...

                statusStrip1.Items.Clear();

                Point grvScreenLocation = dataGridViewBackups.PointToScreen(dataGridViewBackups.Location);
                int tempX = DataGridView.MousePosition.X - grvScreenLocation.X + dataGridViewBackups.Left;
                int tempY = DataGridView.MousePosition.Y - grvScreenLocation.Y + dataGridViewBackups.Top;
                DataGridView.HitTestInfo hit = dataGridViewBackups.HitTest(tempX, tempY);
                if (hit != null && hit.RowIndex >= 0)
                {
                    dataGridViewBackups.Rows[hit.RowIndex].Selected = true;
                    DataGridView Grid = (DataGridView)sender;
                    string PrisonName = Grid.SelectedRows[0].Cells[1].Value.ToString();
                    string Prisonfullname = Grid.SelectedRows[0].Cells[3].Value.ToString();
                    statusStrip1.Items.Add(PrisonName + GetPrisonStats(Prisonfullname));
                    statusStrip1.Update();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("dataGridViewBackups_MouseDown ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //Copy the node selected...
                //selectedTreeNode = (TreeNode)(treeView1.GetNodeAt(e.X, e.Y).Clone());
                #region If RIGHT-CLICK...
                //If RIGHT-CLICK...
                if (e.Button == MouseButtons.Right)
                {
                    //if (listBoxBackups.SelectedIndex >= 0)
                    //{
                    //now show RIGHTCLICK MENU...
                    ////Let's update purgekeepXDaysForYToolStripMenuItem.Text FIRST!
                    ////get the first part of the text
                    //int iForIndex = purgekeepXDaysForYToolStripMenuItem.Text.IndexOf("for ") + 4;
                    //string prefix = purgekeepXDaysForYToolStripMenuItem.Text.Substring(0, iForIndex);
                    //purgekeepXDaysForYToolStripMenuItem.Text = prefix + ((FileInfo)listBoxBackups.SelectedItem).Name.Split('_')[0];

                    ////Let's update sendCopyToCloudStorageToolStripMenuItem.Text FIRST!
                    //if (String.IsNullOrWhiteSpace(Ini.GetKeyValue("settings", "cloud_backup_loc")))
                    //    sendCopyToCloudStorageToolStripMenuItem.Enabled = false;
                    //else
                    //    sendCopyToCloudStorageToolStripMenuItem.Enabled = true;
                    //UpdateExploreCloudBackupMenuItem();
                    string PrisonName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    backupAsGroupABCToolStripMenuItem.Text = "Backup All Files StartsWith '" + PrisonName + "' as Group";
                    backupAsGroupABCAndRemoveToolStripMenuItem.Text = "Backup All Files StartsWith '" + PrisonName + "' as Group and Remove";
                    this.ContextMenuStrip = contextMenuStrip1;
                    //}
                }
                #endregion If RIGHT-CLICK...
                if (e.Button != MouseButtons.Right)
                {
                    //we must select this row!
                    Point grvScreenLocation = dataGridView1.PointToScreen(dataGridView1.Location);
                    int tempX = DataGridView.MousePosition.X - grvScreenLocation.X + dataGridView1.Left;
                    int tempY = DataGridView.MousePosition.Y - grvScreenLocation.Y + dataGridView1.Top;
                    DataGridView.HitTestInfo hit = dataGridView1.HitTest(tempX, tempY);
                    if (hit != null && hit.RowIndex >= 0)
                    {
                        dataGridView1.Rows[hit.RowIndex].Selected = true;
                    }

                    statusStrip1.Items.Clear();
                    DataGridView Grid = (DataGridView)sender;
                    string PrisonName = Grid.SelectedRows[0].Cells[1].Value.ToString();
                    string Prisonfullname = Grid.SelectedRows[0].Cells[3].Value.ToString();
                    statusStrip1.Items.Add(PrisonName + GetPrisonStats(Prisonfullname));
                    statusStrip1.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("dataGridView1_MouseDown ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbthumbsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            bSave.Enabled = true;
        }

        /// <summary>
        /// Creates a zip file with only that world
        /// </summary>
        /// <param name="fullfilename"></param>
        /// <param name="fileList"></param>
        /// <returns></returns>
        private bool CreateBackupGroupFile(String fullfilename, List<FileInfo> prisonFilesList, bool verbose)
        {
            FileInfo MAINFILE = new FileInfo(fullfilename);
            string tempgroupfolder = Common.TEMPDIR + "\\" + MAINFILE.Name.Replace(".zip", "");
            Directory.CreateDirectory(tempgroupfolder);
            DirectoryInfo TEMPFOLDER = new DirectoryInfo(tempgroupfolder);
            CleanUpDirs.Add(new DirectoryInfo(tempgroupfolder));
            bool bCreated = false;
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    //zip.AddDirectory(newFile.DirectoryName, "");
                    foreach (FileInfo prisonfile in prisonFilesList)
                    {
                        File.Copy(prisonfile.FullName, (TEMPFOLDER.FullName + "\\" + prisonfile.Name));
                    }

                    zip.AddDirectory(tempgroupfolder, "");

                    // do the progress bar:
                    zip.SaveProgress += (sender, e) =>
                    {
                        if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
                        {
                            progressBar1.PerformStep();
                        }
                    };
                    progressBar1 = new ProgressBar();
                    progressBar1.Update();

                    zip.Save(fullfilename);
                    zip.Dispose();
                }
                System.Threading.Thread.Sleep(100);
                bCreated = true;
            }
            catch (Exception ex)
            {
                Log("CreateBackupGroupFile: " + ex.Message);
                Log(ex.StackTrace);
            }

            return bCreated;
        }

        private bool CreateBackupFile(String fullfilename, string prisonName, bool verbose)
        {
            bool bCreated = false;
            try
            {
                FileInfo newFile = new FileInfo(prisonName);
                using (ZipFile zip = new ZipFile())
                {
                    //zip.AddDirectory(newFile.DirectoryName, "");
                    zip.AddFile(savedDir.FullName + "\\" + prisonName + ".png", "");
                    if (verbose)
                        Log("     CreateBackupFile: Added File: " + savedDir.FullName + "\\" + prisonName + ".png");
                    zip.AddFile(savedDir.FullName + "\\" + prisonName + ".prison", "");
                    if (verbose)
                        Log("     CreateBackupFile: Added File: " + savedDir.FullName + "\\" + prisonName + ".prison");
                    zip.Save(fullfilename);
                    zip.Dispose();
                }
                System.Threading.Thread.Sleep(100);
                bCreated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateBackupFile: " + ex.Message);
            }

            return bCreated;
        }

        /// <summary>
        /// Nice little MessageBox.Show
        /// </summary>
        /// <param name="whatdone"></param>
        private void ShowMsgBoxGenericCompleted(String whatdone)
        {
            MessageBox.Show(whatdone + " Completed!", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Get a Prison name back from a FullName file
        /// eg. C:\Users\Joe\Dropbox\prisonarchitect\saves\HollywoodPen--_01312015104700.zip
        /// returns HollywoodPen--
        /// </summary>
        /// <param name="fName">File.FullName</param>
        /// <returns></returns>
        private String ExtractPrisonNameFromFullName(string fName)
        {
            String PRISONNAME = "";
            int iLastUnderscore = fName.LastIndexOf('_');
            int iLastHyphen = fName.LastIndexOf('\\');
            if (iLastUnderscore != -1 && iLastHyphen != -1)
                PRISONNAME = fName.Substring((iLastHyphen + 1), ((iLastUnderscore - 1) - iLastHyphen));
            return PRISONNAME;
        }

        /// <summary>
        /// Populates and re-populates the dataGridView1.Rows
        /// list each saved World and then match a rendered image
        /// </summary>
        private void LoadSavedWorlds()
        {
            Cursor.Current = Cursors.WaitCursor;
            Log("LoadSavedWorlds: STARTING...");
            //  dataGridView1.BeginUpdate();
            dataGridView1.Rows.Clear();
            ImageListWorlds.Images.Clear();
            dataGridView1.Update();
            //the settings should be ok...
            savedDir = new DirectoryInfo(Common.savesDir);
            List<FileInfo> FileEntries = new List<FileInfo>();
            if (Directory.Exists(Ini.GetKeyValue("settings", "pa_saves")))
            {
                savedDir = new DirectoryInfo(Ini.GetKeyValue("settings", "pa_saves"));
            }

            if (Directory.Exists(savedDir.FullName))
            {
                //foreach rendered world, get one image at location 
                // "\\Introversion\\Prison Architect\\saves" etc
                foreach (FileInfo item in savedDir.GetFiles())
                {
                    if (item.Extension.ToLower().EndsWith("png"))
                    {
                        FileEntries.Add(item);
                        Image img = Image.FromFile(item.FullName);
                        img.Tag = item.Name;
                        //@@@ IMAGES STORED HERE @@@
                        ImageListWorlds.Images.Add(item.Name, (Image)img.Clone());
                        img.Dispose();
                    }
                }
                //let's get the largest sizes
                int larget_height = 128;//start out with our default size
                int larget_width = 128;
                ImageListWorlds.ImageSize = new Size(larget_width, larget_height);
                if (Directory.Exists(savedDir.FullName))
                {
                    //Now list each saved World and then match a rendered image
                    if (FileEntries.Count > 0)
                    {
                        int i = 0;
                        foreach (FileInfo world in FileEntries)
                        {
                            switch (Ini.GetKeyValue("settings", "thumbsize"))
                            {
                                case "128x128":
                                    dataGridView1.Rows.Add(ImageListWorlds.Images[i].GetThumbnailImage(128, 128, null, IntPtr.Zero).Clone(), world.Name.Replace(".png", ""), world.LastWriteTime, world.FullName.Replace(".png", ".prison"));
                                    break;
                                case "64x64":
                                    dataGridView1.Rows.Add(ImageListWorlds.Images[i].GetThumbnailImage(64, 64, null, IntPtr.Zero).Clone(), world.Name.Replace(".png", ""), world.LastWriteTime, world.FullName.Replace(".png", ".prison"));
                                    break;
                                case "32x32":
                                    dataGridView1.Rows.Add(ImageListWorlds.Images[i].GetThumbnailImage(32, 32, null, IntPtr.Zero).Clone(), world.Name.Replace(".png", ""), world.LastWriteTime, world.FullName.Replace(".png", ".prison"));
                                    break;
                                default:
                                    break;
                            }
                            //lets add the file path to Tag for later use
                            dataGridView1.CurrentRow.Tag = world.FullName.Clone();
                            i = i + 1;
                            // }
                        }
                    }
                }
                else
                {
                    //guess there is no \saved folder yet, which is A O K
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    //dataGridView1.Columns["ColumnLastBackup"].ValueType = typeof(DateTime);
                    //dataGridView1.Columns["ColumnLastBackup"].DefaultCellStyle.Format = "MMddyyyyHHmmss";
                    dataGridView1.Sort(dataGridView1.Columns["ColumnLastBackup"], ListSortDirection.Descending);
                }
                //Get the Column settings
                ReadColumnSettings();
                // dataGridView1.EndUpdate();
                dataGridView1.Update();
            }
            else
            {
                Log("ERROR: No Prison Architect saves folder defined.");
            }
            Log("LoadSavedWorlds: COMPLETED");
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Populates and re-populates the dataGridViewBackups.Rows
        /// list each backed up prison and then match a rendered image
        /// </summary>
        private void LoadBackedUpPrisons()
        {
            Cursor.Current = Cursors.WaitCursor;
            //  dataGridViewBackups.BeginUpdate();
            Log("LoadBackedUpPrisons: STARTING...");
            dataGridViewBackups.Rows.Clear();
            ImageListWorlds.Images.Clear();
            dataGridViewBackups.Update();
            //the settings should be ok...
            String BACKUPDIR = Ini.GetKeyValue("settings", "backup_loc");
            List<FileInfo> FileEntries = new List<FileInfo>();

            if (Directory.Exists(BACKUPDIR))
            {
                backedupDir = new DirectoryInfo(BACKUPDIR);
            }

            if (backedupDir != null)
            {
                if (Directory.Exists(backedupDir.FullName))
                {
                    //foreach rendered world, get one image at location 
                    // "C:\\Users\\Me\\Dropbox\\prisonarchitect\\saves" etc
                    CleanUpDirs.Add(new DirectoryInfo(Common.TEMPDIR));
                    foreach (FileInfo item in backedupDir.GetFiles())
                    {
                        if (item.Extension.ToLower().EndsWith("zip") && (!item.Name.Contains("-GROUP")))
                        {
                            String PrisonName = ExtractPrisonNameFromFullName(item.FullName);
                            FileEntries.Add(item);
                            using (ZipFile zip = ZipFile.Read(item.FullName))
                            {
                                //find the prisonname.png and place into temp storage
                                foreach (ZipEntry entry in zip)
                                {
                                    if (entry.FileName == PrisonName + ".png")
                                    {
                                        String tempFullName = Common.TEMPDIR + "\\" + item.Name.Replace(".zip", ".png");
                                        if (!File.Exists(tempFullName))
                                        {
                                            Log("     LoadBackedUpPrisons: Extracting temp to " + tempFullName);
                                            entry.FileName = item.Name.Replace(".zip", ".png");
                                            if (!Directory.Exists(Common.TEMPDIR))
                                                Directory.CreateDirectory(Common.TEMPDIR);
                                            entry.Extract(Common.TEMPDIR, ExtractExistingFileAction.DoNotOverwrite);
                                        }
                                        Image img = Image.FromFile(tempFullName);
                                        img.Tag = item.Name;
                                        //@@@ IMAGES STORED HERE @@@
                                        ImageListWorlds.Images.Add(item.Name, (Image)img.Clone());
                                        img.Dispose();
                                        System.Threading.Thread.Sleep(100);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    //let's get the largest sizes
                    int larget_height = 128;//start out with our default size
                    int larget_width = 128;
                    ImageListWorlds.ImageSize = new Size(larget_width, larget_height);
                    if (Directory.Exists(backedupDir.FullName))
                    {
                        //Now list each backedup Prison and then match a rendered image
                        if (FileEntries.Count > 0)
                        {
                            int i = 0;
                            foreach (FileInfo prison in FileEntries)
                            {

                                switch (Ini.GetKeyValue("settings", "thumbsize"))
                                {
                                    case "128x128":
                                        dataGridViewBackups.Rows.Add(ImageListWorlds.Images[i].GetThumbnailImage(128, 128, null, IntPtr.Zero).Clone(), prison.Name.Replace(".png", "").Clone(), prison.LastWriteTime.ToString(), prison.FullName.Clone());
                                        break;
                                    case "64x64":
                                        dataGridViewBackups.Rows.Add(ImageListWorlds.Images[i].GetThumbnailImage(64, 64, null, IntPtr.Zero).Clone(), prison.Name.Replace(".png", "").Clone(), prison.LastWriteTime.ToString(), prison.FullName.Clone());
                                        break;
                                    case "32x32":
                                        dataGridViewBackups.Rows.Add(ImageListWorlds.Images[i].GetThumbnailImage(32, 32, null, IntPtr.Zero).Clone(), prison.Name.Replace(".png", "").Clone(), prison.LastWriteTime.ToString(), prison.FullName.Clone());
                                        break;
                                    default:
                                        break;
                                }
                                //lets add the file path to Tag for later use
                                dataGridViewBackups.CurrentRow.Tag = prison.FullName.Clone();
                                i = i + 1;
                                // }
                            }
                        }
                    }
                    else
                    {
                        //guess there is no \saved folder yet, which is A O K
                    }
                }

                if (dataGridViewBackups.Rows.Count > 0)
                {
                    //dataGridViewBackups.Columns["ColumnLastBackup"].ValueType = typeof(DateTime);
                    //dataGridViewBackups.Columns["ColumnLastBackup"].DefaultCellStyle.Format = "MMddyyyyHHmmss";
                    dataGridViewBackups.Sort(dataGridViewBackups.Columns[2], ListSortDirection.Descending);
                }
                //Get the Column settings
                ReadColumnSettings();
                // dataGridViewBackups.EndUpdate();
                dataGridViewBackups.Update();
                Log("LoadBackedUpPrisons: COMPLETED");
            }
            else
            {
                Log("ERROR: No Prison Architect saves folder defined.");
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Backs-up selected row Prison
        /// </summary>
        /// <param name="bRemove">Set true if you wish to remove the prison from active saves folder</param>
        private void DoBackup(bool bRemove)
        {
            Cursor.Current = Cursors.WaitCursor;
            Log("DoBackup(" + Convert.ToString(bRemove) + "): STARTING...");
            string PrisonName = "";
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                PrisonName = item.Cells["ColumnName"].Value.ToString();
                string uniqueFilename = item.Cells["ColumnName"].Value.ToString() + "_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".zip";
                Log("DoBackup(): " + Ini.GetKeyValue("settings", "backup_loc") + "\\" + uniqueFilename);
                CreateBackupFile(Ini.GetKeyValue("settings", "backup_loc") + "\\" + uniqueFilename, item.Cells["ColumnName"].Value.ToString(), true);
                if(bRemove)
                {
                    string prisonFile = Common.savesDir + "\\" + PrisonName + ".prison";
                    string prisonPNG = Common.savesDir + "\\" + PrisonName + ".png";
                    if(File.Exists(prisonFile))
                    {
                        FileSystem.DeleteFile(prisonFile, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        Log("DoBackup(): DeleteFile: " + prisonFile);
                    }
                    if (File.Exists(prisonPNG))
                    {
                        FileSystem.DeleteFile(prisonPNG, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        Log("DoBackup(): DeleteFile: " + prisonPNG);
                    }

                    LoadSavedWorlds();
                }
                break;
            }
            //Now reload the listview
            //LoadSavedWorlds();
            Cursor.Current = Cursors.Default;
            Log("DoBackup(" + Convert.ToString(bRemove) + "): Prison '" + PrisonName + " 'COMPLETED");
            ShowMsgBoxGenericCompleted("Backup of " + PrisonName);
        }

        /// <summary>
        /// Deletes Directories in CleanUpDirs List,
        /// if they exist. If empty, deletes Common.TEMPDIR
        /// </summary>
        private void TempCleanUp()
        {
            //Temp cleanup
            if (CleanUpDirs.Count > 0)
            {
                foreach (DirectoryInfo dir in CleanUpDirs)
                {
                    //just make sure it exists because CleanUpDirs might have some duplicates
                    if (Directory.Exists(dir.FullName))
                    {
                        Log("TempCleanUp; Cleaning up..deleting " + dir.FullName);
                        dir.Delete(true);
                    }
                }
            }
            else
            {
                //We know there is at least the default temp folder
                DirectoryInfo dir = new DirectoryInfo(Common.TEMPDIR);
                if (Directory.Exists(dir.FullName))
                {
                    Log("TempCleanUp; Cleaning up..deleting " + dir.FullName);
                    dir.Delete(true);
                }
            }
        }

        private void backupRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dResult = MessageBox.Show("Are your sure you wish to remove this prison from your current saves folder?", "Archive this prison?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DoBackup(true);
                    Cursor.Current = Cursors.Default;
                }
                else if (dResult == DialogResult.No)
                {
                    
                }
                else if (dResult == DialogResult.Cancel)
                {

                }
            }
            catch (Exception ex)
            {
                Log("backupRemoveToolStripMenuItem_Click: " + ex.Message);
            }
        }

        private void restoreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string PrisonName = dataGridViewBackups.SelectedRows[0].Cells[1].Value.ToString();
                ZipFile backupZip = new ZipFile(dataGridViewBackups.SelectedRows[0].Cells[3].Value.ToString());
                backupZip.ExtractAll(Common.savesDir, ExtractExistingFileAction.OverwriteSilently);
                ShowMsgBoxGenericCompleted(PrisonName + " restored");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Log("restoreToolStripMenuItem_Click: " + ex.Message);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string PrisonName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dResult = MessageBox.Show("Are your sure you wish to delete this prison [" + PrisonName + "] from your current saves folder?", "Delete this Prison?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string prisonFile = Common.savesDir + "\\" + PrisonName + ".prison";
                    string prisonPNG = Common.savesDir + "\\" + PrisonName + ".png";
                    if (File.Exists(prisonFile))
                    {
                        FileSystem.DeleteFile(prisonFile, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        Log("deleteToolStripMenuItem_Click(): DeleteFile: " + prisonFile);
                    }
                    if (File.Exists(prisonPNG))
                    {
                        FileSystem.DeleteFile(prisonPNG, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        Log("deleteToolStripMenuItem_Click(): DeleteFile: " + prisonPNG);
                    }
                    ShowMsgBoxGenericCompleted(PrisonName + " deleted");
                    LoadSavedWorlds();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Log("deleteToolStripMenuItem_Click: " + ex.Message);
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string PrisonName = ExtractPrisonNameFromFullName(dataGridViewBackups.SelectedRows[0].Cells[1].Value.ToString());
                DialogResult dResult = MessageBox.Show("Are your sure you wish to delete this backup [" + PrisonName + "] from your current backup folder?", "Delete this backup?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FileInfo BackupFile = new FileInfo(dataGridViewBackups.SelectedRows[0].Cells[3].Value.ToString());
                    if (File.Exists(BackupFile.FullName))
                    {
                        FileSystem.DeleteFile(BackupFile.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        Log("deleteToolStripMenuItem_Click(): DeleteFile: " + BackupFile.FullName);
                    }
                    ShowMsgBoxGenericCompleted(PrisonName + " deleted");
                    LoadBackedUpPrisons();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Log("deleteToolStripMenuItem1_Click: " + ex.Message);
            }
        }

        private void backupAsGroupABCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string PrisonName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dResult = MessageBox.Show("Are your sure you wish to create a backup group?", "Create backup group?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //iterate through all files that start with the most amount 
                    List<FileInfo> GroupedFilesList = new List<FileInfo>();
                    int max = dataGridView1.Rows.Count;
                    for (int i = 0; i < max; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString().StartsWith(PrisonName))
                        {
                            //Need to add both the image and the .prison file for a full backup.
                            GroupedFilesList.Add(new FileInfo(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                            GroupedFilesList.Add(new FileInfo(dataGridView1.Rows[i].Cells[3].Value.ToString().Replace(".png",".prison")));
                        }
                    }
                    CreateBackupGroupFile(Ini.GetKeyValue("settings", "backup_loc") + "\\" + PrisonName + "-GROUP.zip", GroupedFilesList, true);
                    ShowMsgBoxGenericCompleted(PrisonName + " Group Created!");
                    LoadSavedWorlds();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Log("backupAsGroupABCToolStripMenuItem_Click: " + ex.Message);
            }
        }

        private void backupAsGroupABCAndRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string PrisonName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dResult = MessageBox.Show("Are your sure you wish to create a backup group and remove prisons?", "Create backup group and remove prisons?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //iterate through all files that start with the most amount 
                    List<FileInfo> GroupedFilesList = new List<FileInfo>();
                    int max = dataGridView1.Rows.Count;
                    for (int i = 0; i < max; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString().StartsWith(PrisonName))
                        {
                            //Need to add both the image and the .prison file for a full backup.
                            GroupedFilesList.Add(new FileInfo(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                            GroupedFilesList.Add(new FileInfo(dataGridView1.Rows[i].Cells[3].Value.ToString().Replace(".png", ".prison")));
                        }
                    }
                    CreateBackupGroupFile(Ini.GetKeyValue("settings", "backup_loc") + "\\" + PrisonName + "-GROUP.zip", GroupedFilesList, true);

                    foreach (FileInfo f in GroupedFilesList)
                    {
                        if (File.Exists(f.FullName))
                        {
                            FileSystem.DeleteFile(f.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            Log("backupAsGroupABCAndRemoveToolStripMenuItem_Click(): DeleteFile: " + f.FullName);
                        }
                    }

                    ShowMsgBoxGenericCompleted(PrisonName + " Group Created and prisons removed!");
                    LoadSavedWorlds();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Log("backupAsGroupABCAndRemoveToolStripMenuItem_Click: " + ex.Message);
            }
        }

        private void btnRestoreAllGroup_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string GroupPrisonName = comboBoxGroups.SelectedItem.ToString();
                ZipFile backupZip = new ZipFile(Ini.GetKeyValue("settings", "backup_loc") + "\\" + GroupPrisonName + "-GROUP.zip");
                backupZip.ExtractAll(Common.savesDir);
                ShowMsgBoxGenericCompleted(GroupPrisonName + "Group restored");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Log("btnRestoreAllGroup_Click: " + ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //need to reset this or it right-clicks everywhere with wrong contextmenu
            this.ContextMenuStrip = null;
            string backup_loc = Ini.GetKeyValue("settings", "backup_loc");

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabAllSaves"])
            {
                LoadSavedWorlds();
                tabControl1.SelectedTab.Focus();
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabSavedGroup"])
            {
                comboBoxGroups.Items.Clear();
                if (!String.IsNullOrWhiteSpace(backup_loc))
                {
                    DirectoryInfo BackupDir = new DirectoryInfo(backup_loc);
                    //Display each currently found Groups zip
                    foreach (FileInfo file in BackupDir.GetFiles())
                    {
                        if (file.Name.Contains("-GROUP"))
                            comboBoxGroups.Items.Add(file.Name.Replace("-GROUP.zip", ""));
                    }
                    if (comboBoxGroups.Items.Count > 0)
                        comboBoxGroups.SelectedIndex = 0;
                    //Since one is selected, display its contents in dataGridViewGroups
                    LoadSelectedGroupPrisons();
                }
                else { MessageBox.Show("Please define a backup location in the settings."); }
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabBackups"])
            {
                if (!String.IsNullOrWhiteSpace(backup_loc))
                {
                    LoadBackedUpPrisons();
                }
                else { MessageBox.Show("Please define a backup location in the settings."); }
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabSettings"])
            {
                if (Directory.Exists(Common.TEMPDIR))
                {
                    btnCleanup.Enabled = true;
                }
                else
                    btnCleanup.Enabled = false;
                tabControl1.SelectedTab.Focus();
                this.Update();
            }
        }

        private void btnCleanup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dResult = MessageBox.Show("Are your sure you wish to delete the temporary folder?", "Delete the temporary folder?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Log("btnCleanup_Click clicked...");
                    TempCleanUp();
                    if (!Directory.Exists(Common.TEMPDIR))
                    {
                        btnCleanup.Enabled = false;
                    }
                    Cursor.Current = Cursors.Default;
                }
                else if (dResult == DialogResult.No)
                {

                }
                else if (dResult == DialogResult.Cancel)
                {

                }
            }
            catch (Exception ex)
            {
                Log("btnCleanup_Click: " + ex.Message);
            }
        }

        private void comboBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedGroupPrisons();
            }
            catch (Exception ex)
            {
                Log("comboBoxGroups_SelectedIndexChanged: " + ex.Message);
            }
        }

        private void LoadSelectedGroupPrisons()
        {
            Cursor.Current = Cursors.WaitCursor;
            //  dataGridViewGroups.BeginUpdate();
            Log("LoadSelectedGroupPrisons: STARTING...");
            dataGridViewGroups.Rows.Clear();
            ImageListWorlds.Images.Clear();
            dataGridViewGroups.Update();
            //the settings should be ok...
            String BACKUPDIR = Ini.GetKeyValue("settings", "backup_loc");
            List<ZipEntry> ZipFileEntries = new List<ZipEntry>();

            string FULLGRPFILENAME = BACKUPDIR + "\\" + comboBoxGroups.Items[comboBoxGroups.SelectedIndex].ToString() + "-GROUP.zip";
            FileInfo backedupGRP = new FileInfo(FULLGRPFILENAME);
            String backedupGRPName = backedupGRP.Name.Substring(0, (backedupGRP.Name.LastIndexOf('.')));
            String tempDIR = Common.TEMPDIR + "\\" + backedupGRPName;

            if (File.Exists(backedupGRP.FullName))
            {
                //Extract the GROUP file into temp location so to read it
                //foreach rendered world, get one image at location 
                // "C:\\Users\\Me\\Dropbox\\prisonarchitect\\saves" etc
                CleanUpDirs.Add(new DirectoryInfo(Common.TEMPDIR));

                using (ZipFile zip = ZipFile.Read(backedupGRP.FullName))
                {
                    //find the prisonname.png and place into temp storage
                    foreach (ZipEntry entry in zip)
                    {
                        String pngFileName = entry.FileName.Replace(".zip", ".png");
                        String PrisonName = entry.FileName.Substring(0, (entry.FileName.LastIndexOf('.')));
                        
                        //If this really is a png file as the current entry then....
                        if (entry.FileName == PrisonName + ".png")
                        {
                            ZipFileEntries.Add(entry);
                            String tempFullName = tempDIR + "\\" + pngFileName;
                            if (!File.Exists(tempFullName))
                            {
                                Log("     LoadSelectedGroupPrisons: Extracting temp to " + tempFullName);
                                entry.Extract(tempDIR, ExtractExistingFileAction.DoNotOverwrite);
                            }
                            Image img = Image.FromFile(tempFullName);
                            img.Tag = entry.FileName;
                            //@@@ IMAGES STORED HERE @@@
                            ImageListWorlds.Images.Add(entry.FileName, (Image)img.Clone());
                            img.Dispose();
                            //break;
                        }
                        else
                        {
                            ////must be .prison file so let's extract it in temp
                            //String tempFullName = tempDIR + "\\" + entry.FileName;
                            //if (!File.Exists(tempFullName))
                            //{
                            //    Log("     LoadSelectedGroupPrisons: Extracting temp to " + tempFullName);
                            //    entry.Extract(tempDIR, ExtractExistingFileAction.DoNotOverwrite);
                            //}
                        }
                    }

                }

                //let's get the largest sizes
                int larget_height = 128;//start out with our default size
                int larget_width = 128;
                ImageListWorlds.ImageSize = new Size(larget_width, larget_height);
                if (Directory.Exists(tempDIR))
                {
                    //Now list each Prison extracted and then match a rendered image
                    if (ZipFileEntries.Count > 0)
                    {
                        int i = 0;
                        foreach (ZipEntry prison in ZipFileEntries)
                        {
                            //get the actual zip entry timestamp
                            switch (Ini.GetKeyValue("settings", "thumbsize"))
                            {
                                case "128x128":
                                    dataGridViewGroups.Rows.Add(ImageListWorlds.Images[i].GetThumbnailImage(128, 128, null, IntPtr.Zero).Clone(), prison.FileName.Replace(".png", ""), prison.LastModified, prison.FileName.Replace(".png", ".prison"));
                                    break;
                                case "64x64":
                                    dataGridViewGroups.Rows.Add(ImageListWorlds.Images[i].GetThumbnailImage(64, 64, null, IntPtr.Zero).Clone(), prison.FileName.Replace(".png", ""), prison.LastModified, prison.FileName.Replace(".png", ".prison"));
                                    break;
                                case "32x32":
                                    dataGridViewGroups.Rows.Add(ImageListWorlds.Images[i].GetThumbnailImage(32, 32, null, IntPtr.Zero).Clone(), prison.FileName.Replace(".png", ""), prison.LastModified, prison.FileName.Replace(".png", ".prison"));
                                    break;
                                default:
                                    break;
                            }
                            //lets add the Group folder name to Tag for later use
                            dataGridViewGroups.CurrentRow.Tag = backedupGRPName.Clone();
                            i = i + 1;
                            // }
                        }
                    }
                }
                else
                {
                    //guess there is no \saved folder yet, which is A O K
                }

                if (dataGridViewGroups.Rows.Count > 0)
                {
                    //dataGridViewGroups.Columns["ColumnLastBackup"].ValueType = typeof(DateTime);
                    //dataGridViewGroups.Columns["ColumnLastBackup"].DefaultCellStyle.Format = "MMddyyyyHHmmss";
                    dataGridViewGroups.Sort(dataGridViewGroups.Columns[2], ListSortDirection.Descending);
                }
                //Get the Column settings
                ReadColumnSettings();
                // dataGridViewGroups.EndUpdate();
                dataGridViewGroups.Update();
                Log("LoadSelectedGroupPrisons: COMPLETED");
            }
            else
            {
                Log("ERROR: No Prison Architect saves folder defined.");
            }
            Cursor.Current = Cursors.Default;
        }

        private void dataGridViewGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView Grid = (DataGridView)sender;
            DataGridViewCellEventArgs cellargs = (DataGridViewCellEventArgs)e;
            String SETTINGNAME = Grid.Rows[cellargs.RowIndex].Cells[3].Value.ToString();
            //String SETTINGVALUE = Grid.Rows[cellargs.RowIndex].Cells["Value"].Value.ToString();
            String tempDIR = Common.TEMPDIR + "\\" + comboBoxGroups.SelectedItem.ToString() + "-GROUP\\" + SETTINGNAME.Replace(".prison", ".png");
            if (File.Exists(tempDIR))
                OpenRenderingForSelected(tempDIR);
            else
            {
                MessageBox.Show("Where the heck did\r\n" + tempDIR + "\r\nGo?!?! Restart program and try again.");
            }
        }

        //private String GetFinanceBalance(String financeLine)
        //{
        //    String s;
        //    if (financeLine.StartsWith("BEGIN Finance"))
        //    {
        //        s = financeLine.Substring(0, (financeLine.IndexOf("Balance ") + 8));
        //        s = s.Substring(0, (s.IndexOf(" ")));
        //    }
        //    else
        //    {
        //        s = "";
        //        Log("GetFinanceBalance: This line doesn't StartsWith(\"BEGIN Finance\")");
        //    }
        //    return s;
        //}

        /// <summary>
        /// Find a line the StartsWith in a StringCollection
        /// </summary>
        /// <param name="KEY"></param>
        /// <param name="sc"></param>
        /// <returns>Line</returns>
        private String FindLine(String KEY, StringCollection sc)
        {
            String line = "";
            foreach (string str in sc)
            {
                if(str.Trim().StartsWith(KEY))
                {
                    line = str;
                    break;
                }
            }
            return line;
        }

        /// <summary>
        /// Takes a zip file and extracts in Common.TEMPDIR with Guid.NewGuid() folder name
        /// </summary>
        /// <param name="ZipFullName"></param>
        /// <param name="all_png"></param>
        /// <param name="tempfolder"></param>
        /// <returns>Summary of files in the temp folder in String List</returns>
        private List<String> ExtractToTemp(string ZipFullName, bool all_png, out string tempfolder)
        {
            String tempDIR = Common.TEMPDIR + "\\" + Guid.NewGuid().ToString();
            tempfolder = tempDIR;
            List<String> TempZipFile = new List<String>();
            using (ZipFile zip = ZipFile.Read(ZipFullName))
            {
                //find the prisonname.png and place into temp storage
                foreach (ZipEntry entry in zip)
                {
                    String pngFileName = entry.FileName.Replace(".zip", ".png");
                    String PrisonName = entry.FileName.Substring(0, (entry.FileName.LastIndexOf('.')));

                    //If this really is a png file as the current entry then....
                    if (entry.FileName == PrisonName + ".png")
                    {
                        TempZipFile.Add(entry.FileName);
                        String tempFullName = tempDIR + "\\" + pngFileName;
                        if (!File.Exists(tempFullName))
                        {
                            Log("     LoadSelectedGroupPrisons: Extracting temp to " + tempFullName);
                            entry.Extract(tempDIR, ExtractExistingFileAction.DoNotOverwrite);
                        }
                    }
                    else
                    {
                        ////must be .prison file so let's extract it in temp
                        if (all_png)
                        {
                            String tempFullName = tempDIR + "\\" + entry.FileName;
                            TempZipFile.Add(entry.FileName);
                            if (!File.Exists(tempFullName))
                            {
                                Log("     LoadSelectedGroupPrisons: Extracting temp to " + tempFullName);
                                entry.Extract(tempDIR, ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                    }
                }

            }
            return TempZipFile;
        }

        /// <summary>
        /// Reads the .prison file to report prison stats
        /// </summary>
        /// <param name="prisonFullName"></param>
        /// <returns>String of stats </returns>
        private String GetPrisonStats(String prisonFullName)
        {
            //BEGIN Finance    Balance 783166.0  LastDay 10  LastHour 19  SalePrice 0  BankLoan 0  BankCreditRating 1.000000  Ownership 100  ExportsToday 0  ExportsYesterday 0  END
            String stats = "";
            string BALANCE = "";
            int LASTDAY = 0;
            if (File.Exists(prisonFullName))
            {
                StringCollection dot_prison = new StringCollection();
                if (prisonFullName.EndsWith(".prison"))
                {
                    dot_prison.AddRange(File.ReadAllLines(prisonFullName));
                    string[] seperators = new string[] { "  ", " " };
                    string[] LINE = FindLine("BEGIN Finance", dot_prison).Replace("BEGIN Finance", "").Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                    BALANCE = LINE[1];
                    LASTDAY = Convert.ToInt16(LINE[3]);
                    int LASTHOUR = Convert.ToInt16(LINE[5]);
                    //ROUND UP LASTDAY AS DOES GAME
                    if (LASTHOUR >= 12)
                        LASTDAY = LASTDAY + 1;
                }
                else if(prisonFullName.EndsWith(".zip"))
                {
                    String TEMPFOLDER = "";
                    List<String> TempZipFiles = new List<String>(ExtractToTemp(prisonFullName, true, out TEMPFOLDER));
                    foreach (String item in TempZipFiles)
                    {
                        if (item.EndsWith(".prison") && Directory.Exists(TEMPFOLDER))
                        {
                            dot_prison.AddRange(File.ReadAllLines(TEMPFOLDER + "\\" + item));
                            string[] seperators = new string[] { "  ", " " };
                            string[] LINE = FindLine("BEGIN Finance", dot_prison).Replace("BEGIN Finance", "").Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                            BALANCE = LINE[1];
                            LASTDAY = Convert.ToInt16(LINE[3]);
                            int LASTHOUR = Convert.ToInt16(LINE[5]);
                            //ROUND UP LASTDAY AS DOES GAME
                            if (LASTHOUR >= 12)
                                LASTDAY = LASTDAY + 1;
                        }
                    }
                }

                stats += " || BALANCE: " + BALANCE + " || LASTDAY: " + Convert.ToString(LASTDAY);
            }
            return stats;
        }


    }
}