<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuanzhiBeiliaoJihua.aspx.cs" Inherits="工作数据分析Web_FineUI.YuanZhi.yuanzhi2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         
        <div id ="DivExport" runat="server">
   <table style="width: 100%;">
        <tr>
            <td>
               
         <asp:Button ID="ButtonDownload" runat="server" OnClick="ButtonDownload_Click" Text="下  载" />
               <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView3" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView4" runat="server">
                </asp:GridView>
            </td>
        </tr>
       
    </table>
            </div>
        </form>
</body>
</html>
