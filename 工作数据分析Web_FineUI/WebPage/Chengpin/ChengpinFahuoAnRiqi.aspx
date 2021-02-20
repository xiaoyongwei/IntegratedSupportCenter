<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChengpinFahuoAnRiqi.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Chengpin.ChengpinFahuoAnRiqi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:TextBox ID="TextBoxDateS" runat="server"></asp:TextBox>
        ->&gt;<asp:TextBox ID="TextBoxDateE" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确  认" />

        <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
    
    </form>
</body>
</html>
