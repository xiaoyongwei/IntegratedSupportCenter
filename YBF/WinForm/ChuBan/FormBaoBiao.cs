using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace YBF.WinForm.ChuBan
{
    public partial class FormBaoBiao : Form
    {

        public FormBaoBiao(DataTable dt)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = dt;
        }

        private void FormBaoBiao_Load(object sender, EventArgs e)
        {
            ////关闭多余的窗体
            //foreach (Form f in this.ParentForm.MdiChildren)
            //{
            //    if (f.Name == this.Name && f.Handle != this.Handle)
            //    {
            //        f.Dispose();
            //    }
            //}


             string[] topPaths ={@"\\128.1.30.144\historical_data\processes"
                              ,@"\\128.1.130.31\historical_data\processes"};

            foreach (string topPath in topPaths)
            {
                if (!Directory.Exists(topPath))
                {
                    continue;
                }

            //先读取顶层文件夹，24小时以内的
                foreach (string tPath in Directory.EnumerateDirectories(topPath))
                {
                    if (Directory.GetCreationTime(tPath).AddHours(24) > DateTime.Now)
                    {
                        //把24小时以内的文件夹里面查询是否存在“1-3{printing-to-device}.out.jtk”
                        if (File.Exists(tPath + "\\jt-trail\\1-3{printing-to-device}.out.jtk"))
                        {
                            string AllText =
                                File.ReadAllText
                                (tPath + "\\jt-trail\\1-3{printing-to-device}.out.jtk");
                            Regex regex = new Regex("/CPC_MediaOffset \\d+ 0 R");
                            string str = regex.Match(AllText).Value
                                .Replace("/CPC_MediaOffset", "").Replace("0 R", "0 obj").Trim();
                            regex = new Regex(str + "\n\\[ \\d+\\.\\d+ \\d+\\.\\d+ \\]");
                            str = regex.Match(AllText).Value.Replace(str, "").Trim();
                            regex = new Regex("\\d+\\.\\d+");
                            str = regex.Matches(str)[1].Value;
                            int yaokou = Convert.ToInt32(Math.Round(Convert.ToDouble(str) * 25.4 / 72, 1));

                            //确认文件名称
                            string ProcessCreationInfo = tPath + "\\ProcessCreationInfo.txt";
                            string[] allLines = File.ReadAllLines(ProcessCreationInfo);
                            string fileNames = "";
                            for (int i = 12; i < allLines.Length; i++)
                            {
                                fileNames += allLines[i];
                            }

                            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
                            {
                                if (fileNames.IndexOf
                                    (dgvRow.Cells["产品名称"].Value.ToString()
                                    , StringComparison.CurrentCultureIgnoreCase) > -1)
                                {
                                    dgvRow.Cells["咬口"].Value = yaokou;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
