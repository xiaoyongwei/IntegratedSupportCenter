﻿<%@ Page Language="C#" MasterPageFile="../Master/Site.master" AutoEventWireup="true" CodeFile="ShowResult2.aspx.cs"
    Inherits="WebPage_ShowResult" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">
        <asp:GridView ID="GridView1" runat="server" CaptionAlign="Top" CellPadding="1" CellSpacing="1"
            PageSize="500">
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" CaptionAlign="Top" CellPadding="1" CellSpacing="1"
            PageSize="500">
        </asp:GridView>
    </asp:Panel>
</asp:Content>
