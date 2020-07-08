<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jihuajiaoqi.aspx.cs" Inherits="WebPage_jihua_jihuajiaoqi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
    
    <%@ Register TagPrefix="uc" TagName="jiaoqigondanTab" Src="~/UserControl/jiaoqigondanTab.ascx" %>
    <uc:jiaoqigondanTab  ID="C200707041" runat="server">
    </uc:jiaoqigondanTab>
        </form>
</body>
</html>
