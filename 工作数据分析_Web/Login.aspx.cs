using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


public partial class WebPage_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        //FormsAuthentication.RedirectToLoginPage();

        //每次登陆的时候删除超过1个小时的临时文件
        string path = Server.MapPath("~") + "TmpDownFile";
        foreach (string file in Directory.EnumerateFiles(path))
        {
            if (File.GetLastWriteTime(file)<DateTime.Now.AddHours(-1))
            {
                File.Delete(file);
            }
        }
    }

   

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (Login1.UserName == "a" && Login1.Password == "123") 
        {
            e.Authenticated = true;
            Session.Add("username", Login1.UserName);
        }
        else
        {
            e.Authenticated = false;
        }
    }
}