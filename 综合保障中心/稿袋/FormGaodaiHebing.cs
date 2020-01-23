using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 综合保障中心.稿袋
{
    public partial class FormGaodaiHebing : Form
    {
        private string GaoDai;
        private string Customer;
        private string Product;
        private string NewCustomer;
        private string NewProduct;

        public FormGaodaiHebing(string gaodai,string kehu,string chanpin,string newkehu,string newchanpin)
        {
            InitializeComponent();
            this.textBoxGaodai.Text = gaodai;
            this.textBoxCustomer.Text = kehu;
            this.textBoxProduct.Text = chanpin;
            this.labelHebing.Text = string.Format(this.labelHebing.Text, newkehu, newchanpin);

            GaoDai = gaodai;
            Customer = kehu;
            Product = chanpin;
            NewCustomer = newkehu;
            NewProduct = newchanpin;
        }

        private void FormGaodaiInfo_Load(object sender, EventArgs e)
        {
            if (this.labelHebing.Size.Width + this.labelHebing.Location.X + 10>this.Size.Width)
            {
                this.Size = new Size(this.labelHebing.Size.Width + this.labelHebing.Location.X + 10
                , this.Size.Height);
            }
            
            this.MinimizeBox = false;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
