<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="工作数据分析Web_FineUI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" IsFluid="true" runat="server" 
            Title="表格（动态创建的列）">
        </f:Grid>
    </form>
</body>
</html>
