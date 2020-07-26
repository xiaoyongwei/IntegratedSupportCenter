<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="erqiCaiheKucunMeizhouHuibao.aspx.cs" Inherits="WebPage_erqiCaiheKucunQingkuang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="LabelGenxinShijian" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1_0_7" runat="server" Caption="0-7天库存情况(1期)">
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="GridView1_8_14" runat="server" Caption="8-14天库存情况(1期)">
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="GridView1_15_30" runat="server" Caption="15-30天库存情况(1期)">
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="GridView1_31jiyishang" runat="server" Caption="31天及以上库存情况(1期)">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2_0_7" runat="server">
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="GridView2_8_14" runat="server" Caption="8-14天库存情况(2期)">
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="GridView2_15_30" runat="server" Caption="15-30天库存情况(2期)">
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="GridView2_31jiyishang" runat="server" Caption="31天及以上库存情况(2期)">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

