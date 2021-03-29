namespace 网上抓书
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.chkAddSection = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwArticle = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblInfo = new System.Windows.Forms.Label();
            this.chkEditSection = new System.Windows.Forms.CheckBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoTryAgain = new System.Windows.Forms.RadioButton();
            this.rdoCancel = new System.Windows.Forms.RadioButton();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "网址";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(59, 21);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(453, 21);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Click += new System.EventHandler(this.txtUrl_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(518, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "打开";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(599, 21);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 5;
            this.btnGet.Text = "抓取";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 521);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(896, 23);
            this.progressBar.TabIndex = 6;
            // 
            // chkAddSection
            // 
            this.chkAddSection.AutoSize = true;
            this.chkAddSection.Location = new System.Drawing.Point(826, 24);
            this.chkAddSection.Name = "chkAddSection";
            this.chkAddSection.Size = new System.Drawing.Size(84, 16);
            this.chkAddSection.TabIndex = 7;
            this.chkAddSection.Text = "添加章节号";
            this.chkAddSection.UseVisualStyleBackColor = true;
            this.chkAddSection.CheckedChanged += new System.EventHandler(this.chkAddSection_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "目录名";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(59, 55);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(198, 21);
            this.txtFolder.TabIndex = 9;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(263, 53);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(361, 58);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(29, 12);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "书名";
            // 
            // lvwArticle
            // 
            this.lvwArticle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwArticle.HideSelection = false;
            this.lvwArticle.Location = new System.Drawing.Point(14, 110);
            this.lvwArticle.Margin = new System.Windows.Forms.Padding(2);
            this.lvwArticle.Name = "lvwArticle";
            this.lvwArticle.Size = new System.Drawing.Size(897, 393);
            this.lvwArticle.TabIndex = 12;
            this.lvwArticle.UseCompatibleStateImageBehavior = false;
            this.lvwArticle.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 288;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "地址";
            this.columnHeader2.Width = 486;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "状态";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 505);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 12);
            this.lblInfo.TabIndex = 13;
            this.lblInfo.Text = "0 / 0";
            // 
            // chkEditSection
            // 
            this.chkEditSection.AutoSize = true;
            this.chkEditSection.Location = new System.Drawing.Point(826, 56);
            this.chkEditSection.Name = "chkEditSection";
            this.chkEditSection.Size = new System.Drawing.Size(84, 16);
            this.chkEditSection.TabIndex = 14;
            this.chkEditSection.Text = "生成章节号";
            this.chkEditSection.UseVisualStyleBackColor = true;
            this.chkEditSection.CheckedChanged += new System.EventHandler(this.chkEditSection_CheckedChanged);
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(689, 26);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(72, 16);
            this.chkAuto.TabIndex = 15;
            this.chkAuto.Text = "自动抓取";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(599, 53);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 18;
            this.btnContinue.Text = "继续";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoTryAgain);
            this.panel1.Controls.Add(this.rdoCancel);
            this.panel1.Location = new System.Drawing.Point(689, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 57);
            this.panel1.TabIndex = 19;
            // 
            // rdoTryAgain
            // 
            this.rdoTryAgain.AutoSize = true;
            this.rdoTryAgain.Location = new System.Drawing.Point(14, 35);
            this.rdoTryAgain.Name = "rdoTryAgain";
            this.rdoTryAgain.Size = new System.Drawing.Size(83, 16);
            this.rdoTryAgain.TabIndex = 1;
            this.rdoTryAgain.TabStop = true;
            this.rdoTryAgain.Text = "失败再尝试";
            this.rdoTryAgain.UseVisualStyleBackColor = true;
            // 
            // rdoCancel
            // 
            this.rdoCancel.AutoSize = true;
            this.rdoCancel.Checked = true;
            this.rdoCancel.Location = new System.Drawing.Point(14, 13);
            this.rdoCancel.Name = "rdoCancel";
            this.rdoCancel.Size = new System.Drawing.Size(83, 16);
            this.rdoCancel.TabIndex = 0;
            this.rdoCancel.TabStop = true;
            this.rdoCancel.Text = "失败则中止";
            this.rdoCancel.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(518, 54);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 556);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.chkEditSection);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lvwArticle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkAddSection);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "好书屋-http://www.shbdjs.org/";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox chkAddSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwArticle;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.CheckBox chkEditSection;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoTryAgain;
        private System.Windows.Forms.RadioButton rdoCancel;
        private System.Windows.Forms.Button btnStop;
    }
}

