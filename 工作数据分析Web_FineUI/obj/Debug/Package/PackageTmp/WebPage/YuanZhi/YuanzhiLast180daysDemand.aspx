<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuanzhiLast180daysDemand.aspx.cs" Inherits="工作数据分析Web_FineUI.YuanZhi.yuanzhiLast180daysDemand" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="ButtonDownload" runat="server" OnClick="ButtonDownload_Click" Text="下  载" />
         <br />
 <div id="DivExport" runat="server">
         <asp:GridView ID="GridView1" runat="server" CaptionAlign="Top" CellPadding="1" CellSpacing="1">
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" CaptionAlign="Top" CellPadding="1" CellSpacing="1">
        </asp:GridView>
      </div>
    </form>
</body>
</html>
