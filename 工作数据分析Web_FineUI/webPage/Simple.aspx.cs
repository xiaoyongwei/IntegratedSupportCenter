using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.Master;

namespace 工作数据分析Web_FineUI.webPage
{
    public partial class simple : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 每次页面加载（包括回发），都要进行设置
            ((Simple)Master).ProcessLeftTreeNodeClick = ProcessLeftTreeNodeClick;
            if (!IsPostBack)
            {
            }
        }

        public void ProcessLeftTreeNodeClick(string treeNodeId, string treeNodeText)
        {
            labResult.Text = "你点击了母版页中的树节点：" + treeNodeText;
           
        }
    }
}