<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WuliaoTeshuGongyi.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.WuLiao.WuliaoTeshuGongyi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>特殊工艺</title>
</head>
<body>
    <form id="form1" runat="server">
        <%=Page.Title+" "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%>
        <div> <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
