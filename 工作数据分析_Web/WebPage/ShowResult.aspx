<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
CodeFile="ShowResult.aspx.cs" Inherits="WebPage_ShowResult" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="Button1" runat="server" Text="下载Excel" onclick="Button1_Click" 
        Visible="False" />
    <br />
   <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
    <asp:GridView ID="GridView1" runat="server" 
        CaptionAlign="Top" CellPadding="1" CellSpacing="1" 
        PageSize="500" >
    </asp:GridView>
    </asp:Panel>  
 </asp:Content>

