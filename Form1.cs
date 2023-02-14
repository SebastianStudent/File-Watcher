using System.Text;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace Nasłuchiwanie_Plików
{
    public partial class watcher : Form
    {
        /// <summary>
        /// Our copy path
        /// </summary>
        private static StringBuilder path;
        /// <summary>
        /// Path to file with data
        /// </summary>
        private static string LogFile_Path;
        /// <summary>
        /// Eliminating redundant functions in WriteNewLine(string line)
        /// </summary>
        private static bool check = true;
        /// <summary>
        /// Local time with current date and time
        /// </summary>
        private static DateTime localTime;
        public watcher()
        {
            InitializeComponent();
            dataGridView_Logs.Columns.Add("Records", "Records");
            dataGridView_Logs.ClearSelection();
            DialogResult dialogResult = MessageBox.Show("Do you want load every previous log?", "Warning!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                LoadEveryLog();
            }
        }
        private void rowSelect()
        {
            if (checkBox_focusOnNew.Checked == true)
            {
                int rowIndex = dataGridView_Logs.Rows.Count;
                try
                {
                    dataGridView_Logs.Rows[rowIndex - 1].Selected = true;
                    dataGridView_Logs.FirstDisplayedScrollingRowIndex = rowIndex - 1;
                }
                catch (Exception)
                {
                    checkBox_focusOnNew.Checked = false;
                    MessageBox.Show("You cannot focus on new line if you are not load table");
                }
            }
        }

        private void LoadEveryLog()
        {
            button_LoadEverything.Visible = false;
            StringBuilder strExeFilePath = new StringBuilder(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string fileName = Path.GetFileName(strExeFilePath.ToString());
            //MessageBox.Show(strExeFilePath + "\n\n" + fileName);              //Path to exe file this program and name of this file
            strExeFilePath.Remove(strExeFilePath.Length - fileName.Length, fileName.Length);
            //MessageBox.Show(strExeFilePath.ToString());                       //Path to exe file this program without name of this file
            strExeFilePath.Append("LogFile.txt");
            //MessageBox.Show(strExeFilePath.ToString());                       //Path to exe this program, but the name of file is changed to LogFile.txt
            LogFile_Path = @strExeFilePath.ToString();

            try
            {
                if (!File.Exists(LogFile_Path))                             //Create LogFile.txt if file is not in folder with exe file of this program
                {
                    FileStream fs = File.Create(LogFile_Path);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE CHECKING OR CREATING A LOG FILE " + ex);
            }
            try
            {
                dataGridView_Logs.Rows.Clear();
                dataGridView_Logs.Visible = true;
                FileStream readSourceStream = new FileStream(LogFile_Path, FileMode.Open, FileAccess.Read, FileShare.None);     //Open File stream with only read and share with no one
                StreamReader sr = new StreamReader(readSourceStream);

                while (!sr.EndOfStream)
                {
                    dataGridView_Logs.Rows.Add(sr.ReadLine());
                }
                sr.Close();
                readSourceStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with displaying existing records" + ex);
            }
            rowSelect();
        }

        private void textBox_Sciezka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox_Sciezka.Text != "")
            {
                StringBuilder strExeFilePath = new StringBuilder(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string fileName = Path.GetFileName(strExeFilePath.ToString());
                //MessageBox.Show(strExeFilePath + "\n\n" + fileName);              //Path to exe file this program and name of this file
                strExeFilePath.Remove(strExeFilePath.Length - fileName.Length, fileName.Length);
                //MessageBox.Show(strExeFilePath.ToString());                       //Path to exe file this program without name of this file
                strExeFilePath.Append("LogFile.txt");
                //MessageBox.Show(strExeFilePath.ToString());                       //Path to exe this program, but the name of file is changed to LogFile.txt
                LogFile_Path = @strExeFilePath.ToString();

                path = new StringBuilder();
                path.Append(textBox_Sciezka.Text);
                if (Directory.Exists(@path.ToString()))                             //Program checked that folder path is correct or not
                {
                    dataGridView_Logs.Visible = true;
                    try
                    {
                        if (!File.Exists(LogFile_Path))                             //Create LogFile.txt if file is not in folder with exe file of this program
                        {
                            FileStream fs = File.Create(LogFile_Path);
                            fs.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE CHECKING OR CREATING A LOG FILE " + ex);
                    }
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want open window with that path?", "Warning!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start("Explorer.exe", @path.ToString());             //Open exploler files with correct path
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The path leads to an unhandled exception!\n" + ex.ToString());
                    }
                    try
                    {
                        fileSystemWatcher.Path = @path.ToString();                   //Start pointing at selected folder
                        fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess    //Gets or sets the type of changes to watch
                            | NotifyFilters.FileName
                            | NotifyFilters.DirectoryName
                            | NotifyFilters.LastWrite;
                        fileSystemWatcher.Changed += new FileSystemEventHandler(fileSystemWatcher_Changed);
                        fileSystemWatcher.Created += new FileSystemEventHandler(fileSystemWatcher_Created);
                        fileSystemWatcher.Deleted += new FileSystemEventHandler(fileSystemWatcher_Deleted);
                        fileSystemWatcher.Renamed += new RenamedEventHandler(fileSystemWatcher_Renamed);
                        fileSystemWatcher.Error += new ErrorEventHandler(fileSystemWatcher_Error);
                        fileSystemWatcher.EnableRaisingEvents = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("FileSystemWatcher has an unhandled exception: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid path or folder does not exist. \nMake sure the path points to a folder, not a file!");
                }
            }
        }

        private void WriteNewLine(string line)
        {
            if (check)
            {
                if (!line.Contains(LogFile_Path) || !Directory.Exists(line))
                {

                    dataGridView_Logs.Rows.Add(line);
                    List<string> container = new List<string>();
                    try
                    {
                        FileStream readSourceStream = new FileStream(LogFile_Path, FileMode.Open, FileAccess.Read, FileShare.None);
                        StreamReader sr = new StreamReader(readSourceStream);

                        string readedLine;
                        while (!sr.EndOfStream)
                        {
                            readedLine = sr.ReadLine();
                            container.Add(readedLine);
                        }
                        sr.Close();
                        readSourceStream.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("FileStream lub StreamReader w funkji WriteNewLine posiada nieobsłużony wyjątek: " + ex);
                    }
                    try
                    {
                        FileStream writeSourceStream = new FileStream(LogFile_Path, FileMode.Open, FileAccess.Write, FileShare.None);
                        StreamWriter sw = new StreamWriter(writeSourceStream);
                        foreach (string oneLine in container)
                        {
                            sw.WriteLine(oneLine);
                        }
                        sw.WriteLine(line);
                        sw.Flush();
                        sw.Close();
                        writeSourceStream.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("FileStream lub StreamWriter posiada nieobsłużony wyjątek: " + ex);
                    }
                }
                check = false;
            }
            else
            {
                check = true;
            }
        }

        private void checkBox_focusOnNew_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_focusOnNew.Checked == true)
            {
                dataGridView_Logs.ClearSelection();
                rowSelect();
            }
        }

        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            localTime = DateTime.Now;
            WriteNewLine(localTime + " " + e.FullPath + " " + e.Name + " " + e.ChangeType);
            rowSelect();
        }

        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            localTime = DateTime.Now;
            WriteNewLine(localTime + " " + e.FullPath + " " + e.Name + " " + e.ChangeType);
            rowSelect();
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            localTime = DateTime.Now;
            WriteNewLine(localTime + " " + e.FullPath + " " + e.Name + " " + e.ChangeType);
            rowSelect();
        }

        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            localTime = DateTime.Now;
            WriteNewLine(localTime + " " + e.OldName + " is now " + e.Name + " " + e.ChangeType);
            rowSelect();
        }

        private void fileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            localTime = DateTime.Now;
            WriteNewLine(localTime + " " + "Error: " + e.GetException());
            rowSelect();
        }

        private void LoadEverything_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want load every previous log?", "Warning!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                LoadEveryLog();
            }
        }
    }
}