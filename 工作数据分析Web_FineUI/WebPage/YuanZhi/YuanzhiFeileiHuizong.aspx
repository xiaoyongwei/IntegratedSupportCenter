<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuanzhiFeileiHuizong.aspx.cs" Inherits="工作数据分析Web_FineUI.YuanZhi.YuanzhiFeileiHuizong" %>

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
            <table style="width:100%" >              
                <tr>
                    <td >
                        <asp:GridView ID="GridViewA" runat="server">
                        </asp:GridView>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:GridView ID="GridViewB" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
