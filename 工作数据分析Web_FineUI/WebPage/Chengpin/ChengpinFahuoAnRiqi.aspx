<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChengpinFahuoAnRiqi.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Chengpin.ChengpinFahuoAnRiqi"
    EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="开始日期" EmptyText="请选择开始日期"
                    ID="DatePickerStart" ShowRedStar="true">
                </f:DatePicker>
                <f:DatePicker ID="DatePickerEnd" Required="true" Readonly="false" CompareControl="DatePicker1" DateFormatString="yyyy-MM-dd"
                    CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="结束日期"
                    runat="server" ShowRedStar="true">
                </f:DatePicker>
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确  认" />

        <asp:Button ID="ButtonDownload" runat="server" Text="下  载" OnClick="ButtonDownload_Click" />

        <br />
        <div id="DivExport" runat="server">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:Label ID="LabelKucun" runat="server" Text="成品库存" style="font-size:16px" ></asp:Label>
    <br />
    <br />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
