<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="工作数据分析Web_FineUI.WebForm1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="表格"  PageSize="20" runat="server" 
            AllowPaging="true" IsDatabasePaging="true"  EnableCollapse="false"
            DataKeyNames="Id">
            <Columns>
               <%-- <f:RowNumberField />--%>
                <f:BoundField Width="100px" DataField="订单号" DataFormatString="{0}" HeaderText="订单号" />
                <f:BoundField Width="100px" DataField="客户" DataFormatString="{0}" HeaderText="客户" />
                <f:BoundField Width="100px" DataField="楞型" DataFormatString="{0}" HeaderText="楞型" />
                <f:BoundField Width="100px" DataField="订单数" DataFormatString="{0}" HeaderText="订单数" />
                <f:BoundField Width="100px" DataField="宽度" DataFormatString="{0}" HeaderText="宽度" />
                <f:BoundField Width="100px" DataField="长度" DataFormatString="{0}" HeaderText="长度" />
                <f:BoundField Width="100px" DataField="材质" DataFormatString="{0}" HeaderText="材质" />
                <f:BoundField Width="100px" DataField="门幅" DataFormatString="{0}" HeaderText="门幅" />
                <f:BoundField Width="100px" DataField="序号" DataFormatString="{0}" HeaderText="序号" />
                <f:BoundField Width="100px" DataField="备注" DataFormatString="{0}" HeaderText="备注" />
                <f:BoundField Width="100px" DataField="生产线" DataFormatString="{0}" HeaderText="生产线" />
            </Columns>
        </f:Grid>

    </form>
    

</body>
</html>