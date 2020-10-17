namespace 综合保障中心.其它
{
    partial class FormYijie
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置入库日期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取入库单IDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模拟ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // webBrowser
            // 
            this.webBrowser.ContextMenuStrip = this.contextMenuStrip1;
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(672, 502);
            this.webBrowser.TabIndex = 2;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "网址:";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUrl.Location = new System.Drawing.Point(51, 33);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(624, 21);
            this.textBoxUrl.TabIndex = 4;
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.Location = new System.Drawing.Point(691, 31);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 5;
            this.buttonGo.Text = "前  往";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.前往ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser);
            this.splitContainer1.Size = new System.Drawing.Size(775, 502);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.TabIndex = 6;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(99, 502);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置入库日期ToolStripMenuItem,
            this.获取入库单IDToolStripMenuItem,
            this.模拟ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置入库日期ToolStripMenuItem
            // 
            this.设置入库日期ToolStripMenuItem.Name = "设置入库日期ToolStripMenuItem";
            this.设置入库日期ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.设置入库日期ToolStripMenuItem.Text = "设置入库日期";
            this.设置入库日期ToolStripMenuItem.Click += new System.EventHandler(this.设置入库日期ToolStripMenuItem_Click);
            // 
            // 获取入库单IDToolStripMenuItem
            // 
            this.获取入库单IDToolStripMenuItem.Name = "获取入库单IDToolStripMenuItem";
            this.获取入库单IDToolStripMenuItem.Size = new System.Drawing.Size(93, 21);
            this.获取入库单IDToolStripMenuItem.Text = "获取入库单ID";
            this.获取入库单IDToolStripMenuItem.Click += new System.EventHandler(this.获取入库单IDToolStripMenuItem_Click);
            // 
            // 模拟ToolStripMenuItem
            // 
            this.模拟ToolStripMenuItem.Name = "模拟ToolStripMenuItem";
            this.模拟ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.模拟ToolStripMenuItem.Text = "模拟";
            this.模拟ToolStripMenuItem.Click += new System.EventHandler(this.模拟ToolStripMenuItem_Click);
            // 
            // ddToolStripMenuItem
            // 
            this.ddToolStripMenuItem.Name = "ddToolStripMenuItem";
            this.ddToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ddToolStripMenuItem.Text = "dd";
            // 
            // FormYijie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 565);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormYijie";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "易捷按钮破解";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormYijiePojie_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置入库日期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取入库单IDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模拟ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ddToolStripMenuItem;
    }
}