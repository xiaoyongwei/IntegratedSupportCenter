<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="Kaidan.aspx.cs" Inherits="WebPage_Kaidan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <table style="width:100%;">
        <tr>
            <td>
                开始日期</td>
            <td>
                结束日期</td>
        </tr>
        <tr>
            
            <td>
                <asp:Calendar ID="Calendar1" runat="server" ShowGridLines="True">
                    <SelectedDayStyle BackColor="#FF9900" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
            <td>
                <asp:Calendar ID="Calendar2" runat="server" ShowGridLines="True">
                    <SelectedDayStyle BackColor="#FF9900" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="查  询" onclick="Button1_Click" />
            </td>           
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server"> 
    </asp:GridView>
    <br />
    <asp:Panel ID="Panel1" runat="server" BorderStyle="Double" 
        ScrollBars="Horizontal">
    <asp:GridView ID="GridView2" runat="server" >
    </asp:GridView>
    </asp:Panel>
    
</asp:Content>

