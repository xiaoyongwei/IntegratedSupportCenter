<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true"
    CodeFile="ShowResultWrite.aspx.cs" Inherits="WebPage_ShowResultWrite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">
     <br />
    <%
        string code = Request.QueryString.Count > 0 ? Request.QueryString["sqlcode"].ToString().Trim() : "";

        
        string sqlStr = "";
        string gridTitle = "";
        switch (code)
        {
            case "8":
                sqlStr = "CALL `slbz`.`二期特殊工艺订单`('1')";
                gridTitle = "特殊工艺订单";
                break;
            case "12":
                sqlStr = "CALL `slbz`.`二期未完工订单`('1');";
                gridTitle = "二期未完工订单";
                break;
            default:
                break;
        }
        System.Data.DataTable dt = MySqlDbHelper.ExecuteDataTable(sqlStr);

        if (gridTitle == "二期未完工订单")
        {
            dt.DefaultView.Sort = "所处工序";
        }
        Response.Write(gridTitle + "<br/>");
        Response.Write(My.DataTableToHtml(dt, ""));
    
    %>
   
    </asp:Panel>
</asp:Content>
