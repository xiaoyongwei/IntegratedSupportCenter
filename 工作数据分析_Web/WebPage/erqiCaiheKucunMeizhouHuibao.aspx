﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="erqiCaiheKucunMeizhouHuibao.aspx.cs" Inherits="WebPage_erqiCaiheKucunQingkuang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
                <asp:Label ID="LabelGenxinShijian" runat="server"></asp:Label>
           <br />
                <asp:GridView ID="GridView1_0_7" runat="server" Caption="0-7天库存情况(1期)">
                </asp:GridView>
           <br />            
                <asp:GridView ID="GridView1_8_14" runat="server" Caption="8-14天库存情况(1期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView1_15_30" runat="server" Caption="15-30天库存情况(1期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView1_31jiyishang" runat="server" Caption="31天及以上库存情况(1期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView2_0_7" runat="server" Caption="0-7天库存情况(2期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView2_8_14" runat="server" Caption="8-14天库存情况(2期)">
                </asp:GridView>
           <br />  
                <asp:GridView ID="GridView2_15_30" runat="server" Caption="15-30天库存情况(2期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView2_31jiyishang" runat="server" Caption="31天及以上库存情况(2期)">
                </asp:GridView>
            
</asp:Content>

