<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="ShowCurrentZhibanxian.aspx.cs" Inherits="WebPage_ShowCurrentZhibanxian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 142px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>    
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
                    <td colspan="3">
                        <asp:GridView ID="GridViewPublished" runat="server" Caption="24小时内完成" Font-Size="10pt">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        

</asp:Content>

