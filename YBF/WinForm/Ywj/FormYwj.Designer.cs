namespace YBF.WinForm.Ywj
{
    partial class FormYwj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormYwj));
            this.contextMenuStripYwj = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaiChu = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewYwj = new System.Windows.Forms.ListView();
            this.columnHeaderWjm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRiqi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListFileImage = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripYwj.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripYwj
            // 
            this.contextMenuStripYwj.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetting,
            this.tsmiRefresh,
            this.tsmiCopy,
            this.tsmiPaiChu});
            this.contextMenuStripYwj.Name = "contextMenuStripYwj";
            this.contextMenuStripYwj.Size = new System.Drawing.Size(113, 92);
            // 
            // tsmiSetting
            // 
            this.tsmiSetting.Name = "tsmiSetting";
            this.tsmiSetting.Size = new System.Drawing.Size(112, 22);
            this.tsmiSetting.Text = "设置";
            this.tsmiSetting.Click += new System.EventHandler(this.tsmiSetting_Click);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(112, 22);
            this.tsmiRefresh.Text = "刷新(&R)";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(112, 22);
            this.tsmiCopy.Text = "拷贝";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiPaiChu
            // 
            this.tsmiPaiChu.Name = "tsmiPaiChu";
            this.tsmiPaiChu.Size = new System.Drawing.Size(112, 22);
            this.tsmiPaiChu.Text = "排除";
            this.tsmiPaiChu.Click += new System.EventHandler(this.tsmiPaiChu_Click);
            // 
            // listViewYwj
            // 
            this.listViewYwj.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderWjm,
            this.columnHeaderRiqi,
            this.columnHeaderSize,
            this.columnHeaderName});
            this.listViewYwj.ContextMenuStrip = this.contextMenuStripYwj;
            this.listViewYwj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewYwj.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewYwj.LargeImageList = this.imageListFileImage;
            this.listViewYwj.Location = new System.Drawing.Point(0, 0);
            this.listViewYwj.Name = "listViewYwj";
            this.listViewYwj.Size = new System.Drawing.Size(632, 528);
            this.listViewYwj.SmallImageList = this.imageListFileImage;
            this.listViewYwj.StateImageList = this.imageListFileImage;
            this.listViewYwj.TabIndex = 0;
            this.listViewYwj.UseCompatibleStateImageBehavior = false;
            this.listViewYwj.View = System.Windows.Forms.View.Details;
            this.listViewYwj.ItemActivate += new System.EventHandler(this.listViewYwj_ItemActivate);
            // 
            // columnHeaderWjm
            // 
            this.columnHeaderWjm.Text = "文件名称";
            this.columnHeaderWjm.Width = 313;
            // 
            // columnHeaderRiqi
            // 
            this.columnHeaderRiqi.Text = "最后修改日期";
            this.columnHeaderRiqi.Width = 140;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "大小";
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "CTP";
            // 
            // imageListFileImage
            // 
            this.imageListFileImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFileImage.ImageStream")));
            this.imageListFileImage.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFileImage.Images.SetKeyName(0, "cdrx4");
            // 
            // FormYwj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 528);
            this.Controls.Add(this.listViewYwj);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormYwj";
            this.ShowIcon = false;
            this.Text = "源文件";
            this.Load += new System.EventHandler(this.FormYwj_Load);
            this.contextMenuStripYwj.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewYwj;
        private System.Windows.Forms.ColumnHeader columnHeaderWjm;
        private System.Windows.Forms.ColumnHeader columnHeaderRiqi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripYwj;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetting;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaiChu;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ImageList imageListFileImage;
    }
}