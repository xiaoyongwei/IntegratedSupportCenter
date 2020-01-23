using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HanDe_ClassLibrary.Common.Path
{
    /// <summary>
    /// 此静态类提供了对路径分级的方法
    /// </summary>
     public static class GradingPath
    {
         /// <summary>
         /// 对于目录,读取路径的某一级段的目录名
         /// </summary>
         /// <param customerName="objPath">需要读取的路径名(必须以"\"分隔)</param>
         /// <param customerName="index">要读取的第几级段的目录名</param>
         /// <param customerName="gp">LTR:表示从左到右,RTL:表示从右到左</param>
         /// <param customerName="bl">表示是否检查当前目录是否存在.true:表示需要检查,false表示不需要检查</param>
         /// <returns>成功读取后的目录名</returns>
         public static string ReadDir(string path, int index, Direction gp,bool bl)
         {
             //判断路径是否存在
             if (bl)
             {
                 if (!Directory.Exists(path) || bl)
                 {
                     throw new Exception("目录不存在,请核实后再操作!");
                 }
             }
             return Read(path, index, gp);
         }
         /// <summary>
         /// 对于文件,读取路径的某一级段的目录名货文件名
         /// </summary>
         /// <param customerName="objPath">需要读取的路径名(必须以"\"分隔)</param>
         /// <param customerName="index">要读取的第几级段的目录名</param>
         /// <param customerName="gp">LTR:表示从左到右,RTL:表示从右到左</param>
         /// <param customerName="bl">表示是否检查当前文件是否存在.true:表示需要检查,false表示不需要检查</param>
         /// <returns>成功读取后的目录名或文件名</returns>
         public static string ReadFile(string path, int index, Direction gp,bool bl)
         {
             //判断路径是否存在
             if (bl)
             {
                 if (!File.Exists(path))
                 {
                     throw new Exception("文件不存在,请核实后再操作!");
                 }
             }
             return Read(path, index, gp);
         }


         //进行分级操作
         private static string Read(string path, int index, Direction gp)
         {
             string[] paths = path.Trim('\\').Split('\\');//路径每个级段的目录名
             //判断函数接收过来的级数参数是否在数组的索引范围内
             if (index <= 0 || index > paths.Length)
             {
                 throw new Exception("级数输入错误");
             }
             string pathName = null;
             switch (gp)
             {
                 case Direction.LTR:
                     pathName = paths[index - 1];
                     break;
                 case Direction.RTL:
                     pathName = paths[paths.Length - index];
                     break;
                 default:
                     break;
             }
             //如果当前级数的目录名还是空白的或者前级数的目录名不包含在原始路径参数里面,则操作失败
             if (pathName == null || path.IndexOf(pathName) == -1)
             {
                 throw new Exception("对路径进行级数操作时发生错误!\n请联系管理员进行修正!");
             }
             else
             {
                 return pathName;
             }
         }
    }


     /// <summary>
     /// 此枚举提供了从左到右还是从右到左读取的选择
     /// </summary>
     public enum Direction
     {
         /// <summary>
         /// 从左到右
         /// </summary>
         LTR,
         /// <summary>
         /// 从右到左
         /// </summary>
         RTL
     }
}
