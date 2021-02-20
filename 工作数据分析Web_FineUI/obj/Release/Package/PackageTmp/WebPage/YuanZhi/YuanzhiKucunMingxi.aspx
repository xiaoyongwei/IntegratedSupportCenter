<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuanzhiKucunMingxi.aspx.cs" Inherits="工作数据分析Web_FineUI.YuanZhi.yuanzhi1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>二期原纸库存明细</title>
</head>
<body>
   <form id="form1" runat="server">
        <asp:Button ID="ButtonRefresh" runat="server" Text="刷新数据"  OnClick="ButtonRefresh_Click"/>
        &nbsp;
        &nbsp;
        <asp:Button ID="ButtonDownload" runat="server" Text="导出为Excel文件"  OnClick="ButtonDownload_Click"/>
        <br />
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
        </asp:GridView>
        </form>
</body>
</html>
