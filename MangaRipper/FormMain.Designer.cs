﻿namespace MangaRipper
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnGetChapter = new System.Windows.Forms.Button();
            this.txtTitleUrl = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.dgvQueueChapter = new System.Windows.Forms.DataGridView();
            this.txtSaveTo = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnChangeSaveTo = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.lbSaveTo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.dgvSupportedSites = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ColChapterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChapterStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChapterUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChapter = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueueChapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupportedSites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapter)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetChapter
            // 
            this.btnGetChapter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetChapter.Location = new System.Drawing.Point(876, 9);
            this.btnGetChapter.Name = "btnGetChapter";
            this.btnGetChapter.Size = new System.Drawing.Size(116, 24);
            this.btnGetChapter.TabIndex = 3;
            this.btnGetChapter.Text = "Get Chapters";
            this.btnGetChapter.UseVisualStyleBackColor = true;
            this.btnGetChapter.Click += new System.EventHandler(this.btnGetChapter_Click);
            // 
            // txtTitleUrl
            // 
            this.txtTitleUrl.Location = new System.Drawing.Point(38, 12);
            this.txtTitleUrl.Name = "txtTitleUrl";
            this.txtTitleUrl.Size = new System.Drawing.Size(796, 20);
            this.txtTitleUrl.TabIndex = 1;
            this.txtTitleUrl.Text = "http://www.mangafox.com/manga/mirai_nikki/";
            // 
            // btnDownload
            // 
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Location = new System.Drawing.Point(665, 551);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(216, 23);
            this.btnDownload.TabIndex = 15;
            this.btnDownload.Text = "Start Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(12, 287);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(210, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Selected";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.Location = new System.Drawing.Point(227, 287);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(210, 23);
            this.btnAddAll.TabIndex = 6;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(443, 551);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(105, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.Location = new System.Drawing.Point(554, 551);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(105, 23);
            this.btnRemoveAll.TabIndex = 14;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // dgvQueueChapter
            // 
            this.dgvQueueChapter.AllowUserToAddRows = false;
            this.dgvQueueChapter.AllowUserToDeleteRows = false;
            this.dgvQueueChapter.AllowUserToResizeRows = false;
            this.dgvQueueChapter.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvQueueChapter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvQueueChapter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueueChapter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColChapterName,
            this.ColChapterStatus,
            this.ColChapterUrl});
            this.dgvQueueChapter.Location = new System.Drawing.Point(443, 38);
            this.dgvQueueChapter.Name = "dgvQueueChapter";
            this.dgvQueueChapter.ReadOnly = true;
            this.dgvQueueChapter.RowHeadersVisible = false;
            this.dgvQueueChapter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueueChapter.Size = new System.Drawing.Size(549, 507);
            this.dgvQueueChapter.TabIndex = 12;
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.Location = new System.Drawing.Point(66, 318);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.ReadOnly = true;
            this.txtSaveTo.Size = new System.Drawing.Size(252, 20);
            this.txtSaveTo.TabIndex = 8;
            this.txtSaveTo.Text = "D:\\Personal Files\\Comics\\321321\\";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(887, 551);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(105, 23);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnChangeSaveTo
            // 
            this.btnChangeSaveTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeSaveTo.Location = new System.Drawing.Point(324, 316);
            this.btnChangeSaveTo.Name = "btnChangeSaveTo";
            this.btnChangeSaveTo.Size = new System.Drawing.Size(30, 23);
            this.btnChangeSaveTo.TabIndex = 9;
            this.btnChangeSaveTo.Text = "...";
            this.btnChangeSaveTo.UseVisualStyleBackColor = true;
            this.btnChangeSaveTo.Click += new System.EventHandler(this.btnChangeSaveTo_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Location = new System.Drawing.Point(360, 316);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(77, 23);
            this.btnOpenFolder.TabIndex = 10;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // lbSaveTo
            // 
            this.lbSaveTo.AutoSize = true;
            this.lbSaveTo.Location = new System.Drawing.Point(12, 321);
            this.lbSaveTo.Name = "lbSaveTo";
            this.lbSaveTo.Size = new System.Drawing.Size(48, 13);
            this.lbSaveTo.TabIndex = 7;
            this.lbSaveTo.Text = "Save To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Url";
            // 
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(835, 12);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.ReadOnly = true;
            this.txtPercent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPercent.Size = new System.Drawing.Size(35, 20);
            this.txtPercent.TabIndex = 2;
            // 
            // dgvSupportedSites
            // 
            this.dgvSupportedSites.AllowUserToAddRows = false;
            this.dgvSupportedSites.AllowUserToDeleteRows = false;
            this.dgvSupportedSites.AllowUserToResizeRows = false;
            this.dgvSupportedSites.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSupportedSites.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSupportedSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupportedSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.dgvSupportedSites.Location = new System.Drawing.Point(12, 345);
            this.dgvSupportedSites.MultiSelect = false;
            this.dgvSupportedSites.Name = "dgvSupportedSites";
            this.dgvSupportedSites.ReadOnly = true;
            this.dgvSupportedSites.RowHeadersVisible = false;
            this.dgvSupportedSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupportedSites.Size = new System.Drawing.Size(425, 200);
            this.dgvSupportedSites.TabIndex = 11;
            this.dgvSupportedSites.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupportedSites_CellContentClick);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(123, 551);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "How To Use && F.A.Q.";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(12, 551);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Option";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(332, 551);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "About";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ColChapterName
            // 
            this.ColChapterName.DataPropertyName = "Name";
            this.ColChapterName.HeaderText = "Chapter Name";
            this.ColChapterName.Name = "ColChapterName";
            this.ColChapterName.ReadOnly = true;
            this.ColChapterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColChapterName.Width = 200;
            // 
            // ColChapterStatus
            // 
            this.ColChapterStatus.HeaderText = "%";
            this.ColChapterStatus.Name = "ColChapterStatus";
            this.ColChapterStatus.ReadOnly = true;
            this.ColChapterStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColChapterStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColChapterStatus.Width = 35;
            // 
            // ColChapterUrl
            // 
            this.ColChapterUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColChapterUrl.DataPropertyName = "Url";
            this.ColChapterUrl.HeaderText = "Address";
            this.ColChapterUrl.Name = "ColChapterUrl";
            this.ColChapterUrl.ReadOnly = true;
            this.ColChapterUrl.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColChapterUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvChapter
            // 
            this.dgvChapter.AllowUserToAddRows = false;
            this.dgvChapter.AllowUserToDeleteRows = false;
            this.dgvChapter.AllowUserToResizeRows = false;
            this.dgvChapter.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChapter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChapter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChapter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
            this.dgvChapter.Location = new System.Drawing.Point(12, 38);
            this.dgvChapter.Name = "dgvChapter";
            this.dgvChapter.ReadOnly = true;
            this.dgvChapter.RowHeadersVisible = false;
            this.dgvChapter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChapter.Size = new System.Drawing.Size(425, 243);
            this.dgvChapter.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Chapter Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1004, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "Message: ";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Url";
            this.dataGridViewTextBoxColumn3.HeaderText = "Address";
            this.dataGridViewTextBoxColumn3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.dataGridViewTextBoxColumn3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 606);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvChapter);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvSupportedSites);
            this.Controls.Add(this.txtPercent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSaveTo);
            this.Controls.Add(this.lbSaveTo);
            this.Controls.Add(this.btnChangeSaveTo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.dgvQueueChapter);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtTitleUrl);
            this.Controls.Add(this.btnGetChapter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueueChapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupportedSites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapter)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetChapter;
        private System.Windows.Forms.TextBox txtTitleUrl;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.DataGridView dgvQueueChapter;
        private System.Windows.Forms.TextBox txtSaveTo;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnChangeSaveTo;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Label lbSaveTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.DataGridView dgvSupportedSites;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChapterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChapterStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChapterUrl;
        private System.Windows.Forms.DataGridView dgvChapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewTextBoxColumn3;
    }
}