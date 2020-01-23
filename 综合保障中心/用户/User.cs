using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 综合保障中心
{
    public static class User
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public static string UserPassWord { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public static string FullName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public static string Note { get; set; }

        public static bool 稿袋查看权限 { get; set; }
        public static bool 稿袋管理权限 { get; set; }
        public static bool 开单查看权限 { get; set; }
        public static bool 开单管理权限 { get; set; }
        public static bool 生产计划查看权限 { get; set; }
        public static bool 生产计划管理权限 { get; set; }
        public static bool 数码单查看权限 { get; set; }
        public static bool 数码单管理权限 { get; set; }
        public static bool 系统管理员权限 { get; set; }





    }
}
