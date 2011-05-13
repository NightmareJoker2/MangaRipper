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
        List<IChapter> queue = new List<IChapter>();

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
                txtPercent.Text = "0%";
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
            var items = new List<IChapter>();
            foreach (DataGridViewRow row in dgvChapter.Rows)
            {
                items.Add((IChapter)row.DataBoundItem);
            }
            items.Reverse();
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
                if (chapter.IsBusy == false)
                {
                    queue.Remove(chapter);
                }
            }
            ReBindQueueList();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            queue.RemoveAll(r => r.IsBusy == false);
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

                chapter.DownloadImageProgressChanged += new ProgressChangedEventHandler(IChapter_DownloadImageProgressChanged);
                chapter.DownloadImageCompleted += new RunWorkerCompletedEventHandler(IChapter_DownloadImageCompleted);

                btnDownload.Enabled = false;
                dgvQueueChapter.Rows[0].Cells["ColChapterStatus"].Value = "0%";
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
                queue.Remove(chapter);
            }

            ReBindQueueList();

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
                    item.Cells["ColChapterStatus"].Value = e.ProgressPercentage.ToString() + "%";
                    break;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (dgvQueueChapter.Rows.Count > 0)
            {
                IChapter chapter = (IChapter)dgvQueueChapter.Rows[0].DataBoundItem;
                chapter.CancelDownloadImage();
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
            if (e.ColumnIndex == 1)
            {
                Process.Start(dgvSupportedSites.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dgvQueueChapter.AutoGenerateColumns = false;
            dgvChapter.AutoGenerateColumns = false;
            this.Text = String.Format("{0} {1}", Application.ProductName, DeploymentVersion);
            dgvSupportedSites.Rows.Add("MangaFox", "http://www.mangafox.com/");
            dgvSupportedSites.Rows.Add("MangaShare", "http://read.mangashare.com/");
            dgvSupportedSites.Rows.Add("BleachExile", "http://manga.bleachexile.com/");

            txtSaveTo.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(fileIChapter))
            {
                queue = Common.LoadIChapterCollection(fileIChapter);
                ReBindQueueList(); 
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        public string DeploymentVersion
        {
            get
            {
                System.Reflection.Assembly _assemblyInfo =
                   System.Reflection.Assembly.GetExecutingAssembly();

                string ourVersion = string.Empty;

                // if running the deployed application, you can get the version
                // from the ApplicationDeployment information. If you try
                // to access this when you are running in Visual Studio, it will not work.
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    ourVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
                else
                {
                    if (_assemblyInfo != null)
                    {
                        ourVersion = _assemblyInfo.GetName().Version.ToString();
                    }
                }
                return ourVersion;
            }
        }

        private void btnHowToUse_Click(object sender, EventArgs e)
        {
            Process.Start("http://mangaripper.codeplex.com/documentation");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Common.SaveIChapterCollection(queue, fileIChapter);
        }

        string fileIChapter = "IChapterQueue.sav";
    }
}
