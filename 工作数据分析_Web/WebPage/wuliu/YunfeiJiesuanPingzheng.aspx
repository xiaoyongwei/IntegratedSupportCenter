<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="YunfeiJiesuanPingzheng.aspx.cs" Inherits="WebPage_wuliu_YunfeiJiesuanPingzheng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table >
        <tr>
            <td>开始时间:<asp:TextBox ID="TextBox_time_S" runat="server"></asp:TextBox></td>
            <td>结束时间:<asp:TextBox ID="TextBox_time_E" runat="server"></asp:TextBox></td>
            <td>驾驶员:<asp:DropDownList ID="DropDownListJiashiyuan" runat="server"></asp:DropDownList>&nbsp;</td>            
        </tr>
        <tr><td> <asp:Button ID="ButtonSubmit" runat="server" Text="查询" OnClick="ButtonSubmit_Click" /></td></tr>
    </table>
    <%@ Register TagPrefix="yunfei" TagName="Yunfeidan" Src="~/UserControl/Yunfeidan.ascx" %>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>

