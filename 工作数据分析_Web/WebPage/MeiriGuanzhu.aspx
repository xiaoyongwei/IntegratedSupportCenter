<%@ Page Title="" Language="C#" MasterPageFile="../Master/Site.master" AutoEventWireup="true"
    CodeFile="MeiriGuanzhu.aspx.cs" Inherits="WebPage_WebPageSpace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%
        System.Data.DataTable dt = MySqlDbHelper.ExecuteDataTable("CALL `slbz`.`二期未完工订单`();");

        //需要保留的列
        string[] delColumns = { "所处工序", "甩纸", "胶印", "覆膜", "过油", "瓦片", "裱胶", "压痕", "钉箱", "粘箱", "入库数", "订单特殊工艺", "计划交期", "生产单号", "客户", "产品", "数量" };

        for (int i = dt.Columns.Count - 1; i >= 0; i--)
        {
            if (!delColumns.Contains(dt.Columns[i].ColumnName))
            {
                dt.Columns.RemoveAt(i);
            }
        }

        System.Data.DataTable dt_temp = My.CopyDataTable(dt.Select("所处工序='待入库'"));
        if (dt_temp.Rows.Count > 0)
        {
            Response.Write("<asp:Panel ID='Panel1' runat='server' ScrollBars='Horizontal'>");
            Response.Write("已完工待入库订单<br/>");
            Response.Write(My.DataTableToHtml(dt_temp, "生产单号"));
            Response.Write("</asp:Panel>");
        }
        dt_temp = My.CopyDataTable(dt.Select("所处工序 like '%欠数%'"));
        if (dt_temp.Rows.Count > 0)
        {
            Response.Write("<asp:Panel ID='Panel2' runat='server' ScrollBars='Horizontal'>");
            Response.Write("入库欠数订单<br/>");
            Response.Write(My.DataTableToHtml(dt_temp, "生产单号"));
            Response.Write("</asp:Panel>");
        }
        dt_temp = My.CopyDataTable(dt.Select("生产单号 like '%.%'"));
        if (dt_temp.Rows.Count > 0)
        {
            Response.Write("<asp:Panel ID='Panel3' runat='server' ScrollBars='Horizontal'>");
            Response.Write("补单待入库订单<br/>");
            Response.Write(My.DataTableToHtml(dt_temp, "生产单号"));
            Response.Write("</asp:Panel>");
        }
    %>
</asp:Content>
