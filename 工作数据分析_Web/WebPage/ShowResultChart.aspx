<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ShowResultChart.aspx.cs" Inherits="WebPage_ShowResultChart" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:Chart ID="Chart1" runat="server" Height="406px" Width="899px">
        <Series>
            <asp:Series Label="#VAL" LabelForeColor="Red" Name="Series1" 
                ToolTip="#VALX入库#VAL平方" LabelAngle="30">
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
</asp:Content>

