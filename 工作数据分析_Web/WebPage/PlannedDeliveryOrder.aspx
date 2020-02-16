<%@ Page Title="" Language="C#" MasterPageFile="../Master/Site.master" AutoEventWireup="true" CodeFile="PlannedDeliveryOrder.aspx.cs" Inherits="WebPage_PlannedDeliveryOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 34px;
        }
        .style2
        {
            height: 162px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
    </asp:MultiView>
    <table style="width:100%; height: 500px;table-layout:fixed">
    <tr>  <td class="style1">
        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" 
            Width="190px">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="查  询" />
        </td></tr>
        <tr>            
            <td align="left" class="style2">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" HorizontalAlign="Left" 
                    Width="100%">
                    <asp:GridView ID="GridView1" runat="server" Width="100%">
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        
    </table>
</asp:Content>

