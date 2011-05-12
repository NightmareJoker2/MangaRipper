using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MangaRipper
{
    public partial class FormMain : Form
    {
        List<IChapter> queue = new List<IChapter>();

        public FormMain()
        {
            InitializeComponent();
            dgvQueueChapter.AutoGenerateColumns = false;
            this.Text = String.Format("{0} {1}", Application.ProductName, Application.ProductVersion.Remove(Application.ProductVersion.LastIndexOf(".")));
        }

        private void btnGetChapter_Click(object sender, EventArgs e)
        {
            var titleUrl = new Uri(txtTitleUrl.Text);
            ITitle title = TitleFactory.CreateTitle(titleUrl);
            title.RefreshChapterCompleted += new RunWorkerCompletedEventHandler(title_RefreshChapterCompleted);
            title.RefreshChapterProgressChanged += new ProgressChangedEventHandler(title_RefreshChapterProgressChanged);

            btnGetChapter.Enabled = false;
            title.RefreshChapterAsync();
            txtPercent.Text = "0%";
        }

        void title_RefreshChapterProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => txtPercent.Text = e.ProgressPercentage + "%"));
            }
            else
            {
                txtPercent.Text = e.ProgressPercentage + "%";
            }
        }

        void title_RefreshChapterCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnGetChapter.Enabled = true;
            ITitle title = (ITitle)sender;
            lbChapter.DataSource = title.Chapters;
            lbChapter.DisplayMember = "Name";

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var items = lbChapter.SelectedItems.Cast<IChapter>();
            items = items.Reverse();
            foreach (IChapter item in items)
            {
                if (queue.IndexOf(item) < 0)
                {
                    queue.Add(item);
                }
            }

            ReBindQueueList();
        }

        private void ReBindQueueList()
        {
            dgvQueueChapter.DataSource = null;
            dgvQueueChapter.DataSource = queue;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            var items = lbChapter.Items.Cast<IChapter>();
            items = items.Reverse();
            foreach (IChapter item in items)
            {
                if (queue.IndexOf(item) < 0)
                {
                    queue.Add(item);
                }
            }

            ReBindQueueList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvQueueChapter.SelectedRows)
            {
                IChapter chapter = (IChapter)item.DataBoundItem;
                if (queue.IndexOf(chapter) >= 0)
                {
                    queue.Remove(chapter);
                }
            }
            ReBindQueueList();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            queue.Clear();
            ReBindQueueList();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadChapter();
        }

        private void DownloadChapter()
        {
            if (dgvQueueChapter.Rows.Count > 0)
            {
                IChapter chapter = (IChapter)dgvQueueChapter.Rows[0].DataBoundItem;

                chapter.RefreshImageUrlProgressChanged += new ProgressChangedEventHandler(chapter_RefreshPageProgressChanged);
                chapter.RefreshImageUrlCompleted += new RunWorkerCompletedEventHandler(chapter_RefreshPageCompleted);

                btnDownload.Enabled = false;
                chapter.RefreshImageUrlAsync(txtSaveTo.Text);
            }
            else
            {
                btnDownload.Enabled = true;
            }
        }

        void chapter_RefreshPageCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IChapter chapter = (IChapter)sender;
            if (e.Cancelled == false && e.Error == null)
            {
                queue.Remove(chapter);
            }
            ReBindQueueList();
            DownloadChapter();
        }

        void chapter_RefreshPageProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            IChapter chapter = (IChapter)sender;
            dgvQueueChapter.Rows[0].Cells["ColChapterStatus"].Value = e.ProgressPercentage.ToString() + "%";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (dgvQueueChapter.Rows.Count > 0)
            {
                IChapter chapter = (IChapter)dgvQueueChapter.Rows[0].DataBoundItem;
                chapter.CancelRefreshImageUrl();
            }
        }
    }
}
