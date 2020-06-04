<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="wuliaorukujinezoushi.aspx.cs" Inherits="WebPage_wuliaorukujinezoushi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 145px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                <asp:Panel ID="Panel1" runat="server" Height="650px" ScrollBars="Both" Width="162px">
                    <asp:TextBox ID="TextBoxSearch" runat="server" Width="100%"> </asp:TextBox>
                    <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonH_Click" Text="&lt;&lt;查询&gt;&gt;" />
                    <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                    </asp:TreeView>
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="Panel2" runat="server" Height="650px" ScrollBars="Both">
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
                
</asp:Content>

