<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChengpinRukuAnRiqi.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Chengpin.ChengpinRukuAnRiqi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBoxDateS" runat="server"></asp:TextBox>
    -&gt;<asp:TextBox ID="TextBoxDateE" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确  认" />
    
    &nbsp;<asp:Button ID="ButtonDownload" runat="server" OnClick="ButtonDownload_Click" Text="导出为Excel" />
    
    <br />
        <div runat ="server" id="divExport">
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
         <asp:Label ID="Label1" runat="server" Text="Label" style="font-size:16px" ></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
            </div>
    </form>
</body>
</html>
