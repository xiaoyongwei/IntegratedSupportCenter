<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="ErqiChenpinKucun.aspx.cs" Inherits="WebPage_ErqiChenpinKucun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <%
        System.Data.DataTable dt = new System.Data.DataTable();
        dt = MySqlDbHelper.ExecuteDataTable("CALL `slbz`.`二期库存情况`();");
        if (dt.Rows.Count > 0)
        {
            Response.Write("二期库存情况<br/>");
            Response.Write(My.DataTableToHtml(My.Table_deletezero(dt), ""));
        }

         dt = MySqlDbHelper.ExecuteDataTable("SELECT `订单类型`,round(sum(`面积`))'面积',round(sum(`金额`))'金额'FROM `slbz`.`成品_库存明细` group by `订单类型`"
             +"UNION SELECT '汇总',ifnull(round(sum(`面积`)),0)'面积',ifnull(round(sum(`金额`)),0)'金额' FROM `slbz`.`成品_库存明细`;");
        if (dt.Rows.Count > 1)
        {
            Response.Write("各类型库存情况<br/>");
            Response.Write(My.DataTableToHtml(dt, ""));
        }

         dt = MySqlDbHelper.ExecuteDataTable("SELECT `业务员`,round(sum(`面积`))'面积',round(sum(`金额`))'金额'FROM `slbz`.`成品_库存明细` where `天数`between 0 and 30 group by `业务员`"
             +"UNION SELECT '汇总',ifnull(round(sum(`面积`)),0)'面积',ifnull(round(sum(`金额`)),0)'金额' FROM `slbz`.`成品_库存明细` where `天数`between 0 and 30");
        if (dt.Rows.Count > 1)
        {
            Response.Write("0-30天库存情况<br/>");
            Response.Write(My.DataTableToHtml(dt, ""));
        }

         dt = MySqlDbHelper.ExecuteDataTable("SELECT `业务员`,round(sum(`面积`))'面积',round(sum(`金额`))'金额'FROM `slbz`.`成品_库存明细` where `天数`between 31 and 60 group by `业务员`"
             +"UNION SELECT '汇总',ifnull(round(sum(`面积`)),0)'面积',ifnull(round(sum(`金额`)),0)'金额' FROM `slbz`.`成品_库存明细` where `天数`between 31 and 60");
        if (dt.Rows.Count > 1)
        {
            Response.Write("31-60天库存情况<br/>");
            Response.Write(My.DataTableToHtml(dt, ""));
        }

        dt = MySqlDbHelper.ExecuteDataTable("SELECT `业务员`,round(sum(`面积`))'面积',round(sum(`金额`))'金额'FROM `slbz`.`成品_库存明细` where `天数`between 61 and 90 group by `业务员`"
            +"UNION SELECT '汇总',ifnull(round(sum(`面积`)),0)'面积',ifnull(round(sum(`金额`)),0)'金额' FROM `slbz`.`成品_库存明细` where `天数`between 61 and 90");
        if (dt.Rows.Count > 1)
        {
            Response.Write("61-90天库存情况<br/>");
            Response.Write(My.DataTableToHtml(dt, ""));
        }

         dt = MySqlDbHelper.ExecuteDataTable("SELECT `业务员`,round(sum(`面积`))'面积',round(sum(`金额`))'金额'FROM `slbz`.`成品_库存明细` where `天数`between 91 and 120 group by `业务员`"
             +"UNION SELECT '汇总',ifnull(round(sum(`面积`)),0)'面积',ifnull(round(sum(`金额`)),0)'金额' FROM `slbz`.`成品_库存明细` where `天数`between 91 and 120");
        if (dt.Rows.Count > 1)
        {
            Response.Write("91-120天库存情况<br/>");
            Response.Write(My.DataTableToHtml(dt, ""));
        }

         dt = MySqlDbHelper.ExecuteDataTable("SELECT `业务员`,round(sum(`面积`))'面积',round(sum(`金额`))'金额'FROM `slbz`.`成品_库存明细` where `天数`> 120 group by `业务员`"+
             "UNION SELECT '汇总',ifnull(round(sum(`面积`)),0)'面积',ifnull(round(sum(`金额`)),0)'金额' FROM `slbz`.`成品_库存明细` where `天数`>120");
        if (dt.Rows.Count > 1)
        {
            Response.Write("121天及以上库存情况<br/>");
            Response.Write(My.DataTableToHtml(dt, ""));
        }
        %>
</asp:Content>

