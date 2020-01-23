namespace YBF.WinForm.Ywj
{
    partial class FormYwjInformation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxYwjPath = new System.Windows.Forms.TextBox();
            this.textBoxYwjPathMove = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "源文件所在目录：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "拷贝后移动的目录：";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(398, 21);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxYwjPath
            // 
            this.textBoxYwjPath.Location = new System.Drawing.Point(10, 74);
            this.textBoxYwjPath.Multiline = true;
            this.textBoxYwjPath.Name = "textBoxYwjPath";
            this.textBoxYwjPath.Size = new System.Drawing.Size(400, 55);
            this.textBoxYwjPath.TabIndex = 1;
            this.textBoxYwjPath.DoubleClick += new System.EventHandler(this.textBoxYwjPath_DoubleClick);
            // 
            // textBoxYwjPathMove
            // 
            this.textBoxYwjPathMove.Location = new System.Drawing.Point(10, 159);
            this.textBoxYwjPathMove.Multiline = true;
            this.textBoxYwjPathMove.Name = "textBoxYwjPathMove";
            this.textBoxYwjPathMove.Size = new System.Drawing.Size(400, 55);
            this.textBoxYwjPathMove.TabIndex = 2;
            this.textBoxYwjPathMove.DoubleClick += new System.EventHandler(this.textBoxYwjPathMove_DoubleClick);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(335, 232);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "保  存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(248, 233);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "清  空";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // FormYwjInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 267);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxYwjPathMove);
            this.Controls.Add(this.textBoxYwjPath);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormYwjInformation";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormYwjInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxYwjPath;
        private System.Windows.Forms.TextBox textBoxYwjPathMove;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClear;
    }
}