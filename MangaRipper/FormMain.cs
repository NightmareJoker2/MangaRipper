using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Deployment.Application;

namespace MangaRipper
{
    public partial class FormMain : Form
    {
        BindingList<IChapter> DownloadQueue;

        protected const string FILENAME_ICHAPTER_COLLECTION = "IChapterCollection.bin";

        private bool AllowDownload = true;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnGetChapter_Click(object sender, EventArgs e)
        {
            try
            {
                var titleUrl = new Uri(txtTitleUrl.Text);
                ITitle title = TitleFactory.CreateTitle(titleUrl);
                title.PopulateChapterCompleted += new RunWorkerCompletedEventHandler(ITitle_PopulateChapterCompleted);
                title.PopulateChapterProgressChanged += new ProgressChangedEventHandler(ITitle_PopulateChapterProgressChanged);

                btnGetChapter.Enabled = false;
                title.PopulateChapterAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected void ITitle_PopulateChapterProgressChanged(object sender, ProgressChangedEventArgs e)
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

        protected void ITitle_PopulateChapterCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnGetChapter.Enabled = true;
            ITitle title = (ITitle)sender;
            dgvChapter.DataSource = title.Chapters;

            if (e.Error != null)
            {
                toolStripStatusLabel1.Text = e.Error.Message;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var items = new List<IChapter>();
            foreach (DataGridViewRow row in dgvChapter.Rows)
            {
                if (row.Selected == true)
                {
                    items.Add((IChapter)row.DataBoundItem);
                }
            }

            items.Reverse();
            foreach (IChapter item in items)
            {
                if (DownloadQueue.IndexOf(item) < 0)
                {
                    DownloadQueue.Add(item);
                }
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            var items = new List<IChapter>();
            foreach (DataGridViewRow row in dgvChapter.Rows)
            {
                items.Add((IChapter)row.DataBoundItem);
            }
            items.Reverse();
            foreach (IChapter item in items)
            {
                if (DownloadQueue.IndexOf(item) < 0)
                {
                    DownloadQueue.Add(item);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvQueueChapter.SelectedRows)
            {
                IChapter chapter = (IChapter)item.DataBoundItem;
                if (chapter.IsBusy == false)
                {
                    DownloadQueue.Remove(chapter);
                }
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            var removeItems = DownloadQueue.Where(r => r.IsBusy == false).ToList();

            foreach (var item in removeItems)
            {
                DownloadQueue.Remove(item);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            AllowDownload = true;
            DownloadChapter();
        }

        private void DownloadChapter()
        {
            if (DownloadQueue.Count > 0 && AllowDownload == true)
            {
                IChapter chapter = DownloadQueue.First();

                chapter.DownloadImageProgressChanged += new ProgressChangedEventHandler(IChapter_DownloadImageProgressChanged);
                chapter.DownloadImageCompleted += new RunWorkerCompletedEventHandler(IChapter_DownloadImageCompleted);

                btnDownload.Enabled = false;
                chapter.DownloadImageAsync(txtSaveTo.Text);
            }
            else
            {
                btnDownload.Enabled = true;
            }
        }

        protected void IChapter_DownloadImageCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IChapter chapter = (IChapter)sender;

            if (e.Cancelled == false && e.Error == null)
            {
                DownloadQueue.Remove(chapter);
            }

            if (e.Error != null)
            {

                toolStripStatusLabel1.Text = e.Error.Message;
            }

            if (e.Cancelled == false)
            {
                DownloadChapter();
            }
            else
            {
                btnDownload.Enabled = true;
            }
        }

        protected void IChapter_DownloadImageProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            IChapter chapter = (IChapter)sender;
            foreach (DataGridViewRow item in dgvQueueChapter.Rows)
            {
                if (chapter == item.DataBoundItem)
                {
                    item.Cells[ColChapterStatus.Name].Value = e.ProgressPercentage.ToString() + "%";
                    break;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AllowDownload = false;
            foreach (var item in DownloadQueue)
            {
                item.CancelDownloadImage();
            }
        }

        private void btnChangeSaveTo_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtSaveTo.Text;
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                txtSaveTo.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(txtSaveTo.Text);
        }

        private void dgvSupportedSites_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                Process.Start(dgvSupportedSites.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dgvQueueChapter.AutoGenerateColumns = false;
            dgvChapter.AutoGenerateColumns = false;

            this.Text = String.Format("{0} {1}", Application.ProductName, AppInfo.DeploymentVersion);

            TitleFactory.PopulateSiteGrid(dgvSupportedSites);

            if (String.IsNullOrEmpty(txtSaveTo.Text))
            {
                txtSaveTo.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            DownloadQueue = Common.LoadIChapterCollection(FILENAME_ICHAPTER_COLLECTION);
            dgvQueueChapter.DataSource = DownloadQueue;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        private void btnHowToUse_Click(object sender, EventArgs e)
        {
            Process.Start("http://mangaripper.codeplex.com/documentation");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            Common.SaveIChapterCollection(DownloadQueue, FILENAME_ICHAPTER_COLLECTION);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            FormOption form = new FormOption();
            form.ShowDialog(this);
        }
    }
}
