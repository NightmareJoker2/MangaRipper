namespace MangaRipper
{
    partial class FormMain1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain1));
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnListChapters = new System.Windows.Forms.Button();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.txtSaveTo = new System.Windows.Forms.TextBox();
            this.btnStartDownload = new System.Windows.Forms.Button();
            this.labelURL = new System.Windows.Forms.Label();
            this.labelSaveTo = new System.Windows.Forms.Label();
            this.lbChapters = new System.Windows.Forms.ListBox();
            this.lbQueue = new System.Windows.Forms.ListBox();
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.progressList = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(42, 11);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(385, 22);
            this.txtURL.TabIndex = 0;
            // 
            // btnListChapters
            // 
            this.btnListChapters.Location = new System.Drawing.Point(433, 10);
            this.btnListChapters.Name = "btnListChapters";
            this.btnListChapters.Size = new System.Drawing.Size(87, 23);
            this.btnListChapters.TabIndex = 1;
            this.btnListChapters.Text = "List Chapters";
            this.btnListChapters.UseVisualStyleBackColor = true;
            this.btnListChapters.Click += new System.EventHandler(this.ListChapters_Click);
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Location = new System.Drawing.Point(493, 242);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(27, 23);
            this.btnSelectDirectory.TabIndex = 3;
            this.btnSelectDirectory.Text = "...";
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.SelectDirectory_Click);
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.Location = new System.Drawing.Point(58, 244);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.ReadOnly = true;
            this.txtSaveTo.Size = new System.Drawing.Size(429, 22);
            this.txtSaveTo.TabIndex = 5;
            // 
            // btnStartDownload
            // 
            this.btnStartDownload.Location = new System.Drawing.Point(303, 270);
            this.btnStartDownload.Name = "btnStartDownload";
            this.btnStartDownload.Size = new System.Drawing.Size(105, 23);
            this.btnStartDownload.TabIndex = 6;
            this.btnStartDownload.Text = "Start Download";
            this.btnStartDownload.UseVisualStyleBackColor = true;
            this.btnStartDownload.Click += new System.EventHandler(this.StartDownload_Click);
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(9, 14);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(30, 13);
            this.labelURL.TabIndex = 8;
            this.labelURL.Text = "URL:";
            // 
            // labelSaveTo
            // 
            this.labelSaveTo.AutoSize = true;
            this.labelSaveTo.Location = new System.Drawing.Point(9, 246);
            this.labelSaveTo.Name = "labelSaveTo";
            this.labelSaveTo.Size = new System.Drawing.Size(48, 13);
            this.labelSaveTo.TabIndex = 9;
            this.labelSaveTo.Text = "Save To:";
            // 
            // lbChapters
            // 
            this.lbChapters.DisplayMember = "Name";
            this.lbChapters.FormattingEnabled = true;
            this.lbChapters.Location = new System.Drawing.Point(12, 38);
            this.lbChapters.Name = "lbChapters";
            this.lbChapters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbChapters.Size = new System.Drawing.Size(236, 199);
            this.lbChapters.TabIndex = 2;
            // 
            // lbQueue
            // 
            this.lbQueue.DisplayMember = "Name";
            this.lbQueue.FormattingEnabled = true;
            this.lbQueue.Location = new System.Drawing.Point(285, 38);
            this.lbQueue.Name = "lbQueue";
            this.lbQueue.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbQueue.Size = new System.Drawing.Size(236, 199);
            this.lbQueue.TabIndex = 10;
            // 
            // progressDownload
            // 
            this.progressDownload.Location = new System.Drawing.Point(12, 270);
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(284, 21);
            this.progressDownload.TabIndex = 11;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(471, 270);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(49, 23);
            this.btnHelp.TabIndex = 14;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.Help_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(250, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 25);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddSelected_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(250, 98);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(33, 25);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.RemoveSelected_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(250, 128);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(33, 25);
            this.btnRemoveAll.TabIndex = 18;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.RemoveAll_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(250, 67);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(33, 25);
            this.btnAddAll.TabIndex = 16;
            this.btnAddAll.Text = ">>";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.AddAll_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(415, 270);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(50, 23);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 38);
            this.button1.TabIndex = 21;
            this.button1.Text = "W";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenWebsite_Click);
            // 
            // progressList
            // 
            this.progressList.Location = new System.Drawing.Point(12, 270);
            this.progressList.Name = "progressList";
            this.progressList.Size = new System.Drawing.Size(284, 9);
            this.progressList.TabIndex = 22;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 303);
            this.Controls.Add(this.progressList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.progressDownload);
            this.Controls.Add(this.lbQueue);
            this.Controls.Add(this.labelSaveTo);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.btnStartDownload);
            this.Controls.Add(this.txtSaveTo);
            this.Controls.Add(this.btnSelectDirectory);
            this.Controls.Add(this.lbChapters);
            this.Controls.Add(this.btnListChapters);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnListChapters;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.TextBox txtSaveTo;
        private System.Windows.Forms.Button btnStartDownload;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.Label labelSaveTo;
        private System.Windows.Forms.ListBox lbChapters;
        private System.Windows.Forms.ListBox lbQueue;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ProgressBar progressDownload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressList;

    }
}

