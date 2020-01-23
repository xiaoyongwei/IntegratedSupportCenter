using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanDe_ClassLibrary.Rule
{
    /// <summary>
    /// 路径和文件名的规则
    /// </summary>
    [Serializable]
    public class PathAndFileNameRule
    {
        /// <summary>
        /// 等于
        /// </summary>
        public string DengYu { get; set; }
        /// <summary>
        /// 不等于
        /// </summary>
        public string BuDengYu { get; set; }
        /// <summary>
        /// 包含
        /// </summary>
        public string BaoHan { get; set; }
        /// <summary>
        /// 不包含
        /// </summary>
        public string BuBaoHan { get; set; }
        /// <summary>
        /// 开头是
        /// </summary>
        public string KaiTouShi { get; set; }
        /// <summary>
        /// 开头不是
        /// </summary>
        public string KaiTouBuShi { get; set; }
        /// <summary>
        /// 结尾是
        /// </summary>
        public string JieWeiShi { get; set; }
        /// <summary>
        /// 结尾不是
        /// </summary>
        public string JieWeiBuShi { get; set; }
    }
}
