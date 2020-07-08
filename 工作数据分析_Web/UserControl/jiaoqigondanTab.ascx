<%@ Control Language="C#" AutoEventWireup="true" CodeFile="jiaoqigondanTab.ascx.cs" Inherits="jiaoqigondanTab" %>
<style type="text/css">
    .auto-style1 {
        height: 27px;
    }
</style>
<!--border: 1px solid red;" -->
<table style="width:100%;" >
    <tr>
        <td>
            <asp:Label ID="LabelGongdan" runat="server" Text="Label" BorderColor="#9999FF" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
            &nbsp;<asp:Label ID="LabelKehu" runat="server" Text="Label" BorderColor="#9999FF" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelMingcheng" runat="server" Text="Label" BorderColor="#9999FF" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelDingDan" runat="server" Text="Label" BorderColor="#9999FF" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
            &nbsp;<asp:Label ID="LabelMianji" runat="server" Text="Label" BorderColor="#9999FF" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
            &nbsp;<asp:Label ID="LabelRuku" runat="server" Text="Label" BorderColor="#9999FF" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Button ID="ButtonInfomation" runat="server" Text="工单详情" />
            &nbsp;
            <asp:Button ID="ButtonCompleted" runat="server" Text="完工" />
        </td>
    </tr>
</table>

