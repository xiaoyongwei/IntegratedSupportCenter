using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using YBF.Class.Comm;

namespace YBF.WinForm.Ywj
{
    public partial class FormYwjInformation : Form
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        private int ID = 0;

        public FormYwjInformation()
        {
            InitializeComponent();
        }

        public FormYwjInformation(int id)
        {
            this.ID = id;
            InitializeComponent();
        }

        private void textBoxYwjPath_DoubleClick(object sender, EventArgs e)
        {
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                this.textBoxYwjPath.Text = fbd.SelectedPath;
            }
        }

        private void textBoxYwjPathMove_DoubleClick(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.textBoxYwjPathMove.Text = fbd.SelectedPath;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)item).Text))
                    {
                        Comm_Method.ShowErrorMessage("不能为空！");
                    }
                }
            }

            if (this.ID==0)
            {
                string sqlStr = "INSERT INTO [Ywj]([Name],[Path],[PathMove])VALUES("
                + "'" + this.textBoxName.Text.Trim() + "',"
                + "'" + this.textBoxYwjPath.Text.Trim() + "',"
                + "'" + this.textBoxYwjPathMove.Text.Trim() + "');";
                if (SQLiteList.YBF.ExecuteNonQuery(sqlStr) > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else if(this.ID>0)
            {
                string sqlStr = "UPDATE [Ywj] SET "
               + "[Name]='" + this.textBoxName.Text.Trim() + "',"
               + "[Path]='" + this.textBoxYwjPath.Text.Trim() + "',"
               + "[PathMove]='" + this.textBoxYwjPathMove.Text.Trim() + "'"
               + " WHERE ID=" + this.ID;
                if (SQLiteList.YBF.ExecuteNonQuery(sqlStr) > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            

        }

        private void FormYwjInformation_Load(object sender, EventArgs e)
        {
            if (this.ID>0)
            {
                DataTable dt = SQLiteList.YBF.ExecuteDataTable
                    ("select * from ywj where ID=" + this.ID);
                this.textBoxName.Text = dt.Rows[0]["Name"].ToString();
                this.textBoxYwjPath.Text = dt.Rows[0]["Path"].ToString();
                this.textBoxYwjPathMove.Text = dt.Rows[0]["PathMove"].ToString();
            }
        }
    }
}
