<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChengpinKucunMingxi.aspx.cs" Inherits="工作数据分析Web_FineUI.Chengpin.ChengpinKucunMingxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>成品库存明细</title>
</head>
<body>
    <form id="form1" runat="server">
        <%=Page.Title+" "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%>
        <div> <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
