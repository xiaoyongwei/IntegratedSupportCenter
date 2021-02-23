<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChengpinKucunHuibao.aspx.cs" Inherits="工作数据分析Web_FineUI.Chengpin.ChengpinKucunHuibao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="ButtonDownload" runat="server" Text="导出为Excel文件" OnClick="ButtonDownload_Click" />
         <br /><br />
        <div runat="server" id="divExport"><table>
        <tr>
            <td>
                <asp:GridView ID="GridView1_1qi" runat="server" Caption="未发货彩盒库存(1期)">
                </asp:GridView>
                
                <asp:Label ID="LabelGenxinShijian2" runat="server" ></asp:Label>
            </td>
            <td></td>
            <td>
                 <asp:GridView ID="GridView1_2qi" runat="server" Caption="未发货彩盒库存(2期)">
                </asp:GridView>
               
                <asp:Label ID="LabelGenxinShijian" runat="server" ></asp:Label>
            </td>
        </tr>        
    </table>

        <br />
        <br />
        <br />
               
        <asp:GridView ID="GridViewKucunMingxi" runat="server"></asp:GridView>
        </div>
          <%-- <br />
                <asp:GridView ID="GridView1_0_7" runat="server" Caption="0-7天库存情况(1期)">
                </asp:GridView>
           <br />            
                <asp:GridView ID="GridView1_8_14" runat="server" Caption="8-14天库存情况(1期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView1_15_30" runat="server" Caption="15-30天库存情况(1期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView1_31jiyishang" runat="server" Caption="31天及以上库存情况(1期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView2_0_7" runat="server" Caption="0-7天库存情况(2期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView2_8_14" runat="server" Caption="8-14天库存情况(2期)">
                </asp:GridView>
           <br />  
                <asp:GridView ID="GridView2_15_30" runat="server" Caption="15-30天库存情况(2期)">
                </asp:GridView>
            <br />  
                <asp:GridView ID="GridView2_31jiyishang" runat="server" Caption="31天及以上库存情况(2期)">
                </asp:GridView>--%>
    </form>
</body>
</html>
