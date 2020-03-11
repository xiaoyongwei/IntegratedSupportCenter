<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Master/Site.master"
    CodeFile="RukuGaikuangAnRiqi.aspx.cs" Inherits="WebPage_RukuGaikuangAnRiqi" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确  认" />
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
    
</asp:Content>