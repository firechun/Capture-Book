using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 网上抓书
{
    public partial class MainForm : Form
    {
        enum ActionType
        {
            Open,
            Capture
        }
        ActionType action;

        List<Article> articles;
        string title;
        bool createNewFile = true;
        int startIndex = 0;
        bool isStop = false;
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrl.Text))
            {
                MessageBox.Show("请输入网址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtFolder.Text))
            {
                txtFolder.Text = @"d:\";
                //MessageBox.Show("请输入存放目录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
            }
            action = ActionType.Open;
            startIndex = 0;
            backgroundWorker.RunWorkerAsync();
            //articles = new List<Article>();
            //articles.Add(
            //    new Article
            //    {
            //        Url = "https://wap.43xs.com/read/120/120676/25358570.html",
            //        Name = "0"
            //    }
            //);
            //for (int i = 2; i <= 191; i++)
            //{
            //    articles.Add(new Article
            //    {
            //        Url = $"https://wap.43xs.com/read/120/120676/25358570_{i}.html",
            //        Name = i.ToString()
            //    });
            //}
            //foreach (var article in articles)
            //{
            //    lvwArticle.Items.Add(new ListViewItem(new string[] { article.Name, article.Url, "" }));
            //}

        }

        private void OpenHtml()
        {
            Cursor = Cursors.WaitCursor;
            lvwArticle.Items.Clear();
            articles = new List<Article>();
            progressBar.Value = 0;
            lblInfo.Text = "0 / 0";
            try
            {
                var htmlDoc = LoadHtml(txtUrl.Text, Encoding.Default);
                //查找书名
                title = htmlDoc.DocumentNode.Descendants("td")
                    .First(n => n.Attributes["class"] != null && n.Attributes["class"].Value == "lookmc")
                    .InnerText.Trim();
                title = title.Replace("*", "-");
                lblTitle.Text = title;
                var nodes = htmlDoc.DocumentNode.Descendants("table")
                    .FirstOrDefault(n => n.Attributes["class"] != null && n.Attributes["class"].Value == "mread")
                    .Descendants("td");
                int index = 1;
                foreach (var node in nodes)
                {
                    var baiNode = node.Descendants("div")
                        .FirstOrDefault(n => n.Attributes["class"] != null && n.Attributes["class"].Value == "bai");
                    if (baiNode != null)
                    {
                        var article = new Article
                        {
                            Url = baiNode.ChildNodes["a"].Attributes["href"].Value,
                            Name = baiNode.InnerText,
                            Index = index
                        };
                        articles.Add(article);
                        //lvwArticle.Items.Add(new ListViewItem(new string[] { baiNode.InnerText, url }));
                        var duNode = node.Descendants("div")
                            .FirstOrDefault(n => n.Attributes["class"] != null && n.Attributes["class"].Value == "du");
                        if (duNode != null && duNode.HasChildNodes)
                        {
                            article = new Article
                            {
                                Url = duNode.ChildNodes["a"].Attributes["href"].Value,
                                Name = duNode.InnerText,
                                Index = index + 4
                            };
                            articles.Add(article);
                            //lvwArticle.Items.Add(new ListViewItem(new string[] { baiNode.InnerText, url }));
                        }
                        index++;
                        if ((index - 1) % 4 == 0) index += 4;
                    }
                }
                articles.Sort();
                foreach (var article in articles)
                {
                    lvwArticle.Items.Add(new ListViewItem(new string[] { article.Name, article.Url, "" }));
                }
                lblInfo.Text = $"0 / {articles.Count}";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }



        private void btnGet_Click(object sender, EventArgs e)
        {
            action = ActionType.Capture;
            createNewFile = true;
            startIndex = 0;
            btnContinue.Enabled = false;
            backgroundWorker.RunWorkerAsync();
        }
        //private void CaptureContent()
        //{
        //    Cursor = Cursors.WaitCursor;
        //    progressBar.Maximum = articles.Count;
        //    string path = txtFolder.Text.EndsWith(@"\") ? txtFolder.Text : txtFolder.Text + @"\";

        //    for (int i = 0; i < articles.Count; i++)
        //    {
        //        progressBar.Value = i + 1;
        //        lblInfo.Text = $"{i + 1} / {articles.Count}";
        //        lblInfo.Refresh();
        //        string filename = $"{path}{articles[i].Name}.txt";
        //        filename = filename.Replace("?", "？").Replace("/", "-");
        //        if (File.Exists(filename))
        //        {
        //            File.Delete(filename);
        //        }
        //        StreamWriter mySw = File.CreateText(filename);
        //        var htmlDoc = LoadHtml(articles[i].Url, Encoding.GetEncoding("gbk"));
        //        var node = htmlDoc.DocumentNode.Descendants("div")
        //            .FirstOrDefault(n => n.HasClass("p120676p"));
        //        var content = node.InnerHtml.Replace("&nbsp;", " ").Replace("<br>", "\r\n").Replace("\n\t\t\t", "");
        //        mySw.WriteLine(content);
        //        mySw.Close();
        //    }
        //    Cursor = Cursors.Default;
        //}

        //抓书-妈妈小说网 http://www.momxs.com/
        private void CaptureContent()
        {
            Cursor = Cursors.WaitCursor;
            progressBar.Maximum = articles.Count;
            if (!Directory.Exists(txtFolder.Text))
            {
                Directory.CreateDirectory(txtFolder.Text);
            }
            string path = txtFolder.Text.EndsWith(@"\") ? txtFolder.Text : txtFolder.Text + @"\";
            string filename = $"{path}{title}.txt";
            var keySet = new HashSet<string>();
            if (createNewFile)
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }
            StreamWriter mySw = File.AppendText(filename);
            var keys = new List<string>();
            int i = startIndex;
            for (; i < articles.Count; i++)
            {
                if (isStop)
                {
                    break;
                }
                try
                {
                    var htmlDoc = LoadHtml(articles[i].Url, Encoding.Default);
                    //重新获取不缺字的标题
                    var title = htmlDoc.DocumentNode.Descendants("td")
                        .FirstOrDefault(n => n.HasClass("max"))
                        .ChildNodes["font"].ChildNodes["strong"].InnerHtml;
                    articles[i].Name = title;
                    var node = htmlDoc.DocumentNode.Descendants("td")
                        .FirstOrDefault(n => n.HasClass("content"));
                    if (node == null)
                    {
                        node = htmlDoc.DocumentNode.Descendants("td")
                        .FirstOrDefault(n => n.HasClass("contant"));
                    }
                    var content = node.InnerHtml;
                    var imgNodes = node.Descendants("img");
                    var imgSet = new List<string>();
                    //用文字替换掉网页上对应的图片
                    foreach (var img in imgNodes)
                    {
                        if (imgSet.Contains(img.OuterHtml))
                        {
                            continue;
                        }
                        var src = img.Attributes["src"].Value;
                        var key = src.Substring(src.LastIndexOf("/") + 1);
                        if (ImageToText.Words.ContainsKey(key))
                        {
                            content = content.Replace(img.OuterHtml, ImageToText.Words[key]);
                        }
                        else
                        {
                            keySet.Add(key);
                        }
                        imgSet.Add(img.OuterHtml);
                    }
                    //获取内容中脚本的内容
                    var scriptNodes = node.Elements("script");
                    foreach (var scriptNode in scriptNodes)
                    {
                        var src = scriptNode.Attributes["src"].Value;
                        if (!string.IsNullOrEmpty(src))
                        {
                            var host = new Uri(articles[i].Url).Host;
                            var script = HttpUtil.GetWebContent("http://" + host + src, Encoding.Default);
                            if (!string.IsNullOrEmpty(script))
                            {
                                var text = script.Substring(script.IndexOf("\"") + 1, script.LastIndexOf("\"") - script.IndexOf("\"") - 1);
                                content = content.Replace(scriptNode.OuterHtml, text);
                            }
                        }
                    }
                    //去掉内容中的链接水印
                    var aNode = node.Element("a");
                    if (aNode != null)
                    {
                        content = content.Replace($"<{aNode.OuterHtml}>", "");
                    }
                    content = content.Replace("&nbsp;", " ").Replace("&quot;", "\"").Replace("<br>", "\r\n");
                    content = content.Replace("\r\n\r\n", "\r\n");
                    //整理章节名称
                    if (chkAddSection.Checked)
                    {
                        mySw.WriteLine($"第{i + 1}章 {articles[i].Name}");
                    }
                    else if (chkEditSection.Checked)
                    {
                        mySw.WriteLine(MakeSectionName(articles[i].Name));
                    }
                    else
                    {
                        mySw.WriteLine(articles[i].Name);
                    }
                    mySw.WriteLine(content);
                    lvwArticle.Items[i].SubItems[2].Text = "下载成功";
                    lvwArticle.Items[i].EnsureVisible();
                    progressBar.Value = i + 1;
                    lblInfo.Text = $"{i + 1} / {articles.Count}";
                    lblInfo.Refresh();
                }
                catch (Exception ex)
                {
                    lvwArticle.Items[i].SubItems[2].Text = $"失败-{ex.Message}";
                    if (rdoCancel.Checked)
                    {
                        startIndex = i;
                        btnContinue.Enabled = true;
                        break;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            mySw.Close();
            if (keySet.Count > 0)
            {
                StreamWriter keyFile = File.AppendText($"{path}{title}-未替换的图片.txt");
                foreach (string key in keySet)
                {
                    keyFile.WriteLine(key);
                }
                keyFile.Close();
                MessageBox.Show("有图片没有被替换！");
            }
            if (i == articles.Count - 1)
            {
                btnContinue.Enabled = false;
            }
            Cursor = Cursors.Default;
        }

        private HtmlAgilityPack.HtmlDocument LoadHtml(string url,Encoding encoding)
        {
            var html = HttpUtil.GetWebContent(url, Encoding.Default);
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = dialog.SelectedPath;
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            btnStart.Enabled = btnGet.Enabled = false;
            isStop = false;
            if (action == ActionType.Open)
            {
                OpenHtml();
                if (chkAuto.Checked)
                {
                    CaptureContent();
                }
            }
            else if (action == ActionType.Capture)
            {
                CaptureContent();
            }
        }

        private void chkAddSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddSection.Checked)
            {
                chkEditSection.Checked = false;
            }
        }

        private void chkEditSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditSection.Checked)
            {
                chkAddSection.Checked = false;
            }
        }

        private string MakeSectionName(string name)
        {
            if (int.TryParse(name, out int result))
            {
                name = $"第{name}章";
            }
            else
            {
                if (name[0] < '0' || name[0] > '9')
                {
                    return name;
                }
                for(int i = 0; i < name.Length; i++)
                {
                    if(name[i]<'0' || name[i] > '9')
                    {
                        name = name.Insert(i, "章 ");
                        name = "第" + name;
                        break;
                    }
                }
            }
            return name;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStart.Enabled = btnGet.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isStop = true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            action = ActionType.Capture;
            createNewFile = false;
            btnContinue.Enabled = false;
            backgroundWorker.RunWorkerAsync();
        }


        private void txtUrl_Click(object sender, EventArgs e)
        {
            txtUrl.SelectAll();
        }

    }
}
