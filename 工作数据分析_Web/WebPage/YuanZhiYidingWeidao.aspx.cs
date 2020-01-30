using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class WebPage_YuanZhiYidingWeidao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        Searche();
    }

    private void Searche()
    {
        //SELECT concat('TextBox',`代码`,`门幅`)'ID',`件数`FROM `slbz`.`二期原纸已订未到`where 纸类='A'
        DataTable dt = MySqlDbHelper.ExecuteDataTable(
            "select concat('TextBox_',`代码`,'_',`门幅`)'ID',`件数`FROM `slbz`.`二期原纸已订未到`where 纸类='"
            + DropDownList1.SelectedValue + "';");


        foreach (System.Web.UI.Control ctr in this.Panel1.Controls)
        {
            if (ctr is System.Web.UI.WebControls.TextBox)
            {
                TextBox tb = ctr as TextBox;
                tb.Text = string.Empty;
                DataRow[] drs = dt.Select("ID='" + ctr.ID + "'");
                if (drs.Length > 0)
                {
                    tb.Text = drs[0]["件数"].ToString();
                }
            }
        }


    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        List<string> sqlList = new List<string>();
        foreach (System.Web.UI.Control ctr in this.Panel1.Controls)
        {

            if (ctr is System.Web.UI.WebControls.TextBox)
            {
                TextBox tb = ctr as TextBox;
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    continue;
                }
                //分离出纸类,代码,门幅,件数
                string zhilei = DropDownList1.SelectedValue;
                string[] textSplit = ctr.ID.Split('_');
                string daima = textSplit[1];
                string menfu = textSplit[2];

                int jianshu = Convert.ToInt16(tb.Text);

                sqlList.Add(
                    string.Format(
                    "UPDATE`slbz`.`二期原纸已订未到`SET`件数`='{0}'WHERE`纸类`='{1}',`代码`='{2}',`门幅`='{3}'"
                    , jianshu, zhilei, daima, menfu));
            }
        }
        if (MySqlDbHelper.ExecuteSqlTran(sqlList))
        {
            Searche();
        }
        else
        {
            Response.Write("<script>alert('错误: 保存失败!');</script>");
        }
    }
}