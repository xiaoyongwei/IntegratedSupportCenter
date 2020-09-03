<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Yunfeidan.ascx.cs" Inherits="WebPage_wuliu_WebUserControl_Yunfeidan" %>
<table >
    <tr  ><td colspan="4"></td></tr>
    <tr>
        <td>日期:<asp:Label ID="LabelRiqi" runat="server"></asp:Label>
        </td>
        <td>车牌:<asp:Label ID="LabelChepai" runat="server"></asp:Label>
        </td>
        <td>司机:<asp:Label ID="LabelSiji" runat="server"></asp:Label>
        </td>
        <td>装车单号:<asp:Label ID="LabelZhuangchedanhao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:GridView ID="GridViewQingdan" runat="server" Width="100%">
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>平方合计:<asp:Label ID="LabelHejipingfang" runat="server"></asp:Label>
            <br />
        </td>
        <td>&nbsp;</td>
        <td>运费+附加费合计:<asp:Label ID="LabelZongyunfei" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4">导出日期:<asp:Label ID="LabelDaochuriqi" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <hr />
        </td>
    </tr>
</table>

