<%@ Page Language="C#" MasterPageFile="../Master/Site.master" AutoEventWireup="true" CodeFile="GongdanPage.aspx.cs" Inherits="WebPage_GongdanPage" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
     <asp:Button ID="Button1" runat="server" Text="整单完工" onclick="Button1_Click" />
     &nbsp;<asp:Button ID="Button2" runat="server" Text="取消整单完工" 
         onclick="Button2_Click" />
     <%
        
            string gdh = Request.QueryString.Count > 0 ? Request.QueryString["gdh"].ToString().Trim() : "";
            
            if (string.IsNullOrWhiteSpace(gdh))
            {
                this.Button1.Enabled = false;
                this.Button2.Enabled = false;
            }
            else
            {
                Response.Write("&nbsp;");
                Response.Write(MySqlDbHelper.ExecuteScalar("CALL `slbz`.`判断订单是否完工`('" + gdh + "')")); ;
                Response.Write("<br/><br/>");
                
                System.Data.DataSet ds = MySqlDbHelper.ExecuteDataSet("CALL `slbz`.`订单page`('" + gdh + "')");
                foreach (System.Data.DataTable dt in ds.Tables)
                {
                    Response.Write(My.DataTableToHtml(dt, ""));
                }
            }
            
         %>
        
</asp:Content>