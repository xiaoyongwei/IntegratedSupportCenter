using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanDe_ClassLibrary.Rule
{
    /// <summary>
    /// 精炼规则
    /// </summary>
    [Serializable]
    public class RefineRule
    {
        /// <summary>
        /// 路径和文件名规则列表
        /// </summary>
        public List<PathAndFileNameRule> PathAndFileNameRuleList { get; set; }
        /// <summary>
        /// 是否叠印
        /// </summary>
        public bool OverPrinting { get; set; }
    }
}
