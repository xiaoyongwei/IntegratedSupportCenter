using FineUIPro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace 工作数据分析Web_FineUI
{
    public partial class accordion_tree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 绑定 XML 数据源到树控件
                treeWork.DataSource = XmlDataSource1;
                treeWork.DataBind();

                ResolveTreeNode(treeWork.Nodes);
            }
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