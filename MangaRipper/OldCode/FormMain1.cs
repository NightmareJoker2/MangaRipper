using System;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Net;

namespace MangaRipper
{
    public partial class FormMain1 : Form
    {
        bool _cancelListChapters;

        bool _cancelStartDownload;

        Thread thListChapters;

        Thread thDownload;

        delegate void AddToChapterListDelegate(List<Chapter> arr);

        delegate void RemoveFromQueueDelegate(Chapter item);

        public FormMain1()
        {
            InitializeComponent();
            this.Text = String.Format("{0} {1}", Application.ProductName, Application.ProductVersion.Remove(Application.ProductVersion.LastIndexOf(".")));
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = Application.ProductName;
            progressList.MarqueeAnimationSpeed = 25;
            progressDownload.MarqueeAnimationSpeed = 50;
        }

        private void AddToChaptersList(List<Chapter> arr)
        {
            if (InvokeRequired)
            {
                Invoke(new AddToChapterListDelegate(AddToChaptersList), arr);
            }
            else
            {
                foreach (Chapter item in arr)
                {
                    lbChapters.Items.Add(item);
                }
            }
        }

        private void RemoveFromQueueList(Chapter item)
        {
            if (InvokeRequired)
            {
                Invoke(new RemoveFromQueueDelegate(RemoveFromQueueList), item);
            }
            else
            {
                lbQueue.Items.Remove(item);
            }
        }

       

        private void ListChaptersThread()
        {
            try
            {
                Common.SetControlPropertyThreadSafe(btnListChapters, "Enabled", false);
                Common.SetControlPropertyThreadSafe(progressList, "Style", ProgressBarStyle.Marquee);
                List<Chapter> chapters = Manga.ListChaptersFromManga(txtURL.Text, 10, ref _cancelListChapters);
                if (!_cancelListChapters)
                {
                    AddToChaptersList(chapters);
                }
            }
            catch (Exception ex)
            {
                Common.SetControlPropertyThreadSafe(this, "Visible", true);
                Common.SetControlPropertyThreadSafe(this, "WindowState", FormWindowState.Normal);
                string strex = ex.Message + "\r\n\r\n" + ex.StackTrace;
                Common.MessageBoxThreadSafe(this, strex, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Common.SetControlPropertyThreadSafe(progressList, "Style", ProgressBarStyle.Blocks);
                Common.SetControlPropertyThreadSafe(btnListChapters, "Enabled", true);
            }
        }

        private void StartDownloadThread()
        {
            try
            {
                Common.SetControlPropertyThreadSafe(btnStartDownload, "Enabled", false);
                Common.SetControlPropertyThreadSafe(btnSelectDirectory, "Enabled", false);
                while (lbQueue.Items.Count > 0 && !_cancelStartDownload)
                {
                    Chapter li = (Chapter)lbQueue.Items[0];
                    string saveToFolder = txtSaveTo.Text + "\\" + li.Name
                        .Replace("\\", "").Replace("/", "").Replace(":", "")
                        .Replace("*", "").Replace("?", "").Replace("\"", "")
                        .Replace("<", "").Replace(">", "").Replace("|", "");
                    Directory.CreateDirectory(saveToFolder);
                    Common.SetControlPropertyThreadSafe(progressDownload, "Style", ProgressBarStyle.Marquee);
                    List<string> images = Manga.ListImagesFromChapter(li.Value, 10, ref _cancelStartDownload);
                    if (_cancelStartDownload) { break; }
                    Common.SetControlPropertyThreadSafe(progressDownload, "Style", ProgressBarStyle.Blocks);
                    Common.SetControlPropertyThreadSafe(progressDownload, "Maximum", images.Count);
                    Common.SetControlPropertyThreadSafe(progressDownload, "Value", 0);
                    int imageDownloadedCount = 0;
                    foreach (string imageURL in images)
                    {
                        Common.DownloadImage(imageURL, saveToFolder, 10, ref _cancelStartDownload);
                        if (_cancelStartDownload) { break; }
                        imageDownloadedCount++;
                        Common.SetControlPropertyThreadSafe(progressDownload, "Value", imageDownloadedCount);
                    }
                    if (!_cancelStartDownload)
                    {
                        RemoveFromQueueList(li);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.SetControlPropertyThreadSafe(this, "Visible", true);
                Common.SetControlPropertyThreadSafe(this, "WindowState", FormWindowState.Normal);
                string strex = ex.Message + "\r\n\r\n" + ex.StackTrace;
                Common.MessageBoxThreadSafe(this, strex, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Common.SetControlPropertyThreadSafe(progressDownload, "Style", ProgressBarStyle.Blocks);
                Common.SetControlPropertyThreadSafe(btnSelectDirectory, "Enabled", true);
                Common.SetControlPropertyThreadSafe(btnStartDownload, "Enabled", true);
            }
        }

        private void ListChapters_Click(object sender, EventArgs e)
        {
            lbChapters.Items.Clear();
            _cancelListChapters = false;
            thListChapters = new Thread(ListChaptersThread);
            thListChapters.IsBackground = true;
            thListChapters.SetApartmentState(ApartmentState.STA);
            thListChapters.Start();
        }

        private void StartDownload_Click(object sender, EventArgs e)
        {
            if (lbQueue.Items.Count == 0)
            {
                MessageBox.Show("Please select some chapters to download.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((thDownload != null && !thDownload.IsAlive) || thDownload == null)
            {
                _cancelStartDownload = false;
                thDownload = new Thread(StartDownloadThread);
                thDownload.IsBackground = true;
                thDownload.SetApartmentState(ApartmentState.STA);
                thDownload.Start();
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            _cancelStartDownload = true;
            _cancelListChapters = true;
        }

        private void AddSelected_Click(object sender, EventArgs e)
        {
            int ic = lbQueue.Items.Count;
            foreach (Chapter item in lbChapters.SelectedItems)
            {
                if (lbQueue.FindStringExact(item.Name) == ListBox.NoMatches)
                {
                    lbQueue.Items.Insert(ic, item);
                }
            }
        }

        private void AddAll_Click(object sender, EventArgs e)
        {
            int ic = lbQueue.Items.Count;
            foreach (Chapter item in lbChapters.Items)
            {
                if (lbQueue.FindStringExact(item.Name) == ListBox.NoMatches)
                {
                    lbQueue.Items.Insert(ic, item);
                }
            }
        }

        private void RemoveSelected_Click(object sender, EventArgs e)
        {
            List<Chapter> li = new List<Chapter>();
            for (int i = 0; i < lbQueue.SelectedItems.Count; i++)
            {
                if (lbQueue.SelectedItems[i] == lbQueue.Items[0] && thDownload != null && thDownload.IsAlive)
                    continue;
                li.Add((Chapter)lbQueue.SelectedItems[i]);
            }

            for (int y = 0; y < li.Count; y++)
            {
                lbQueue.Items.Remove(li[y]);
            }
        }

        private void RemoveAll_Click(object sender, EventArgs e)
        {
            List<Chapter> li = new List<Chapter>();
            for (int i = 0; i < lbQueue.Items.Count; i++)
            {
                if (i == 0 && thDownload != null && thDownload.IsAlive)
                    continue;
                li.Add((Chapter)lbQueue.Items[i]);
            }
            for (int y = 0; y < li.Count; y++)
            {
                lbQueue.Items.Remove(li[y]);
            }
        }

        private void SelectDirectory_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                txtSaveTo.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog(this);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cancelStartDownload = true;
            _cancelListChapters = true;
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void OpenWebsite_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Manga.WebAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cannot find default browser to open website!", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}