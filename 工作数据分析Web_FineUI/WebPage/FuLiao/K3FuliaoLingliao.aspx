<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="K3FuliaoLingliao.aspx.cs" Inherits="工作数据分析Web_FineUI.FuLiao.K3FuliaoLingliao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>辅料领料</title>
     <style type="text/css">
        .auto-style1 {
            width: 67px;
        }
        .auto-style3 {
            width: 59px;
        }
        .auto-style5 {
            width: 76px;
        }
        .auto-style6 {
            width: 219px;
        }
        .auto-style7 {
            width: 98%;
        }
        .auto-style8 {
            width: 67px;
            height: 25px;
        }
        .auto-style10 {
            width: 59px;
            height: 25px;
        }
        .auto-style11 {
            width: 219px;
            height: 25px;
        }
        .auto-style12 {
            width: 76px;
            height: 25px;
        }
        .auto-style13 {
            height: 25px;
        }
        .auto-style14 {
            width: 212px;
        }
        .auto-style15 {
            width: 212px;
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <table class="auto-style7">
        <tr>
            <td class="auto-style1">日期:</td>
            <td class="auto-style14">
                <asp:TextBox ID="TextBoxRiqi" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td class="auto-style3">单据编号:</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBoxDjbh" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td class="auto-style5">物料名称:</td>
            <td>
                <asp:TextBox ID="TextBoxWlmc" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">批号:</td>
            <td class="auto-style14">
                <asp:TextBox ID="TextBoxPh" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td class="auto-style3">规格型号:</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBoxGgxh" runat="server" Width="100%" ToolTip="比如平张纸的尺寸"></asp:TextBox>
            </td>
            <td class="auto-style5">辅助属性:</td>
            <td>
                <asp:TextBox ID="TextBoxFzsx" runat="server" Width="100%" ToolTip="比如原纸门幅"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">领料部门:</td>
            <td class="auto-style15">
                <asp:TextBox ID="TextBoxLlbm" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td class="auto-style10">领料人:</td>
            <td class="auto-style11">
                
                <asp:TextBox ID="TextBoxLlr" runat="server" Width="100%"></asp:TextBox>
                
            </td>
            <td class="auto-style12"></td>
            <td class="auto-style13"><asp:Button ID="ButtonRestart" runat="server" Text="重置" Width="67px" OnClick="ButtonRestart_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonSearch" runat="server" Text="查询" Width="67px" OnClick="ButtonSearch_Click" /></td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">
        <asp:GridView ID="GridView" runat="server" Caption="查询结果">
        </asp:GridView>
    </asp:Panel>
    </form>
</body>
</html>
