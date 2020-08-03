using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using excelToTable_NPOI;

namespace 综合保障中心.Comm
{
    public static class My
    {
        /// <summary>
        /// 显示错误弹窗
        /// </summary>
        /// <param name="mess"></param>
        public static void ShowErrorMessage(string mess)
        {
            MessageBox.Show(mess, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ExceptToExcel(string fileFullName, DataTable table)
        {
            return new ExcelHelper(fileFullName).DataTableToExcel_Zhuangche(table, null, true) > 0;
        }

      


        /// <summary>
        /// 获取单元格的值，或默认值
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static string GetCellDefault(DataGridViewCell cell)
        {
            string sssss = cell.OwningColumn.Name;
            string ss = cell.ValueType.Name;
            string value = "";
            switch (cell.ValueType.Name)
            {
                case "Boolean":
                    bool bll = cell.Value == null;
                    value = ((cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString())) ? "0" : (Convert.ToBoolean(cell.Value) ? "1" : "0"));
                    break;
                case "String":
                    value = cell.Value == null ? "" : cell.Value.ToString();
                    break;
                case "Int32":
                case "Int16":
                case "Int64":
                case "Double":
                    value = cell.Value == null ? "0" : cell.Value.ToString();
                    break;
                default:
                    value = cell.Value == null ? "" : cell.Value.ToString();
                    break;
            }

            return value;
        }
    }
}
