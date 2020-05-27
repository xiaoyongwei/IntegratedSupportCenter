<%@ Page Title="" Language="C#" MasterPageFile="../Master/Site.master" AutoEventWireup="true"
    CodeFile="YuanZhiYidingWeidao.aspx.cs" Inherits="WebPage_YuanZhiYidingWeidao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 48px;
        }
        .style2
        {
            width: 48px;
            height: 23px;
        }
        .style3
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    原纸已订未到明细
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" EnableViewState="False">
    
    <table style="width: 100%;" border="1" cellspacing="0" dir="ltr" frame="above" >
     <tr>
     <td><asp:DropDownList ID="DropDownList1" runat="server" Height="19px" Width="75px" >
         <asp:ListItem Value="A">A类纸</asp:ListItem>
         <asp:ListItem Value="B">B类纸</asp:ListItem>
    </asp:DropDownList>
         <asp:Button ID="ButtonSearch" runat="server" onclick="ButtonSearch_Click" 
             Text="查  询" />
         </td></tr>
        <tr>
            <td >代码
            </td>
            <td>
                900
            </td>
            <td>
                950
            </td>
            <td>
                1000
            </td>
            <td>
                1050
            </td>
            <td>
                1100
            </td>
            <td>
                1150
            </td>
            <td>
                1200
            </td>
            <td>
                1250
            </td>
            <td>
                1300
            </td>
            <td>
                1350
            </td>
            <td>
                1400
            </td>
            <td>
                1450
            </td>
            <td>
                1500
            </td>
            <td>
                1550
            </td>
            <td>
                1600
            </td>
            <td>
                1650
            </td>
            <td>
                1700
            </td>
        </tr>
        <tr>
            <td class="style2">
                T
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_900" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_950" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1000" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1050" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1100" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1150" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1200" runat="server" Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1250" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1300" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1350" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1400" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1450" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1500" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1550" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1600" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1650" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox_T_1700" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                UV
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_900" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_950" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1000" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1050" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1100" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1150" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1200" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1250" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1300" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1350" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1400" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1450" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1500" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1550" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1600" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1650" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UV_1700" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                V1
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_900" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_950" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1000" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1050" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1100" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1150" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1200" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1250" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1300" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1350" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1400" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1450" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1500" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1550" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1600" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1650" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox_V1_1700" runat="server"  Width="100%" BorderStyle="None"  EnableViewState="False" Wrap="False"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="ButtonSubmit" runat="server" Text="保  存" 
            onclick="ButtonSubmit_Click" />
    </asp:Panel>
</asp:Content>
