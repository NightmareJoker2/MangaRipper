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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnGetChapter = new System.Windows.Forms.Button();
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
            this.btnChangeSaveTo = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.lbSaveTo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ColChapterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChapterStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChapterUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueueChapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetChapter
            // 
            this.btnGetChapter.Location = new System.Drawing.Point(876, 9);
            this.btnGetChapter.Name = "btnGetChapter";
            this.btnGetChapter.Size = new System.Drawing.Size(116, 24);
            this.btnGetChapter.TabIndex = 0;
            this.btnGetChapter.Text = "Get Chapters";
            this.btnGetChapter.UseVisualStyleBackColor = true;
            this.btnGetChapter.Click += new System.EventHandler(this.btnGetChapter_Click);
            // 
            // txtTitleUrl
            // 
            this.txtTitleUrl.Location = new System.Drawing.Point(38, 12);
            this.txtTitleUrl.Name = "txtTitleUrl";
            this.txtTitleUrl.Size = new System.Drawing.Size(796, 20);
            this.txtTitleUrl.TabIndex = 2;
            this.txtTitleUrl.Text = "http://www.mangafox.com/manga/mirai_nikki/";
            // 
            // lbChapter
            // 
            this.lbChapter.FormattingEnabled = true;
            this.lbChapter.Location = new System.Drawing.Point(12, 38);
            this.lbChapter.Name = "lbChapter";
            this.lbChapter.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbChapter.Size = new System.Drawing.Size(425, 238);
            this.lbChapter.TabIndex = 3;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(665, 554);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(105, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 282);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(210, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Selected";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(227, 282);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(210, 23);
            this.btnAddAll.TabIndex = 6;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(443, 554);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(105, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(554, 554);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(105, 23);
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
            this.dgvQueueChapter.Location = new System.Drawing.Point(443, 38);
            this.dgvQueueChapter.Name = "dgvQueueChapter";
            this.dgvQueueChapter.ReadOnly = true;
            this.dgvQueueChapter.RowHeadersVisible = false;
            this.dgvQueueChapter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueueChapter.Size = new System.Drawing.Size(549, 510);
            this.dgvQueueChapter.TabIndex = 9;
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.Location = new System.Drawing.Point(66, 313);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.ReadOnly = true;
            this.txtSaveTo.Size = new System.Drawing.Size(252, 20);
            this.txtSaveTo.TabIndex = 10;
            this.txtSaveTo.Text = "D:\\Personal Files\\Comics\\321321\\";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(776, 554);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(105, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnChangeSaveTo
            // 
            this.btnChangeSaveTo.Enabled = false;
            this.btnChangeSaveTo.Location = new System.Drawing.Point(324, 311);
            this.btnChangeSaveTo.Name = "btnChangeSaveTo";
            this.btnChangeSaveTo.Size = new System.Drawing.Size(30, 23);
            this.btnChangeSaveTo.TabIndex = 13;
            this.btnChangeSaveTo.Text = "...";
            this.btnChangeSaveTo.UseVisualStyleBackColor = true;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Enabled = false;
            this.btnOpenFolder.Location = new System.Drawing.Point(360, 311);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(77, 23);
            this.btnOpenFolder.TabIndex = 14;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            // 
            // lbSaveTo
            // 
            this.lbSaveTo.AutoSize = true;
            this.lbSaveTo.Location = new System.Drawing.Point(12, 316);
            this.lbSaveTo.Name = "lbSaveTo";
            this.lbSaveTo.Size = new System.Drawing.Size(48, 13);
            this.lbSaveTo.TabIndex = 15;
            this.lbSaveTo.Text = "Save To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Url";
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
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(835, 12);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.ReadOnly = true;
            this.txtPercent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPercent.Size = new System.Drawing.Size(35, 20);
            this.txtPercent.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 340);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(425, 237);
            this.dataGridView1.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(887, 554);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Url";
            this.dataGridViewTextBoxColumn3.HeaderText = "Address";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 589);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
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
            this.Controls.Add(this.lbChapter);
            this.Controls.Add(this.txtTitleUrl);
            this.Controls.Add(this.btnGetChapter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueueChapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetChapter;
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
        private System.Windows.Forms.Button btnChangeSaveTo;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Label lbSaveTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChapterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChapterStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChapterUrl;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}