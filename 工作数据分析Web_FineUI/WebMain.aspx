<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMain.aspx.cs"
    Inherits="工作数据分析Web_FineUI.accordion_tree" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    
    
    
    <form id="form1" runat="server">
        <asp:Label ID="userName" runat="server">欢迎您:XXX,</asp:Label><asp:LinkButton runat="server" ID="changePassword">[注销]</asp:LinkButton>
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" IsFluid="true" CssClass="blockpanel" ShowBorder="false" runat="server" Margin="5px">
            <Regions>
                <f:Region ID="Region2" RegionSplit="true" RegionSplitHeaderClass="false" RegionPosition="Left" Width="200px" ShowHeader="false"
                    Title="目录" EnableCollapse="false" Layout="Fit" runat="server">
                    <Items>
                        <f:Accordion runat="server" ShowBorder="false" ShowHeader="false" ShowCollapseTool="true">
                            <Panes>
                                <f:AccordionPane runat="server" Title="工作台" IconUrl="~/res/images/16/1.png" BodyPadding="2px 5px"
                                    Layout="Fit">
                                    <Items>
                                        <f:Tree runat="server" ShowBorder="false" ShowHeader="false" ID="treeWork" EnableSingleClickExpand="true">
                                            <%-- <Listeners>
                                                <f:Listener Event="nodeclick" Handler="onTreeNodeClick" />
                                            </Listeners>--%>
                                        </f:Tree>
                                    </Items>
                                </f:AccordionPane> 
                                
                            </Panes>
                        </f:Accordion>
                    </Items>
                </f:Region>
                <f:Region ID="Region3" ShowHeader="false" EnableIFrame="true" 
                   IFrameUrl="~/About.aspx"
                    IFrameName="accordionmainframe" Position="Center" runat="server">
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/res/menu.xml"></asp:XmlDataSource>
    </form>
    <%--<script>

        var region3ClientID = '<%= Region3.ClientID %>';

        function onTreeNodeClick(event, nodeId) {
            var me = this;
            var nodeData = me.getNodeData(nodeId);

            if (nodeData.leaf && nodeData.href) {

                F(region3ClientID).setIFrameUrl(nodeData.href);

                event.preventDefault();
            }

        }

    </script>--%>
</body>
</html>