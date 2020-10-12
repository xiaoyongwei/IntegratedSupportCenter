using System.Windows.Forms;
namespace YBF.WinForm
{
    partial class FormJobManager : Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJobManager));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.暂停 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.出版 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.报废 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.稿袋号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.机台 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.文件名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制造尺寸 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.下料尺寸 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.咬口印能捷 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.颜色 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.印版数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.印版类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.关联的文件 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsJob = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiPublished = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiAbolish = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBaofei = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChange = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete_cms = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyJob = new System.Windows.Forms.ToolStripMenuItem();
            this.复制文件名规范ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLimit500 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiToday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi7day = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi1month = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi1year = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChazhao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShuaxin = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeaderWjm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRiqi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsListview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCmm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDingwei = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSubmitToPrinergyEvo = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.cmsJob.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsListview.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.暂停,
            this.出版,
            this.报废,
            this.时间,
            this.工单号,
            this.稿袋号,
            this.机台,
            this.客户名,
            this.文件名,
            this.制造尺寸,
            this.下料尺寸,
            this.咬口印能捷,
            this.颜色,
            this.印版数量,
            this.印版类型,
            this.备注,
            this.关联的文件});
            this.dgv.ContextMenuStrip = this.cmsJob;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(975, 375);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgv_CellStateChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 30;
            // 
            // 暂停
            // 
            this.暂停.DataPropertyName = "暂停";
            this.暂停.FalseValue = "0";
            this.暂停.HeaderText = "暂停";
            this.暂停.IndeterminateValue = "0";
            this.暂停.Name = "暂停";
            this.暂停.ReadOnly = true;
            this.暂停.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.暂停.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.暂停.TrueValue = "1";
            this.暂停.Width = 35;
            // 
            // 出版
            // 
            this.出版.DataPropertyName = "出版";
            this.出版.FalseValue = "0";
            this.出版.HeaderText = "出版";
            this.出版.IndeterminateValue = "0";
            this.出版.Name = "出版";
            this.出版.ReadOnly = true;
            this.出版.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.出版.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.出版.TrueValue = "1";
            this.出版.Width = 35;
            // 
            // 报废
            // 
            this.报废.DataPropertyName = "报废";
            this.报废.FalseValue = "0";
            this.报废.HeaderText = "报废";
            this.报废.IndeterminateValue = "0";
            this.报废.Name = "报废";
            this.报废.ReadOnly = true;
            this.报废.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.报废.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.报废.TrueValue = "1";
            this.报废.Width = 35;
            // 
            // 时间
            // 
            this.时间.DataPropertyName = "时间";
            dataGridViewCellStyle1.Format = "F";
            dataGridViewCellStyle1.NullValue = null;
            this.时间.DefaultCellStyle = dataGridViewCellStyle1;
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.ReadOnly = true;
            // 
            // 工单号
            // 
            this.工单号.DataPropertyName = "工单号";
            this.工单号.HeaderText = "工单号";
            this.工单号.Name = "工单号";
            this.工单号.ReadOnly = true;
            this.工单号.Visible = false;
            // 
            // 稿袋号
            // 
            this.稿袋号.DataPropertyName = "稿袋号";
            this.稿袋号.HeaderText = "稿袋号";
            this.稿袋号.Name = "稿袋号";
            this.稿袋号.ReadOnly = true;
            // 
            // 机台
            // 
            this.机台.DataPropertyName = "机台";
            this.机台.HeaderText = "机台";
            this.机台.Name = "机台";
            this.机台.ReadOnly = true;
            // 
            // 客户名
            // 
            this.客户名.DataPropertyName = "客户名";
            this.客户名.HeaderText = "客户名";
            this.客户名.Name = "客户名";
            this.客户名.ReadOnly = true;
            // 
            // 文件名
            // 
            this.文件名.HeaderText = "文件名";
            this.文件名.Name = "文件名";
            this.文件名.ReadOnly = true;
            // 
            // 制造尺寸
            // 
            this.制造尺寸.DataPropertyName = "制造尺寸";
            this.制造尺寸.HeaderText = "制造尺寸";
            this.制造尺寸.Name = "制造尺寸";
            this.制造尺寸.ReadOnly = true;
            // 
            // 下料尺寸
            // 
            this.下料尺寸.DataPropertyName = "下料尺寸";
            this.下料尺寸.HeaderText = "下料尺寸";
            this.下料尺寸.Name = "下料尺寸";
            this.下料尺寸.ReadOnly = true;
            // 
            // 咬口印能捷
            // 
            this.咬口印能捷.DataPropertyName = "咬口印能捷";
            this.咬口印能捷.HeaderText = "咬口印能捷";
            this.咬口印能捷.Name = "咬口印能捷";
            this.咬口印能捷.ReadOnly = true;
            // 
            // 颜色
            // 
            this.颜色.DataPropertyName = "颜色";
            this.颜色.HeaderText = "颜色";
            this.颜色.Name = "颜色";
            this.颜色.ReadOnly = true;
            // 
            // 印版数量
            // 
            this.印版数量.DataPropertyName = "印版数量";
            this.印版数量.HeaderText = "印版数量";
            this.印版数量.Name = "印版数量";
            this.印版数量.ReadOnly = true;
            // 
            // 印版类型
            // 
            this.印版类型.DataPropertyName = "印版类型";
            this.印版类型.HeaderText = "印版类型";
            this.印版类型.Name = "印版类型";
            this.印版类型.ReadOnly = true;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "备注";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.ReadOnly = true;
            // 
            // 关联的文件
            // 
            this.关联的文件.DataPropertyName = "关联的文件";
            this.关联的文件.HeaderText = "关联的文件";
            this.关联的文件.Name = "关联的文件";
            this.关联的文件.ReadOnly = true;
            this.关联的文件.Visible = false;
            // 
            // cmsJob
            // 
            this.cmsJob.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPublished,
            this.tmsiAbolish,
            this.tsmiBaofei,
            this.tsmiChange,
            this.tsmiDelete_cms,
            this.tsmiCopyJob,
            this.复制文件名规范ToolStripMenuItem});
            this.cmsJob.Name = "cmsJob";
            this.cmsJob.Size = new System.Drawing.Size(166, 158);
            // 
            // tsmiPublished
            // 
            this.tsmiPublished.Name = "tsmiPublished";
            this.tsmiPublished.Size = new System.Drawing.Size(165, 22);
            this.tsmiPublished.Text = "标记为[出版]";
            this.tsmiPublished.Click += new System.EventHandler(this.tsmiPublished_Click);
            // 
            // tmsiAbolish
            // 
            this.tmsiAbolish.Name = "tmsiAbolish";
            this.tmsiAbolish.Size = new System.Drawing.Size(165, 22);
            this.tmsiAbolish.Text = "标记为[暂停]";
            this.tmsiAbolish.Click += new System.EventHandler(this.tmsiAbolish_Click);
            // 
            // tsmiBaofei
            // 
            this.tsmiBaofei.Name = "tsmiBaofei";
            this.tsmiBaofei.Size = new System.Drawing.Size(165, 22);
            this.tsmiBaofei.Text = "报废";
            this.tsmiBaofei.Click += new System.EventHandler(this.tsmiBaofei_Click);
            // 
            // tsmiChange
            // 
            this.tsmiChange.Name = "tsmiChange";
            this.tsmiChange.Size = new System.Drawing.Size(165, 22);
            this.tsmiChange.Text = "修改";
            this.tsmiChange.Click += new System.EventHandler(this.tsmiChange_Click);
            // 
            // tsmiDelete_cms
            // 
            this.tsmiDelete_cms.Name = "tsmiDelete_cms";
            this.tsmiDelete_cms.Size = new System.Drawing.Size(165, 22);
            this.tsmiDelete_cms.Text = "删除";
            this.tsmiDelete_cms.Click += new System.EventHandler(this.tsmiDelete_cms_Click);
            // 
            // tsmiCopyJob
            // 
            this.tsmiCopyJob.Name = "tsmiCopyJob";
            this.tsmiCopyJob.Size = new System.Drawing.Size(165, 22);
            this.tsmiCopyJob.Text = "复制并修改";
            this.tsmiCopyJob.Click += new System.EventHandler(this.tsmiCopyJob_Click);
            // 
            // 复制文件名规范ToolStripMenuItem
            // 
            this.复制文件名规范ToolStripMenuItem.Name = "复制文件名规范ToolStripMenuItem";
            this.复制文件名规范ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.复制文件名规范ToolStripMenuItem.Text = "复制_文件名规范";
            this.复制文件名规范ToolStripMenuItem.Click += new System.EventHandler(this.复制文件名规范ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiUpdate,
            this.tsmiDelete,
            this.tsmiShow,
            this.tsmiChazhao,
            this.tsmiShuaxin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAdd.Image")));
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmiAdd.Size = new System.Drawing.Size(81, 21);
            this.tsmiAdd.Text = "添加(F2)";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(44, 21);
            this.tsmiUpdate.Text = "修改";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(44, 21);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiShow
            // 
            this.tsmiShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLimit500,
            this.tsmiToday,
            this.tsmi7day,
            this.tsmi1month,
            this.tsmi1year,
            this.tsmiCustom});
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(44, 21);
            this.tsmiShow.Text = "显示";
            // 
            // tsmiLimit500
            // 
            this.tsmiLimit500.Name = "tsmiLimit500";
            this.tsmiLimit500.Size = new System.Drawing.Size(155, 22);
            this.tsmiLimit500.Text = "最近500项";
            this.tsmiLimit500.Click += new System.EventHandler(this.tsmiToday_Click);
            // 
            // tsmiToday
            // 
            this.tsmiToday.CheckOnClick = true;
            this.tsmiToday.Name = "tsmiToday";
            this.tsmiToday.Size = new System.Drawing.Size(155, 22);
            this.tsmiToday.Text = "当日作业";
            this.tsmiToday.Click += new System.EventHandler(this.tsmiToday_Click);
            // 
            // tsmi7day
            // 
            this.tsmi7day.CheckOnClick = true;
            this.tsmi7day.Name = "tsmi7day";
            this.tsmi7day.Size = new System.Drawing.Size(155, 22);
            this.tsmi7day.Text = "7日内作业";
            this.tsmi7day.Click += new System.EventHandler(this.tsmiToday_Click);
            // 
            // tsmi1month
            // 
            this.tsmi1month.CheckOnClick = true;
            this.tsmi1month.Name = "tsmi1month";
            this.tsmi1month.Size = new System.Drawing.Size(155, 22);
            this.tsmi1month.Text = "30日内作业";
            this.tsmi1month.Click += new System.EventHandler(this.tsmiToday_Click);
            // 
            // tsmi1year
            // 
            this.tsmi1year.CheckOnClick = true;
            this.tsmi1year.Name = "tsmi1year";
            this.tsmi1year.Size = new System.Drawing.Size(155, 22);
            this.tsmi1year.Text = "1年内作业";
            this.tsmi1year.Click += new System.EventHandler(this.tsmiToday_Click);
            // 
            // tsmiCustom
            // 
            this.tsmiCustom.CheckOnClick = true;
            this.tsmiCustom.Name = "tsmiCustom";
            this.tsmiCustom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiCustom.Size = new System.Drawing.Size(155, 22);
            this.tsmiCustom.Text = "自定义";
            this.tsmiCustom.Click += new System.EventHandler(this.tsmiToday_Click);
            // 
            // tsmiChazhao
            // 
            this.tsmiChazhao.Image = ((System.Drawing.Image)(resources.GetObject("tsmiChazhao.Image")));
            this.tsmiChazhao.Name = "tsmiChazhao";
            this.tsmiChazhao.Size = new System.Drawing.Size(60, 21);
            this.tsmiChazhao.Text = "查找";
            this.tsmiChazhao.Click += new System.EventHandler(this.tsmiChazhao_Click);
            // 
            // tsmiShuaxin
            // 
            this.tsmiShuaxin.Name = "tsmiShuaxin";
            this.tsmiShuaxin.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmiShuaxin.Size = new System.Drawing.Size(65, 21);
            this.tsmiShuaxin.Text = "刷新(F5)";
            this.tsmiShuaxin.Click += new System.EventHandler(this.tsmiShuaxin_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewFile);
            this.splitContainer1.Size = new System.Drawing.Size(975, 490);
            this.splitContainer1.SplitterDistance = 375;
            this.splitContainer1.TabIndex = 2;
            // 
            // listViewFile
            // 
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderWjm,
            this.columnHeaderRiqi,
            this.columnHeaderSize,
            this.columnHeaderPath});
            this.listViewFile.ContextMenuStrip = this.cmsListview;
            this.listViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFile.FullRowSelect = true;
            this.listViewFile.GridLines = true;
            this.listViewFile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewFile.HideSelection = false;
            this.listViewFile.Location = new System.Drawing.Point(0, 0);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(975, 111);
            this.listViewFile.TabIndex = 1;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewFile_AfterLabelEdit);
            this.listViewFile.ItemActivate += new System.EventHandler(this.listViewFile_ItemActivate);
            this.listViewFile.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewFile_ItemDrag);
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
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "所在目录";
            // 
            // cmsListview
            // 
            this.cmsListview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCmm,
            this.tsmiAddFile,
            this.tsmiDingwei,
            this.tsmiOpen,
            this.tsmiSubmitToPrinergyEvo});
            this.cmsListview.Name = "cmsListview";
            this.cmsListview.Size = new System.Drawing.Size(161, 114);
            // 
            // tsmiCmm
            // 
            this.tsmiCmm.Name = "tsmiCmm";
            this.tsmiCmm.Size = new System.Drawing.Size(160, 22);
            this.tsmiCmm.Text = "重命名";
            this.tsmiCmm.Visible = false;
            this.tsmiCmm.Click += new System.EventHandler(this.tsmiCmm_Click);
            // 
            // tsmiAddFile
            // 
            this.tsmiAddFile.Name = "tsmiAddFile";
            this.tsmiAddFile.Size = new System.Drawing.Size(160, 22);
            this.tsmiAddFile.Text = "关联文件";
            this.tsmiAddFile.Click += new System.EventHandler(this.tsmiAddFile_Click);
            // 
            // tsmiDingwei
            // 
            this.tsmiDingwei.Name = "tsmiDingwei";
            this.tsmiDingwei.Size = new System.Drawing.Size(160, 22);
            this.tsmiDingwei.Text = "定位";
            this.tsmiDingwei.Click += new System.EventHandler(this.tsmiDingwei_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(160, 22);
            this.tsmiOpen.Text = "打开";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiSubmitToPrinergyEvo
            // 
            this.tsmiSubmitToPrinergyEvo.Name = "tsmiSubmitToPrinergyEvo";
            this.tsmiSubmitToPrinergyEvo.Size = new System.Drawing.Size(160, 22);
            this.tsmiSubmitToPrinergyEvo.Text = "直接提交到出版";
            this.tsmiSubmitToPrinergyEvo.Click += new System.EventHandler(this.tsmiSubmitToPrinergyEvo_Click);
            // 
            // FormJobManager
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 515);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormJobManager";
            this.ShowIcon = false;
            this.Text = "出版作业管理";
            this.Load += new System.EventHandler(this.FormJobManager_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormJobAdd_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormJobAdd_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.cmsJob.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cmsListview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ColumnHeader columnHeaderWjm;
        private System.Windows.Forms.ColumnHeader columnHeaderRiqi;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.ContextMenuStrip cmsListview;
        private System.Windows.Forms.ToolStripMenuItem tsmiCmm;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiToday;
        private System.Windows.Forms.ToolStripMenuItem tsmi7day;
        private System.Windows.Forms.ToolStripMenuItem tsmi1month;
        private System.Windows.Forms.ToolStripMenuItem tsmi1year;
        private System.Windows.Forms.ToolStripMenuItem tsmiCustom;
        private System.Windows.Forms.ToolStripMenuItem tsmiLimit500;
        private System.Windows.Forms.ContextMenuStrip cmsJob;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublished;
        private System.Windows.Forms.ToolStripMenuItem tmsiAbolish;
        private System.Windows.Forms.ToolStripMenuItem tsmiBaofei;
        private System.Windows.Forms.ToolStripMenuItem tsmiChange;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete_cms;
        private ToolStripMenuItem tsmiShuaxin;
        private ToolStripMenuItem tsmiDingwei;
        private ToolStripMenuItem tsmiCopyJob;
        private ToolStripMenuItem tsmiOpen;
        private ToolStripMenuItem tsmiSubmitToPrinergyEvo;
        private ToolStripMenuItem tsmiChazhao;
        private ToolStripMenuItem 复制文件名规范ToolStripMenuItem;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewCheckBoxColumn 暂停;
        private DataGridViewCheckBoxColumn 出版;
        private DataGridViewCheckBoxColumn 报废;
        private DataGridViewTextBoxColumn 时间;
        private DataGridViewTextBoxColumn 工单号;
        private DataGridViewTextBoxColumn 稿袋号;
        private DataGridViewTextBoxColumn 机台;
        private DataGridViewTextBoxColumn 客户名;
        private DataGridViewTextBoxColumn 文件名;
        private DataGridViewTextBoxColumn 制造尺寸;
        private DataGridViewTextBoxColumn 下料尺寸;
        private DataGridViewTextBoxColumn 咬口印能捷;
        private DataGridViewTextBoxColumn 颜色;
        private DataGridViewTextBoxColumn 印版数量;
        private DataGridViewTextBoxColumn 印版类型;
        private DataGridViewTextBoxColumn 备注;
        private DataGridViewTextBoxColumn 关联的文件;
    }
}