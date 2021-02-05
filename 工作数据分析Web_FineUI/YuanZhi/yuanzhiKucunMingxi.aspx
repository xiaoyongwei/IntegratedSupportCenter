<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yuanzhiKucunMingxi.aspx.cs" Inherits="工作数据分析Web_FineUI.YuanZhi.yuanzhi1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>二期原纸库存明细</title>
</head>
<body>
   <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" IsFluid="true" CssClass="blockpanel" Title="表格"  EnableCollapse="false"  ForceFit="true" ShowBorder="true" ShowHeader="true"
             AllowPaging="true" IsDatabasePaging="true" runat="server"  ShowPagingMessage="false" >
            <Columns>
               <%-- <f:RowNumberField />
                <f:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                <f:TemplateField Width="100px" HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField Width="100px" DataField="EntranceYear" HeaderText="入学年份" />
                <f:CheckBoxField Width="100px" RenderAsStaticField="true" DataField="AtSchool" HeaderText="是否在校" />
                <f:HyperLinkField HeaderText="所学专业" DataToolTipField="Major" DataTextField="Major"
                    DataTextFormatString="{0}" DataNavigateUrlFields="Major" DataNavigateUrlFormatString="http://gsa.ustc.edu.cn/search?q={0}" UrlEncode="true"
                    Target="_blank" ExpandUnusedSpace="true" MinWidth="150px" />
                <f:ImageField Width="100px" DataImageUrlField="Group" DataImageUrlFormatString="~/res/images/16/{0}.png"
                    HeaderText="分组">
                </f:ImageField>--%>
            </Columns>
        </f:Grid>
        </form>
</body>
</html>
