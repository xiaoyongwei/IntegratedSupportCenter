<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChengpinJiaohuoChaoqiKaohe.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Chengpin.ChengpinJiaohuoChaoqiKaohe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>交货超期考核</title>
</head>
<body>
    <form id="form1" runat="server">
         <f:PageManager ID="PageManager1" runat="server" />
                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="时间点" EmptyText="请选择时间点"
                    ID="DatePicker1" ShowRedStar="true"></f:DatePicker>
        <asp:Button ID="Button1" runat="server" Text="查  询" OnClick="btnSubmit_Click" />
                <asp:Button  ID="ButtonDownload" runat="server" Text="导出Excel文件" OnClick="ButtonDownload_Click"/>
         <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
   
</body>
</html>
