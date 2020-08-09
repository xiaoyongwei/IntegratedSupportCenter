using MySql.Data.MySqlClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using 工作数据分析.Data.DAL.Oracle;
using 工作数据分析.Properties;
using Resources = 工作数据分析.Properties.Resources;

namespace 工作数据分析.WinForm
{
    public partial class Form警告提示 : Form
    {
        SpeechSynthesizer speech = new SpeechSynthesizer();

        public Form警告提示()
        {
            InitializeComponent();
        }

        private void Form警告提示_Load(object sender, EventArgs e)
        {
            Show警告();
        }

       

        private void Show警告()
        {
            /*
            自动更新:每一个小时更新24小时内的数据
            手动更新:更新24小时内的数据

            1.成品仓库出现提前入库的记录时
            2.成品仓库出现超订单入库记录时
            3.甩纸出现3卷及以上用量时
            4.订单出现急单时(提示相应物料是否充足)
            */

            DataTable dtTqrk = OracleHelper.ExecuteDataTable(Resources.提前入库明细当天);
           
                //语音播报格式
                //客户：绿田，工单号：C200702003，存在提前入库情况，请核实！

                foreach (DataRow row in dtTqrk.Rows)
                {
                string speekStr = string.Format("客户:{0},工单号{1},存在提前入库情况,请核实!"
                        , row["客户简称"], row["工单号"]);
                TextboxShowAdd(speekStr);
                    speech.SpeakAsync(speekStr);
                }
        }

        private void TextboxShowAdd(string speekStr)
        {
            textBoxShow.AppendText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                + Environment.NewLine + speekStr + Environment.NewLine);
        }
    }
}
