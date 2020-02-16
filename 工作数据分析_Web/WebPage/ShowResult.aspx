<%@ Page Language="C#" MasterPageFile="../Master/Site.master" AutoEventWireup="true"
    CodeFile="ShowResult.aspx.cs" Inherits="WebPage_ShowResult" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="Button1" runat="server" Text="下载Excel" OnClick="Button1_Click" Visible="False" />
    <br />
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
        <asp:GridView ID="GridView1" runat="server" CaptionAlign="Top" CellPadding="1" CellSpacing="1"
            PageSize="500">
        </asp:GridView>
        <%--<%
            string code = Request.QueryString.Count > 0 ? Request.QueryString["sqlcode"].ToString().Trim() : "";
            string sqlStr = "";
            string gridTitle = "";
            switch (code)
            {
                case "9":
                    sqlStr = "CALL `slbz`.`二期原纸仓库库存明细分类汇总`('A')";
                    gridTitle = "分类汇总(A类纸)";
                    break;
                case "10":
                    sqlStr = "CALL `slbz`.`二期原纸仓库库存明细分类汇总`('B')";
                    gridTitle = "分类汇总(B类纸)";
                    break;
                default:
                    break;
            }

            Response.Write(gridTitle + "<br/>");
            
            if (!string.IsNullOrWhiteSpace(sqlStr))
            {
                if (gridTitle.Contains("分类汇总("))
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt = MySqlDbHelper.ExecuteDataTable(sqlStr);
                    for (int i = dt.Columns.Count - 1; i >= 0; i--)
                    {
                        if (dt.Columns[i].ColumnName == "代码" || dt.Columns[i].ColumnName == "门幅")
                        {
                            continue;
                        }
                        int sum = 0;
                        foreach (System.Data.DataRow dr in dt.Rows)
                        {
                            try
                            {
                                sum += Convert.ToInt32(dr[i]);
                                if (sum > 0)
                                {
                                    continue;
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        if (sum == 0)
                        {
                            dt.Columns.RemoveAt(i);
                        }
                    }
                    Response.Write(My.DataTableToHtml( My.Table_zero(dt)));
                }
            }
        %>--%>
    </asp:Panel>
</asp:Content>
