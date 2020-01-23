namespace YBF.WinForm.Ywj
{
    partial class FormQQFileRecv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQQFileRecv));
            this.listViewYwj = new System.Windows.Forms.ListView();
            this.columnHeaderWjm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRiqi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAiToPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShuaXin = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListFileImage = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewYwj
            // 
            this.listViewYwj.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderWjm,
            this.columnHeaderRiqi,
            this.columnHeaderSize});
            this.listViewYwj.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewYwj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewYwj.GridLines = true;
            this.listViewYwj.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewYwj.LargeImageList = this.imageListFileImage;
            this.listViewYwj.Location = new System.Drawing.Point(0, 0);
            this.listViewYwj.Name = "listViewYwj";
            this.listViewYwj.Size = new System.Drawing.Size(667, 460);
            this.listViewYwj.SmallImageList = this.imageListFileImage;
            this.listViewYwj.StateImageList = this.imageListFileImage;
            this.listViewYwj.TabIndex = 1;
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAiToPdf,
            this.tsmiShuaXin});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // tsmiAiToPdf
            // 
            this.tsmiAiToPdf.Name = "tsmiAiToPdf";
            this.tsmiAiToPdf.Size = new System.Drawing.Size(124, 22);
            this.tsmiAiToPdf.Text = "ai To PDF";
            this.tsmiAiToPdf.Click += new System.EventHandler(this.tsmiAiToPdf_Click);
            // 
            // tsmiShuaXin
            // 
            this.tsmiShuaXin.Name = "tsmiShuaXin";
            this.tsmiShuaXin.Size = new System.Drawing.Size(124, 22);
            this.tsmiShuaXin.Text = "刷新";
            this.tsmiShuaXin.Click += new System.EventHandler(this.tsmiShuaXin_Click);
            // 
            // imageListFileImage
            // 
            this.imageListFileImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFileImage.ImageStream")));
            this.imageListFileImage.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFileImage.Images.SetKeyName(0, "cdrx4");
            // 
            // FormQQFileRecv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 460);
            this.Controls.Add(this.listViewYwj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormQQFileRecv";
            this.ShowIcon = false;
            this.Text = "QQ接受过来的文件";
            this.Load += new System.EventHandler(this.FormQQFileRecv_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewYwj;
        private System.Windows.Forms.ColumnHeader columnHeaderWjm;
        private System.Windows.Forms.ColumnHeader columnHeaderRiqi;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAiToPdf;
        private System.Windows.Forms.ImageList imageListFileImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiShuaXin;
    }
}