namespace 工作数据分析.WinForm.WuLiu.yunfei
{
    partial class Form为客户设置地区
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxKehu = new System.Windows.Forms.TextBox();
            this.comboBoxQuyu = new System.Windows.Forms.ComboBox();
            this.comboBoxMudidi = new System.Windows.Forms.ComboBox();
            this.textBoxKm = new System.Windows.Forms.TextBox();
            this.textBoxDacheYunfei = new System.Windows.Forms.TextBox();
            this.textBoxXiaocheYunfei = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "客户:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "大车运费:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "目的地:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "区域:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "小车运费:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "公里数:";
            // 
            // textBoxKehu
            // 
            this.textBoxKehu.Location = new System.Drawing.Point(79, 19);
            this.textBoxKehu.Name = "textBoxKehu";
            this.textBoxKehu.ReadOnly = true;
            this.textBoxKehu.Size = new System.Drawing.Size(190, 21);
            this.textBoxKehu.TabIndex = 5;
            // 
            // comboBoxQuyu
            // 
            this.comboBoxQuyu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuyu.FormattingEnabled = true;
            this.comboBoxQuyu.Location = new System.Drawing.Point(79, 67);
            this.comboBoxQuyu.Name = "comboBoxQuyu";
            this.comboBoxQuyu.Size = new System.Drawing.Size(190, 20);
            this.comboBoxQuyu.TabIndex = 0;
            this.comboBoxQuyu.TextChanged += new System.EventHandler(this.comboBoxQuyu_TextChanged);
            // 
            // comboBoxMudidi
            // 
            this.comboBoxMudidi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMudidi.FormattingEnabled = true;
            this.comboBoxMudidi.Location = new System.Drawing.Point(79, 114);
            this.comboBoxMudidi.Name = "comboBoxMudidi";
            this.comboBoxMudidi.Size = new System.Drawing.Size(190, 20);
            this.comboBoxMudidi.TabIndex = 0;
            this.comboBoxMudidi.TextChanged += new System.EventHandler(this.comboBoxMudidi_TextChanged);
            // 
            // textBoxKm
            // 
            this.textBoxKm.Location = new System.Drawing.Point(79, 161);
            this.textBoxKm.Name = "textBoxKm";
            this.textBoxKm.ReadOnly = true;
            this.textBoxKm.Size = new System.Drawing.Size(190, 21);
            this.textBoxKm.TabIndex = 5;
            // 
            // textBoxDacheYunfei
            // 
            this.textBoxDacheYunfei.Location = new System.Drawing.Point(79, 257);
            this.textBoxDacheYunfei.Name = "textBoxDacheYunfei";
            this.textBoxDacheYunfei.ReadOnly = true;
            this.textBoxDacheYunfei.Size = new System.Drawing.Size(190, 21);
            this.textBoxDacheYunfei.TabIndex = 5;
            // 
            // textBoxXiaocheYunfei
            // 
            this.textBoxXiaocheYunfei.Location = new System.Drawing.Point(79, 209);
            this.textBoxXiaocheYunfei.Name = "textBoxXiaocheYunfei";
            this.textBoxXiaocheYunfei.ReadOnly = true;
            this.textBoxXiaocheYunfei.Size = new System.Drawing.Size(190, 21);
            this.textBoxXiaocheYunfei.TabIndex = 5;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(194, 316);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 1;
            this.buttonSubmit.Text = "提  交";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(97, 316);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "重  置";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // Form为客户设置地区
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 363);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.comboBoxMudidi);
            this.Controls.Add(this.comboBoxQuyu);
            this.Controls.Add(this.textBoxXiaocheYunfei);
            this.Controls.Add(this.textBoxDacheYunfei);
            this.Controls.Add(this.textBoxKm);
            this.Controls.Add(this.textBoxKehu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form为客户设置地区";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "为客户设置地区";
            this.Load += new System.EventHandler(this.Form为客户设置地区_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxKehu;
        private System.Windows.Forms.ComboBox comboBoxQuyu;
        private System.Windows.Forms.ComboBox comboBoxMudidi;
        private System.Windows.Forms.TextBox textBoxKm;
        private System.Windows.Forms.TextBox textBoxDacheYunfei;
        private System.Windows.Forms.TextBox textBoxXiaocheYunfei;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonReset;
    }
}