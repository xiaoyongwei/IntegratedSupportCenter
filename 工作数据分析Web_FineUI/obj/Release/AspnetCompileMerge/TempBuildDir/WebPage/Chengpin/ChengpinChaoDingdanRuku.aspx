﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChengpinChaoDingdanRuku.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Chengpin.ChengpinChaoDingdanRuku" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>超订单入库</title>
</head>
<body>
    <form id="form1" runat="server">
        <%=Page.Title+" "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%>
      <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>
