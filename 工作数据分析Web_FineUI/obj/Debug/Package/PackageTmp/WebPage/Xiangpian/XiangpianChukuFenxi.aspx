<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiangpianChukuFenxi.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Xiangpian.XiangpianChukuFenxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
        <asp:GridView ID="GridView1" runat="server" CaptionAlign="Top" CellPadding="1" CellSpacing="1"
            PageSize="500">
        </asp:GridView>
    </asp:Panel>
    </form>
</body>
</html>
