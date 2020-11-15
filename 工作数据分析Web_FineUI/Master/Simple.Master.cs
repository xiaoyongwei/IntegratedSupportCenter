using FineUIPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.Master
{
    public partial class Simple : System.Web.UI.MasterPage
    {
        public delegate void ProcessLeftTreeNodeClickDelegate(string treeNodeId, string treeNodeText);
        public ProcessLeftTreeNodeClickDelegate ProcessLeftTreeNodeClick
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Tree1_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            if (ProcessLeftTreeNodeClick != null)
            {
                ProcessLeftTreeNodeClick(e.NodeID, e.Node.Text);
            }
        }
    }
}