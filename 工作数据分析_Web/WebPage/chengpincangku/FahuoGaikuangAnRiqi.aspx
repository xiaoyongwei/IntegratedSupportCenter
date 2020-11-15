<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.master"
    CodeFile="FahuoGaikuangAnRiqi.aspx.cs" Inherits="WebPage_FahuoGaikuangAnRiqi" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:TextBox ID="TextBoxDateS" runat="server"></asp:TextBox>
    -&gt;<asp:TextBox ID="TextBoxDateE" runat="server"></asp:TextBox>
&nbsp;<%-- <asp:TextBox ID="TextBoxDateS" runat="server"></asp:TextBox>
<asp:TextBox ID="TextBoxDateE" runat="server"></asp:TextBox>--%><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确  认" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="ButtonDownLoad" runat="server" Text="下载Excel" OnClick="ButtonDownLoad_Click"/>
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
    
</asp:Content>