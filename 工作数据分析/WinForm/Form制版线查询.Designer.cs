namespace 工作数据分析.WinForm
{
    partial class Form制版线查询
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.8米制版线");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2.2米制版线");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("2.5米制版线");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从瓦片线载入数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage当前排程 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tabPage完工查询 = new System.Windows.Forms.TabPage();
            this.button查询 = new System.Windows.Forms.Button();
            this.textBox客户 = new System.Windows.Forms.TextBox();
            this.textBox工单 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPicker_e = new System.Windows.Forms.DateTimePicker();
            this.dtPicker_s = new System.Windows.Forms.DateTimePicker();
            this.dgv_wg = new System.Windows.Forms.DataGridView();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage当前排程.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tabPage完工查询.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_wg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.从瓦片线载入数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.刷新ToolStripMenuItem.Text = "刷新";
            // 
            // 从瓦片线载入数据ToolStripMenuItem
            // 
            this.从瓦片线载入数据ToolStripMenuItem.Name = "从瓦片线载入数据ToolStripMenuItem";
            this.从瓦片线载入数据ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.从瓦片线载入数据ToolStripMenuItem.Text = "从瓦片线载入数据";
            this.从瓦片线载入数据ToolStripMenuItem.Click += new System.EventHandler(this.从瓦片线载入数据ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage当前排程);
            this.tabControl1.Controls.Add(this.tabPage完工查询);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(924, 657);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage当前排程
            // 
            this.tabPage当前排程.Controls.Add(this.splitContainer1);
            this.tabPage当前排程.Location = new System.Drawing.Point(4, 22);
            this.tabPage当前排程.Name = "tabPage当前排程";
            this.tabPage当前排程.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage当前排程.Size = new System.Drawing.Size(916, 631);
            this.tabPage当前排程.TabIndex = 0;
            this.tabPage当前排程.Text = "当前排程";
            this.tabPage当前排程.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(910, 625);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView.ForeColor = System.Drawing.Color.Black;
            this.treeView.Indent = 5;
            this.treeView.ItemHeight = 30;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.Name = "treenode1800";
            treeNode1.Text = "1.8米制版线";
            treeNode2.Name = "treenode2200";
            treeNode2.Text = "2.2米制版线";
            treeNode3.Name = "treenode2500";
            treeNode3.Text = "2.5米制版线";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView.ShowLines = false;
            this.treeView.Size = new System.Drawing.Size(151, 625);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv1);
            this.splitContainer2.Size = new System.Drawing.Size(755, 625);
            this.splitContainer2.SplitterDistance = 442;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(755, 442);
            this.dgv.TabIndex = 0;
            // 
            // tabPage完工查询
            // 
            this.tabPage完工查询.Controls.Add(this.button查询);
            this.tabPage完工查询.Controls.Add(this.textBox客户);
            this.tabPage完工查询.Controls.Add(this.textBox工单);
            this.tabPage完工查询.Controls.Add(this.label4);
            this.tabPage完工查询.Controls.Add(this.label3);
            this.tabPage完工查询.Controls.Add(this.label2);
            this.tabPage完工查询.Controls.Add(this.label1);
            this.tabPage完工查询.Controls.Add(this.dtPicker_e);
            this.tabPage完工查询.Controls.Add(this.dtPicker_s);
            this.tabPage完工查询.Controls.Add(this.dgv_wg);
            this.tabPage完工查询.Location = new System.Drawing.Point(4, 22);
            this.tabPage完工查询.Name = "tabPage完工查询";
            this.tabPage完工查询.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage完工查询.Size = new System.Drawing.Size(916, 631);
            this.tabPage完工查询.TabIndex = 1;
            this.tabPage完工查询.Text = "完工查询";
            this.tabPage完工查询.UseVisualStyleBackColor = true;
            // 
            // button查询
            // 
            this.button查询.Location = new System.Drawing.Point(753, 6);
            this.button查询.Name = "button查询";
            this.button查询.Size = new System.Drawing.Size(75, 23);
            this.button查询.TabIndex = 5;
            this.button查询.Text = "查  询";
            this.button查询.UseVisualStyleBackColor = true;
            this.button查询.Click += new System.EventHandler(this.button查询_Click);
            // 
            // textBox客户
            // 
            this.textBox客户.Location = new System.Drawing.Point(223, 6);
            this.textBox客户.Name = "textBox客户";
            this.textBox客户.Size = new System.Drawing.Size(120, 21);
            this.textBox客户.TabIndex = 4;
            // 
            // textBox工单
            // 
            this.textBox工单.Location = new System.Drawing.Point(50, 6);
            this.textBox工单.Name = "textBox工单";
            this.textBox工单.Size = new System.Drawing.Size(120, 21);
            this.textBox工单.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(553, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "结束时间:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "开始时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "客户:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "工单:";
            // 
            // dtPicker_e
            // 
            this.dtPicker_e.Location = new System.Drawing.Point(618, 6);
            this.dtPicker_e.Name = "dtPicker_e";
            this.dtPicker_e.Size = new System.Drawing.Size(129, 21);
            this.dtPicker_e.TabIndex = 2;
            // 
            // dtPicker_s
            // 
            this.dtPicker_s.Location = new System.Drawing.Point(416, 6);
            this.dtPicker_s.Name = "dtPicker_s";
            this.dtPicker_s.Size = new System.Drawing.Size(129, 21);
            this.dtPicker_s.TabIndex = 2;
            // 
            // dgv_wg
            // 
            this.dgv_wg.AllowUserToAddRows = false;
            this.dgv_wg.AllowUserToDeleteRows = false;
            this.dgv_wg.AllowUserToOrderColumns = true;
            this.dgv_wg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_wg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_wg.Location = new System.Drawing.Point(3, 33);
            this.dgv_wg.Name = "dgv_wg";
            this.dgv_wg.ReadOnly = true;
            this.dgv_wg.RowTemplate.Height = 23;
            this.dgv_wg.Size = new System.Drawing.Size(910, 595);
            this.dgv_wg.TabIndex = 0;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(0, 0);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(755, 179);
            this.dgv1.TabIndex = 1;
            // 
            // Form制版线查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 682);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form制版线查询";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "制版线查询";
            this.Load += new System.EventHandler(this.Form制版线查询_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage当前排程.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tabPage完工查询.ResumeLayout(false);
            this.tabPage完工查询.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_wg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage当前排程;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TabPage tabPage完工查询;
        private System.Windows.Forms.DataGridView dgv_wg;
        private System.Windows.Forms.ToolStripMenuItem 从瓦片线载入数据ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtPicker_e;
        private System.Windows.Forms.TextBox textBox客户;
        private System.Windows.Forms.TextBox textBox工单;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPicker_s;
        private System.Windows.Forms.Button button查询;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgv1;
    }
}