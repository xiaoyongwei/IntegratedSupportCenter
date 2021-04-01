<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WuliuTuopanJinchuPingdan.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Wuliu.WuliuTuopanJinchuPingdan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 41px;
        }
        .auto-style10 {
            height: 23px;
        }
        .auto-style11 {
            width: 137px;
            height: 23px;
        }
        .auto-style12 {
            height: 23px;
            width: 116px;
        }
        .auto-style17 {
            width: 116px;
        }
        .auto-style19 {
            width: 136px;
        }
        .auto-style20 {
            height: 24px;
            width: 136px;
            text-align: center;
        }
        .auto-style23 {
            width: 137px;
        }
        .auto-style25 {
            text-align: center;
        }
        .auto-style27 {
            height: 24px;
            width: 129px;
            text-align: center;
        }
        .auto-style28 {
            width: 129px;
        }
        .auto-style29 {
            height: 24px;
            width: 113px;
            text-align: center;
        }
        .auto-style30 {
            width: 113px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <f:PageManager runat="server" ></f:PageManager>
   
        <asp:Button ID="ButtonSave" runat="server" Text="保  存" />
&nbsp;
        <asp:Button ID="ButtonDownload" runat="server" Text="下  载" />
        <br />
        <br />
   
    <table style="width:1000px" border="1px" cellpadding="10px" cellspacing="0px" bordercolor="black">
        <tr >
            <td align="center" colspan="6" > <p style="font-size:15px">温岭市森林包装有限公司</p></td>
        </tr>
        <tr>
             <td align="center" colspan="6" > <p style="font-size:20px" >托盘进出凭单</p></td>
        </tr>
        <tr>
           <td align="center" colspan="6" class="auto-style2" > <p style="font-size:15px" >事业部：水印事业部（   ）     胶印事业部（ √ ）  </p></td>
        </tr>
        <tr>
            <td class="auto-style12">车间</td>
            <td colspan="2" class="auto-style10"></td>
            <td class="auto-style11">司机姓名</td>
            <td colspan="2" class="auto-style10">
                <asp:DropDownList ID="DropDownListSiji" runat="server" Width="100%">
                    <asp:ListItem> </asp:ListItem>
                    <asp:ListItem>霍红海</asp:ListItem>
                    <asp:ListItem>郑二毛</asp:ListItem>
                    <asp:ListItem>郑荷伟</asp:ListItem>
                    <asp:ListItem>周晓军</asp:ListItem>
                    <asp:ListItem>杨冬冬</asp:ListItem>
                    <asp:ListItem>娄绍勇</asp:ListItem>
                    <asp:ListItem>郑华东</asp:ListItem>
                    <asp:ListItem>石昆仑</asp:ListItem>
                    <asp:ListItem>罗正春</asp:ListItem>
                    <asp:ListItem>蔡林威</asp:ListItem>
                    <asp:ListItem>赵庆宇</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style17" rowspan="2">客户名称</td>
            <td class="auto-style25" colspan="2">带出托盘</td>
            <td class="auto-style25" colspan="2">收回托盘</td>
            <td class="auto-style25" rowspan="2">备注</td>
        </tr>
        <tr>
            <td class="auto-style20">日期</td>
            <td class="auto-style29">数量(只)</td>
            <td class="auto-style20">日期</td>
            <td class="auto-style27">数量(只)</td>
        </tr>
        <tr>
            <td class="auto-style17">
                <asp:TextBox ID="TextBoxKehu" runat="server" Width="100%" Height="100%"></asp:TextBox>
            </td>
            <td class="auto-style19"><f:DatePicker runat="server" ID="DataPickerChu"  Width="160" EnableEdit="false" ShowLabel="false"></f:DatePicker></td>
            <td class="auto-style30">
                <asp:TextBox ID="TextBoxDaichu" runat="server"  Width="100%" Height="100%"></asp:TextBox>
            </td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style28">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style30">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style28">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style30">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style28">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style30">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style28">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style30">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style28">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <p class="MsoNormal">
                    <span style="mso-spacerun:'yes';font-family:宋体;mso-ascii-font-family:Calibri;
mso-hansi-font-family:Calibri;mso-bidi-font-family:'Times New Roman';font-size:12.0000pt;
mso-font-kerning:1.0000pt;"><font face="宋体">执勤保安：</font> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font face="宋体">主管审批：</font> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font face="宋体">担保人签字：</font> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font face="宋体">仓管：</font> <o:p></o:p></span>
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="6">编号:<asp:Label ID="LabelBianhao" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

         </form>
</body>
</html>
