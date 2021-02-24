<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="K3RukuJineZoushi.aspx.cs" Inherits="工作数据分析Web_FineUI.FuLiao.K3RukuJineZoushi" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>物料入库金额走势</title>
    <style type="text/css">
        .auto-style1 {
            width: 145px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                <asp:Panel ID="Panel1" runat="server" Height="650px" ScrollBars="Both" Width="179px">
                    <asp:TextBox ID="TextBoxSearch" runat="server" Width="100%"> </asp:TextBox>
                    <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonH_Click" Text="&lt;&lt;查询&gt;&gt;" />
                    <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                    </asp:TreeView>
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="Panel2" runat="server" Height="650px" ScrollBars="Both" Width="750px">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                    <br />
                </asp:Panel>
            </td>
        </tr>
    </table>
                        <asp:Chart ID="Chart1" runat="server" Width="932px">
                        <Series>
                            <asp:Series Name="Series1" ChartType="Line">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
        
        
    </form>
</body>
</html>
