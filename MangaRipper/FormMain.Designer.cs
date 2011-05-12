namespace MangaRipper
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
            this.btnGetChapter = new System.Windows.Forms.Button();
            this.pbGetChapterProgress = new System.Windows.Forms.ProgressBar();
            this.txtTitleUrl = new System.Windows.Forms.TextBox();
            this.lbChapter = new System.Windows.Forms.ListBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.dgvQueueChapter = new System.Windows.Forms.DataGridView();
            this.txtSaveTo = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ColChapterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChapterStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChapterUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueueChapter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetChapter
            // 
            this.btnGetChapter.Location = new System.Drawing.Point(370, 30);
            this.btnGetChapter.Name = "btnGetChapter";
            this.btnGetChapter.Size = new System.Drawing.Size(95, 24);
            this.btnGetChapter.TabIndex = 0;
            this.btnGetChapter.Text = "Get Chapters";
            this.btnGetChapter.UseVisualStyleBackColor = true;
            this.btnGetChapter.Click += new System.EventHandler(this.btnGetChapter_Click);
            // 
            // pbGetChapterProgress
            // 
            this.pbGetChapterProgress.Location = new System.Drawing.Point(26, 59);
            this.pbGetChapterProgress.Name = "pbGetChapterProgress";
            this.pbGetChapterProgress.Size = new System.Drawing.Size(338, 23);
            this.pbGetChapterProgress.TabIndex = 1;
            // 
            // txtTitleUrl
            // 
            this.txtTitleUrl.Location = new System.Drawing.Point(26, 33);
            this.txtTitleUrl.Name = "txtTitleUrl";
            this.txtTitleUrl.Size = new System.Drawing.Size(338, 20);
            this.txtTitleUrl.TabIndex = 2;
            this.txtTitleUrl.Text = "http://www.mangafox.com/manga/mirai_nikki/";
            // 
            // lbChapter
            // 
            this.lbChapter.FormattingEnabled = true;
            this.lbChapter.Location = new System.Drawing.Point(26, 88);
            this.lbChapter.Name = "lbChapter";
            this.lbChapter.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbChapter.Size = new System.Drawing.Size(301, 212);
            this.lbChapter.TabIndex = 3;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(333, 251);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(168, 49);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download Chapter";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(333, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(166, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Selected";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(333, 117);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(166, 23);
            this.btnAddAll.TabIndex = 6;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(333, 146);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(166, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(333, 175);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(166, 23);
            this.btnRemoveAll.TabIndex = 8;
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
            this.dgvQueueChapter.Location = new System.Drawing.Point(26, 332);
            this.dgvQueueChapter.Name = "dgvQueueChapter";
            this.dgvQueueChapter.ReadOnly = true;
            this.dgvQueueChapter.RowHeadersVisible = false;
            this.dgvQueueChapter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueueChapter.Size = new System.Drawing.Size(510, 239);
            this.dgvQueueChapter.TabIndex = 9;
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.Location = new System.Drawing.Point(333, 225);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.Size = new System.Drawing.Size(168, 20);
            this.txtSaveTo.TabIndex = 10;
            this.txtSaveTo.Text = "d:\\Personal Files\\Comics\\321321\\";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(527, 264);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Support www.mangafox.com and read.mangashare.com url";
            // 
            // ColChapterName
            // 
            this.ColChapterName.DataPropertyName = "Name";
            this.ColChapterName.HeaderText = "Chapter Name";
            this.ColChapterName.Name = "ColChapterName";
            this.ColChapterName.ReadOnly = true;
            this.ColChapterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColChapterName.Width = 150;
            // 
            // ColChapterStatus
            // 
            this.ColChapterStatus.HeaderText = "Status";
            this.ColChapterStatus.Name = "ColChapterStatus";
            this.ColChapterStatus.ReadOnly = true;
            this.ColChapterStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColChapterStatus.Width = 50;
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 589);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtSaveTo);
            this.Controls.Add(this.dgvQueueChapter);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lbChapter);
            this.Controls.Add(this.txtTitleUrl);
            this.Controls.Add(this.pbGetChapterProgress);
            this.Controls.Add(this.btnGetChapter);
            this.Name = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueueChapter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetChapter;
        private System.Windows.Forms.ProgressBar pbGetChapterProgress;
        private System.Windows.Forms.TextBox txtTitleUrl;
        private System.Windows.Forms.ListBox lbChapter;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.DataGridView dgvQueueChapter;
        private System.Windows.Forms.TextBox txtSaveTo;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChapterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChapterStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChapterUrl;
    }
}