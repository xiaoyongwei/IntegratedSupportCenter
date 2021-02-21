using FineUIPro;
using System;

namespace 工作数据分析Web_FineUI
{
    public partial class accordion_tree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"]==null||string.IsNullOrWhiteSpace(Session["username"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("~/WebPage/Login/Login.aspx");
            }
            else
            {
                Workbench.Title = "欢迎:" + Session["username"];
            }


            if (!IsPostBack)
            {
                // 绑定 XML 数据源到树控件
                treeWork.DataSource = XmlDataSource1;
                treeWork.DataBind();

                ResolveTreeNode(treeWork.Nodes);
            }
            Title = DateTime.Now.ToString();
        }

        private void ResolveTreeNode(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    if (!String.IsNullOrEmpty(node.NavigateUrl))
                    {
                        node.Target = "accordionmainframe";
                    }
                }
                else
                {
                    ResolveTreeNode(node.Nodes);
                }
            }

        }
    }
}