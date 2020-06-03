<%@ Page Language="C#"MasterPageFile="../Master/Site.master"  AutoEventWireup="true" CodeFile="ErqiFuliao.aspx.cs" Inherits="WebPage_ErqiFuliao" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

    <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table style="border-style: double; border-color: #0000FF" >
        <tr>
            <td>
                开始日期</td>
            <td>
                结束日期</td>
            
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox_S" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_E" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Button ID="ButtonSearch" runat="server" Text="查  询" 
                    onclick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
            
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" Caption="辅料领料明细" CaptionAlign="Top">
    </asp:GridView>
    
        <br />
        <asp:GridView ID="GridView2" runat="server" Caption="各部门领料概况">
        </asp:GridView>
    
    </asp:Content>