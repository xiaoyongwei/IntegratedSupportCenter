<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiangpianDangqianPaicheng.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Xiangpian.XiangpianDangqianPaicheng" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="refresh" content="60"/>
    <title>箱片排程</title>
</head>
<body>
    <form id="form1" runat="server">
            <asp:Button ID="ButtonShowCaihe" runat="server" Text="查看彩盒排程" OnClick="ButtonShowCaihe_Click" />
&nbsp;
        <asp:Button ID="ButtonShowAll" runat="server" Text="查看全部排程" OnClick="ButtonShowAll_Click" />
        <br />
        <br />
            <asp:Label ID="Lable1" runat="server"></asp:Label>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="500px" Width="100%">
                            <asp:GridView ID="GridView1800" runat="server" Caption="制版线1800" Font-Size="10pt">                               
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                    <td class="auto-style1">
                        <asp:Panel ID="Panel4" runat="server" ScrollBars="Both" Height="500px" Width="100%">
                            <asp:GridView ID="GridView1800F" runat="server" Caption="制版线1800F" Font-Size="10pt">                               
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                    <td class="auto-style1">
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Height="500px" Width="100%">
                            <asp:GridView ID="GridView2200" runat="server" Caption="制版线2200" Font-Size="10pt">
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                    <td class="auto-style1">
                        <asp:Panel ID="Panel3" runat="server" ScrollBars="Both" Height="500px" Width="100%">
                            <asp:GridView ID="GridView2500" runat="server" Caption="制版线2500" Font-Size="10pt">
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridViewPublished" runat="server" Caption="24小时内完成" Font-Size="10pt">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
    </form>
</body>

</html>
