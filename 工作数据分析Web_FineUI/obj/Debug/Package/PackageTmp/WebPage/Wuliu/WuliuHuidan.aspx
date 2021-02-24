<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WuliuHuidan.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.Wuliu.WuliuHuidan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>回单管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" IsFluid="true" CssClass="blockpanel" Title="表格（数据库分页）" EnableCollapse="false" PageSize="5" ShowBorder="true" ShowHeader="true"
            AllowPaging="true" IsDatabasePaging="true" runat="server" EnableCheckBoxSelect="true" Height="350px" ForceFit="true"
           OnPageIndexChange="Grid1_PageIndexChange">
           
              
            <PageItems>
                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                </f:ToolbarSeparator>
                <f:ToolbarText runat="server" Text="每页记录数：">
                </f:ToolbarText>
                <f:DropDownList runat="server" ID="ddlPageSize" Width="100px" AutoPostBack="true" EnableEdit="true"
                    OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                    <f:ListItem Text="20" Value="20" />
                    <f:ListItem Text="50" Value="50" />
                    <f:ListItem Text="100" Value="100" />
                    <f:ListItem Text="200" Value="200" />
                    <f:ListItem Text="500" Value="500" />
                    <f:ListItem Text="1000" Value="1000" />
                    <f:ListItem Text="2000" Value="2000" />
                    <f:ListItem Text="5000" Value="5000" />
                </f:DropDownList>
            </PageItems>
        </f:Grid>
        <br />
        <f:Button ID="Button1" runat="server" Text="选中了哪些行" OnClick="Button1_Click">
        </f:Button>
        <br />
        <f:Label ID="labResult" EncodeText="false" runat="server">
        </f:Label>
    </form>
</body>
</html>
