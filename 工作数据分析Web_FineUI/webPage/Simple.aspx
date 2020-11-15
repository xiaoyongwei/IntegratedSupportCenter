<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simple.aspx.cs" Inherits="工作数据分析Web_FineUI.webPage.simple" MasterPageFile="~/master/Simple.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headCPH" runat="server">
    <meta name="sourcefiles" content="~/master/Simple.Master" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainCPH" runat="server">
    <f:Panel ID="Panel1" Title="位于内容页中" BoxFlex="1" Margin="0" runat="server"
        BodyPadding="10px" ShowBorder="true" ShowHeader="true">
        <Items>
            <f:Label ID="labResult" runat="server" Text="左侧树尚未选中">
            </f:Label>
            <f:Button runat="server" ID="Button1" EnablePostBack="false" Text="按钮的初始文本，在脚本中修改">
                <Listeners>
                    <f:Listener Event="click" Handler="onButton1Click" />
                </Listeners>
            </f:Button>
        </Items>
    </f:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptCPH" runat="server">
    <script>
        
        function onButton1Click() {
            F.notify({
                message: '你点击了内容页中的按钮',
                messageIcon: 'information',
                target: '_top',
                header: false,
                displayMilliseconds: 2000,
                positionX: 'center',
                positionY: 'center'
            });
        }

        var button1ClientID = '<%= Button1.ClientID %>';

        F.ready(function () {

            // 修改按钮的初始文本
            F(button1ClientID).setText('点击调用内容页中的脚本');

        });

    </script>
</asp:Content>