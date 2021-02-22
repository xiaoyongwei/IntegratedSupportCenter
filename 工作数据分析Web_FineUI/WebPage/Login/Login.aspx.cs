using FineUIPro;
using FineUIPro.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.Login
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbxUserName.Text = "admin";
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxUserName.Text == "admin" && tbxPassword.Text == "123")
            {
                ShowNotify("成功登录！", MessageBoxIcon.Success);
                Session["username"] = tbxUserName.Text;
                Response.Redirect("~/default.aspx");
            }
            else
            {
                ShowNotify("用户名或密码错误！", MessageBoxIcon.Error);
            }
        }
    }
}