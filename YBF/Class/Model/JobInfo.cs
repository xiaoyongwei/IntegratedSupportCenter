using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YBF.Class.Model
{
    public class JobInfo
    {
        /// <summary>
        /// 作业的ID(唯一标识)
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 稿袋号
        /// </summary>
        public string Gdh { get; set; }
        /// <summary>
        /// 上机机台
        /// </summary>
        public string Sjjt { get; set; }
        /// <summary>
        /// 客户简称
        /// </summary>
        public string Khjc { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Cpmc { get; set; }
        /// <summary>
        /// 制造尺寸
        /// </summary>
        public string Zzcc { get; set; }
        /// <summary>
        /// 面纸尺寸
        /// </summary>
        public string Mzcc { get; set; }
        /// <summary>
        /// 色数1 (印刷色)
        /// </summary>
        public string Ss1 { get; set; }
        /// <summary>
        /// 色数2 (专色)
        /// </summary>
        public string Ss2 { get; set; }
        /// <summary>
        /// 晒版数
        /// </summary>
        public string Sbs { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Bz { get; set; }
        /// <summary>
        /// 咬口
        /// </summary>
        public string Yk { get; set; }
        /// <summary>
        /// 对应的Excel文件名称
        /// </summary>
        public string ExcelFile { get; set; }
        /// <summary>
        /// 标记是否出版
        /// </summary>
        public bool Published { get; set; }
    }
}
