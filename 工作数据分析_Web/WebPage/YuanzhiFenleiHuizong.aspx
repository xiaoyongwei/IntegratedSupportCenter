<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Master/Site.master"
    CodeFile="YuanzhiFenleiHuizong.aspx.cs" Inherits="WebPage_YuanzhiFeileiHuizong" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
            <table style="width:100%" >              
                <tr valign="top">
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
       </asp:Content>