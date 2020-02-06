<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Chart ID="Chart1" runat="server" Height="406px" Width="1300px">
        <Series>
            <asp:Series Label="#VAL" LabelForeColor="Red" Name="Series1" 
                ToolTip="#VALX入库#VAL平方">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Name="Title1" Text="成品仓库近30天入库情况">
            </asp:Title>
        </Titles>
    </asp:Chart>
    </form>
</body>
</html>
