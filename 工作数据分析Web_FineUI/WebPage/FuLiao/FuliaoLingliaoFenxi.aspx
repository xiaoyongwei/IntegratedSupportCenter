<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FuliaoLingliaoFenxi.aspx.cs" Inherits="工作数据分析Web_FineUI.FuLiao.FuliaoLingliaoFenxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>辅料领料分析</title>
</head>
<body>
    <form id="form1" runat="server">
        <%=Page.Title+" "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%>
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
        <asp:GridView ID="GridView2" runat="server" Caption="各部门领料概况">
        </asp:GridView>
    <asp:GridView ID="GridView1" runat="server" Caption="辅料领料明细" CaptionAlign="Top">
    </asp:GridView>
    
        <br />
    </form>
</body>
</html>
