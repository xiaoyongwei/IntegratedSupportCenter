<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="工作数据分析Web_FineUI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" IsFluid="true" CssClass="blockpanel" BodyPadding="10px" EnableCollapse="false"
            Title="简单表单" runat="server">
            <Items>
                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="开始日期" EmptyText="请选择开始日期"
                    ID="DatePicker1" ShowRedStar="true">
                </f:DatePicker>
                <f:DatePicker ID="DatePicker2" Required="true" Readonly="false" CompareControl="DatePicker1" DateFormatString="yyyy-MM-dd"
                    CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="结束日期"
                    runat="server" ShowRedStar="true">
                </f:DatePicker>
                <f:Button ID="btnSubmit" runat="server" ValidateForms="SimpleForm1" Text="提交表单"
                    OnClick="btnSubmit_Click">
                </f:Button>
            </Items>
        </f:SimpleForm>
        <br />
        <f:Label ID="labResult" ShowLabel="false" runat="server">
        </f:Label>
    </form>
</body>
</html>
