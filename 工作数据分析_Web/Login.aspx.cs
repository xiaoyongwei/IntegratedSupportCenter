using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        //FormsAuthentication.RedirectToLoginPage();
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