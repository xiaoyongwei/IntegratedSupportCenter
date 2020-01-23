using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using NPOI.SS.Util;
using 综合保障中心.Comm;

namespace excelToTable_NPOI
{
    /// <summary>
    /// NPOI操作Excel文件的实例类
    /// </summary>
    class ExcelHelper : IDisposable
    {
        private string fileFullName = null; //文件名
        private IWorkbook workbook = null;
        //private bool disposed;

        /// <summary>
        /// 需要操作的Excel的文件全路径名称
        ///<para>需要导入或导出的Excel全路径名称</para>
        /// </summary>
        /// <param name="fileFullName"></param>
        public ExcelHelper(string fileFullName)
        {
            this.fileFullName = fileFullName;
            //disposed = false;
        }

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            FileStream fs = null;


            try
            {
                fs = new FileStream(fileFullName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (fileFullName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook();
                else if (fileFullName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook();
                if (workbook != null)
                {
                    if (string.IsNullOrWhiteSpace(sheetName))
                    {
                        sheet = workbook.CreateSheet("sheet1");
                    }
                    else
                    {
                        sheet = workbook.CreateSheet(sheetName);
                    }
                    
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="tableList">要导入的数据</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableListToExcel(List<DataTable> tableList)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            FileStream fs = null;

            try
            {
                if (fileFullName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook();
                else if (fileFullName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook();
                if (workbook == null)
                {
                    return -1;
                }
                foreach (DataTable table in tableList)
                {
                    if (table == null
                        || table.Rows.Count == 0
                        || table.Columns.Count == 0)
                    {
                        continue;
                    }

                    sheet = workbook.CreateSheet(string.IsNullOrWhiteSpace(table.TableName) ? Path.GetRandomFileName() : table.TableName);

                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < table.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(table.Columns[j].ColumnName);
                    }
                    count = 1;


                    for (i = 0; i < table.Rows.Count; ++i)
                    {
                        row = sheet.CreateRow(count);
                        for (j = 0; j < table.Columns.Count; ++j)
                        {
                            //ICell cell = row.CreateCell(j);
                            //switch (table.Columns[j].DataType.ToString())
                            //{
                            //    case "System.Int16":
                            //    case "System.Int32":
                            //    case "System.Int64":
                            //    case "System.Double":
                            //        cell.SetCellType(CellType.NUMERIC);
                            //        break;
                            //    default:
                            //        break;
                            //}
                            //cell.SetCellValue(table.Rows[i][j].ToString());
                            row.CreateCell(j).SetCellValue(table.Rows[i][j].ToString());
                        }
                        count++;
                    }
                }

                fs = new FileStream(fileFullName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <param name="isSpace">是否允许存在空格</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn, bool isSpace)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileFullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if (fileFullName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileFullName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            DataColumn column = new DataColumn(firstRow.GetCell(i).StringCellValue);
                            data.Columns.Add(column);
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            ICell icell = row.GetCell(j);
                            if (icell != null) //同理，没有数据的单元格都默认是null
                            {
                                if (icell.CellType == CellType.NUMERIC && DateUtil.IsCellDateFormatted(icell))
                                {
                                    dataRow[j] = icell.DateCellValue.ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    dataRow[j] = isSpace ? icell.ToString()
                                    : icell.ToString().Replace(" ", "");
                                }

                            }

                        }

                        data.Rows.Add(dataRow);
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
            return data;

        }

        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            if (fs != null)
        //                fs.Close();
        //        }

        //        fs = null;
        //        disposed = true;
        //    }
        //}


        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel_排车(DataTable data, string sheetName, bool isColumnWritten)
        {
            //先剔除不要的行和列
            if (data.Columns.Count>0)
            {
                data.Columns.Remove("估算运费");
            }


            int i = 0;
            int j = 0;
            int RowIndex = 0;
            ISheet sheet = null;
            FileStream fs = null;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            data.DefaultView.Sort = "理货单,生产单 DESC";
            try
            {
                fs = new FileStream(fileFullName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (fileFullName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook();
                else if (fileFullName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook();
                if (workbook != null)
                {
                    if (string.IsNullOrWhiteSpace(sheetName))
                    {
                        sheet = workbook.CreateSheet("sheet1");
                    }
                    else
                    {
                        sheet = workbook.CreateSheet(sheetName);
                    }
                }
                else
                {
                    return -1;
                }

                IRow row_temp = sheet.CreateRow(0);
                row_temp.CreateCell(0).SetCellValue("二期成品仓库排车发货日报表");
                IFont font = workbook.CreateFont();//字体
                font.FontHeightInPoints = 22;
                font.FontName = "微软雅黑";
                ICellStyle cellStyle = workbook.CreateCellStyle();//单元格格式
                cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                cellStyle.VerticalAlignment = VerticalAlignment.CENTER;
                cellStyle.SetFont(font);
                row_temp.Cells[0].CellStyle = cellStyle;


                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, data.Columns.Count - 2)); //合并第一行单元格
                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(1);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }

                    RowIndex = 2;
                }
                else
                {
                    RowIndex = 1;
                }

                //写入每个行数据
                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(RowIndex);
                    string cellValue = data.Rows[i][0].ToString();
                    if (dic.Keys.Contains(cellValue) && dic[cellValue] < RowIndex)
                    {
                        dic[cellValue] = RowIndex;
                    }
                    else
                    {
                        dic.Add(cellValue, RowIndex);
                    }
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++RowIndex;
                }
                //合并最后一行单元格
                sheet.AddMergedRegion(new CellRangeAddress(sheet.LastRowNum, sheet.LastRowNum, 0, data.Columns.Count - 2));
                font = workbook.CreateFont();
                font.FontHeightInPoints = 16;
                font.Color = 10;
                sheet.GetRow(sheet.LastRowNum).Cells[0].CellStyle = cellStyle;
                cellStyle = workbook.CreateCellStyle();//单元格格式
                cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                cellStyle.VerticalAlignment = VerticalAlignment.CENTER;
                cellStyle.SetFont(font);
                sheet.GetRow(sheet.LastRowNum).Cells[0].CellStyle = cellStyle;
                //合并相关联的所有单元格
                string[] hebingdanyuange = { "理货单", "1期平方", "2期平方", "总平方", "2期占比", "报货人", "司机", "车辆归属" };
                string zhuagnchedanhao = "";
                int firstIndex = 0;
                int lastIndex = 0;
                for (int index = 0; index < data.Rows.Count; index++)
                {

                    DataRow dr = data.Rows[index];
                    if (dr["理货单"].ToString() != zhuagnchedanhao)
                    {
                        for (int dcIndex = 0; dcIndex < data.Columns.Count; dcIndex++)
                        {
                            if (hebingdanyuange.Contains(data.Columns[dcIndex].ColumnName) && !string.IsNullOrWhiteSpace(zhuagnchedanhao))
                            {
                                sheet.AddMergedRegion(new CellRangeAddress(firstIndex + 2, lastIndex + 2, dcIndex, dcIndex));
                            }
                        }
                        firstIndex = index;
                        lastIndex = index;
                        zhuagnchedanhao = dr["理货单"].ToString();
                    }
                    else
                    {
                        lastIndex = index;
                    }
                }

                //所有单元格都水平垂直居中
                ICellStyle zhengwenCellStyle = workbook.CreateCellStyle();//单元格格式
                zhengwenCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                zhengwenCellStyle.VerticalAlignment = VerticalAlignment.CENTER;
                IFont zhengwenFont = workbook.CreateFont();//正文字体
                zhengwenFont.FontName = "宋体";
                zhengwenFont.FontHeightInPoints = 12;
                zhengwenCellStyle.SetFont(zhengwenFont);
                for (int ri = 1; ri <= data.Rows.Count; ri++)
                {
                    for (int ci = 0; ci < sheet.GetRow(ri).LastCellNum; ci++)
                    {
                        sheet.GetRow(ri).Cells[ci].CellStyle = zhengwenCellStyle;
                    }
                }
                //设置标题为加粗 
                //标题加粗
                IFont biaotiFont = workbook.CreateFont();
                biaotiFont.Boldweight = 700;
                ICellStyle biaoticellstyle = workbook.CreateCellStyle();
                biaoticellstyle.SetFont(biaotiFont);
                biaoticellstyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                biaoticellstyle.VerticalAlignment = VerticalAlignment.CENTER;
                biaotiFont.FontName = "宋体";
                biaotiFont.FontHeightInPoints = 12;
                biaotiFont.Boldweight = 700;
                biaoticellstyle.SetFont(biaotiFont);
                for (int ci = 0; ci < sheet.GetRow(1).LastCellNum; ci++)
                {
                    sheet.GetRow(1).Cells[ci].CellStyle = biaoticellstyle;
                }
                //设置列的颜色
                //for (int ci = 0; ci < sheet.GetRow(1).LastCellNum; ci++)
                //{
                //    switch (data.Columns[ci].ColumnName)
                //    {
                //        case "二期占比":
                //            ICellStyle cs1 = workbook.CreateCellStyle();//单元格格式
                //            cs1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                //            cs1.VerticalAlignment = VerticalAlignment.CENTER;
                //            cs1.SetFont(zhengwenFont);
                //            cs1.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.BRIGHT_GREEN.index;
                //            cs1.FillPattern = FillPatternType.SOLID_FOREGROUND;
                //            for (int ri = 1; ri <= data.Rows.Count; ri++)
                //            {
                //                sheet.GetRow(ri).Cells[ci].CellStyle = cs1;
                //            }
                //            break;
                //        case "司机":
                //            ICellStyle cs2 = workbook.CreateCellStyle();//单元格格式
                //            cs2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                //            cs2.VerticalAlignment = VerticalAlignment.CENTER;
                //            cs2.SetFont(zhengwenFont);
                //            cs2.FillBackgroundColor = 43;
                //            for (int ri = 1; ri <= data.Rows.Count; ri++)
                //            {
                //                sheet.GetRow(ri).Cells[ci].CellStyle = cs2;
                //            }
                //            break;
                //        case "车辆归属":
                //            ICellStyle cs3 = workbook.CreateCellStyle();//单元格格式
                //            cs3.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                //            cs3.VerticalAlignment = VerticalAlignment.CENTER;
                //            cs3.FillBackgroundColor = 47;
                //            for (int ri = 1; ri <= data.Rows.Count; ri++)
                //            {
                //                sheet.GetRow(ri).Cells[ci].CellStyle = cs3;
                //            }
                //            break;
                //        default:
                //            break;
                //    }

                //}


                workbook.Write(fs); //写入到excel
                return RowIndex;
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
                return -1;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }
    }
}