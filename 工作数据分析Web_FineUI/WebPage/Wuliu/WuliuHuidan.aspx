﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WuliuHuidan.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Wuliu.WuliuHuidan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>回单管理</title>
   
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="ButtonDownload" runat="server" Text="导出Excel文件" OnClick="ButtonDownload_Click" />
        <br />
        <asp:GridView ID="GridView1" Caption="回单管理" runat="server"></asp:GridView>
    </form>
</body>
</html>
