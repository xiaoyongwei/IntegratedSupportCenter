<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="工作数据分析Web_FineUI.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
         <f:Window Width="350" WindowPosition="GoldenSection" EnableClose="false" IsModal="false" Title="登录表单" ID="Window1" runat="server">
            <Items>
                <f:SimpleForm ShowHeader="false" BodyPadding="10" ShowBorder="false" ID="SimpleForm1" runat="server">
                    <Items>
                        <f:TextBox ShowRedStar="true" Required="true" Label="用户名" ID="tbxUserName" runat="server"></f:TextBox>
                        <f:TextBox ShowRedStar="true" Required="true" TextMode="Password" Label="密码" ID="tbxPassword" runat="server"></f:TextBox>
                    </Items>
                </f:SimpleForm>
            </Items>
            <Toolbars>
                <f:Toolbar Position="Bottom" ToolbarAlign="Right" ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button Type="Submit" ID="btnLogin" Text="登录" ValidateTarget="Top" ValidateForms="SimpleForm1"
                            OnClick="btnLogin_Click" runat="server">
                        </f:Button>
                        <f:Button Type="Reset" Text="重置" ID="btnReset" runat="server"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>
    </form>
</body>
</html>
