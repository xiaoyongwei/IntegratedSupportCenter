<%@ Page Title="" Language="C#" MasterPageFile="../Master/Site.master" AutoEventWireup="true" CodeFile="ChengpinCangku.aspx.cs" Inherits="WebPage_ChengpinCangku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        天数:<asp:TextBox ID="TextBoxTianshu_S" runat="server" Width="56px">0</asp:TextBox>
        到<asp:TextBox ID="TextBoxTianshu_E" runat="server" Width="56px">9999</asp:TextBox>
        <asp:Button ID="ButtonSearch" runat="server" onclick="ButtonSearch_Click" 
            Text="查  询" />
    </p>
<asp:Panel ID="PanelShowData" runat="server" ScrollBars="Horizontal">
</asp:Panel>
</asp:Content>

