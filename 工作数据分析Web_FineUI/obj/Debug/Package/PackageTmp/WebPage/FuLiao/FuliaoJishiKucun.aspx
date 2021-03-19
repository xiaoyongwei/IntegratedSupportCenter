<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FuliaoJishiKucun.aspx.cs" Inherits="工作数据分析Web_FineUI.FuLiao.FuliaoJishiKucun" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>辅料即时库存</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="ButtonDownload" runat="server" OnClick="ButtonDownload_Click" Text="下  载" />
         <br />
        <div> <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
        </div>
    </form>
</body>
</html>
