<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Yunfeidan.ascx.cs" Inherits="WebUserControl_Yunfeidan" %>
<style type="text/css">
    .auto-style1 {
        width: 426px;
    }
    .auto-style2 {
        width: 188px;
    }
    .auto-style3 {
        width: 181px;
    }
</style>
<table >
    <tr  ><td colspan="4" style="text-align:center;"><u>运费核对单</u></td></tr>
    <tr>
        <td colspan="4">
            日期:<asp:Label ID="LabelRiqi" runat="server"></asp:Label>
            &nbsp;&nbsp;
            车牌:<asp:Label ID="LabelChepai" runat="server"></asp:Label>
            &nbsp;&nbsp;
            司机:<asp:Label ID="LabelSiji" runat="server"></asp:Label>
            &nbsp;&nbsp;
            装车单号:<asp:Label ID="LabelZhuangchedanhao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:GridView ID="GridViewQingdan" runat="server" Width="100%">
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style2">平方合计:<asp:Label ID="LabelPingfangheji" runat="server" ForeColor="#3399FF"></asp:Label>
            <br />
        </td>
        <td>&nbsp;</td>
        <td class="auto-style1">运费+附加费合计:<asp:Label ID="LabelZongyunfei" runat="server" ForeColor="Red"></asp:Label>
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

