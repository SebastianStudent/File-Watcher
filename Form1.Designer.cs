namespace Nasłuchiwanie_Plików
{
    partial class watcher
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_Logs = new System.Windows.Forms.DataGridView();
            this.textBox_Sciezka = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.checkBox_focusOnNew = new System.Windows.Forms.CheckBox();
            this.button_LoadEverything = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Logs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Logs
            // 
            this.dataGridView_Logs.AllowUserToAddRows = false;
            this.dataGridView_Logs.AllowUserToDeleteRows = false;
            this.dataGridView_Logs.AllowUserToResizeColumns = false;
            this.dataGridView_Logs.AllowUserToResizeRows = false;
            this.dataGridView_Logs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Logs.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView_Logs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Logs.Location = new System.Drawing.Point(33, 97);
            this.dataGridView_Logs.Name = "dataGridView_Logs";
            this.dataGridView_Logs.ReadOnly = true;
            this.dataGridView_Logs.RowHeadersVisible = false;
            this.dataGridView_Logs.RowTemplate.Height = 25;
            this.dataGridView_Logs.Size = new System.Drawing.Size(900, 343);
            this.dataGridView_Logs.TabIndex = 0;
            this.dataGridView_Logs.Visible = false;
            // 
            // textBox_Sciezka
            // 
            this.textBox_Sciezka.Location = new System.Drawing.Point(33, 37);
            this.textBox_Sciezka.Name = "textBox_Sciezka";
            this.textBox_Sciezka.Size = new System.Drawing.Size(900, 23);
            this.textBox_Sciezka.TabIndex = 1;
            this.textBox_Sciezka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Sciezka_KeyDown);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.NotifyFilter = ((System.IO.NotifyFilters)((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName) 
            | System.IO.NotifyFilters.LastWrite) 
            | System.IO.NotifyFilters.LastAccess)));
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Deleted);
            this.fileSystemWatcher.Error += new System.IO.ErrorEventHandler(this.fileSystemWatcher_Error);
            this.fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher_Renamed);
            // 
            // checkBox_focusOnNew
            // 
            this.checkBox_focusOnNew.AutoSize = true;
            this.checkBox_focusOnNew.Location = new System.Drawing.Point(33, 66);
            this.checkBox_focusOnNew.Name = "checkBox_focusOnNew";
            this.checkBox_focusOnNew.Size = new System.Drawing.Size(105, 19);
            this.checkBox_focusOnNew.TabIndex = 2;
            this.checkBox_focusOnNew.Text = "Focus for news";
            this.checkBox_focusOnNew.UseVisualStyleBackColor = true;
            this.checkBox_focusOnNew.CheckedChanged += new System.EventHandler(this.checkBox_focusOnNew_CheckedChanged);
            // 
            // button_LoadEverything
            // 
            this.button_LoadEverything.Location = new System.Drawing.Point(858, 63);
            this.button_LoadEverything.Name = "button_LoadEverything";
            this.button_LoadEverything.Size = new System.Drawing.Size(75, 23);
            this.button_LoadEverything.TabIndex = 3;
            this.button_LoadEverything.Text = "LoadEverything";
            this.button_LoadEverything.UseVisualStyleBackColor = true;
            this.button_LoadEverything.Click += new System.EventHandler(this.LoadEverything_Click);
            // 
            // watcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 451);
            this.Controls.Add(this.button_LoadEverything);
            this.Controls.Add(this.checkBox_focusOnNew);
            this.Controls.Add(this.textBox_Sciezka);
            this.Controls.Add(this.dataGridView_Logs);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(980, 490);
            this.MinimumSize = new System.Drawing.Size(980, 490);
            this.Name = "watcher";
            this.Text = "FolderWatcher";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Logs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView_Logs;
        private TextBox textBox_Sciezka;
        private FileSystemWatcher fileSystemWatcher;
        private CheckBox checkBox_focusOnNew;
        private Button button_LoadEverything;
    }
}