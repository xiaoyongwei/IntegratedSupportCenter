using FineUIPro;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.WebPage.DataImportOutport
{
    public partial class DataImport : System.Web.UI.Page
    {
        private StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            //每次加载的时候删除超过24小时的上传的文件
            foreach (FileInfo file in new DirectoryInfo(Server.MapPath("~/upload/")).GetFiles())
            {
                if (file.LastWriteTime.AddHours(24)<DateTime.Now)
                {
                    file.Delete();
                }
            }
        }

        /// <summary>
        /// 显示通知对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageIcon"></param>
        public virtual void ShowNotify(string message, MessageBoxIcon messageIcon = MessageBoxIcon.Information)
        {
            Notify n = new Notify();
            n.Target = Target.Top;
            n.Message = message;
            n.MessageBoxIcon = messageIcon;
            n.PositionX = Position.Center;
            n.PositionY = Position.Top;
            n.DisplayMilliseconds = 5000;
            n.ShowHeader = false;


            n.Show();
        }
        protected readonly static List<string> VALID_FILE_TYPES = new List<string> { "xls", "jpg", "bmp", "gif", "jpeg", "png" };
        protected static bool ValidateFileType(string fileName)
        {
            string fileType = String.Empty;
            int lastDotIndex = fileName.LastIndexOf(".");
            if (lastDotIndex >= 0)
            {
                fileType = fileName.Substring(lastDotIndex + 1).ToLower();
            }

            if (VALID_FILE_TYPES.Contains(fileType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (FileUploadZhibanRukuExcel.HasFile)
            {
                string fileName = FileUploadZhibanRukuExcel.ShortFileName;

                if (Path.GetExtension(fileName) != ".xls")
                {
                    // 清空文件上传控件
                    FileUploadZhibanRukuExcel.Reset();

                    ShowNotify("无效的文件类型！", MessageBoxIcon.Error);
                   
                    return;
                }
                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                FileUploadZhibanRukuExcel.SaveAs(Server.MapPath("~/upload/" + fileName));


                labResult.Text = "<p>文件路径：" + FileUploadZhibanRukuExcel.FileName + "</p>";

                //// 清空表单字段（第一种方法）
                //tbxUserName.Reset();
                //FileUploadZhibanRukuExcel.Reset();

                // 清空表单字段（第三种方法）
                SimpleForm1.Reset();
            }
        }

        protected void FileUploadZhibanRukuExcel_FileSelected(object sender, EventArgs e)
        {
            if (FileUploadZhibanRukuExcel.HasFile)
            {
                string fileName = FileUploadZhibanRukuExcel.ShortFileName;
                string extension = Path.GetExtension(fileName);
                if (extension != ".xls" && extension != ".xlsx")
                {
                    ShowNotify("不是Excel文件！", MessageBoxIcon.Error);
                    
                    return;
                }
                if (!fileName.Contains("纸板入库明细"))
                {
                    ShowNotify("不是[纸板入库明细]文件！", MessageBoxIcon.Error);
                    return;
                }
                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                string fileFullName = "~/upload/" + fileName;

                FileUploadZhibanRukuExcel.SaveAs(Server.MapPath(fileFullName));



                DataTable table = new ExcelHelper(Server.MapPath(fileFullName)).ExcelToDataTableDaoru(true);


                if (table != null && table.Rows.Count > 0)
                {
                    //第一步先删除重复的工单
                    //第二步插入信息
                    string sqlDeleteTemp = "DELETE FROM `slbz`.`纸板管理入库明细`WHERE `生产单号`='{0}';";
                    List<string> sqlDeleteList = new List<string>();
                    string sqlInsertTemp = "INSERT INTO `slbz`.`纸板管理入库明细`" +
                        "(`仓库`,`日期`,`生产单号`,`材质`,`楞型`,`供应商`,`客户`,`产品`" +
                        ",`规格`,`数量`,`金额`,`备注`,`入库单号`,`平方价`,`单价`)VALUES(" +
                        "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'," +
                        "'{8}','{9}','{10}','{11}','{12}','{13}','{14}');";
                    List<string> sqlInsertList = new List<string>();


                    foreach (DataRow dr in table.Rows)
                    {
                        sqlDeleteList.Add(string.Format(sqlDeleteTemp, dr["生产单号"]));
                        sqlInsertList.Add(string.Format(sqlInsertTemp, dr["仓库"], dr["日期"], dr["生产单号"],
                            dr["材质"], dr["楞型"], dr["供应商"], dr["客户"], dr["产品"], dr["规格"],
                            dr["数量"], dr["金额"], dr["备注"], dr["入库单号"], dr["平方价"], dr["单价"]));
                    }
                    if (MySqlDbHelper.ExecuteSqlTran(sqlDeleteList))
                    { ShowNotify("删除重复生产单号成功!", MessageBoxIcon.Success); }

                    if (MySqlDbHelper.ExecuteSqlTran(sqlInsertList))
                    {
                        ShowNotify("导入[纸板管理入库明细]成功!", MessageBoxIcon.Success);
                    }
                    //删除上传的文件
                    File.Delete(Server.MapPath(fileFullName));
                }
            }
        }

        protected void FileUploadZhibanKucunExcel_FileSelected(object sender, EventArgs e)
        {
            if (FileUploadZhibanKucunExcel.HasFile)
            {
                string fileName = FileUploadZhibanKucunExcel.ShortFileName;
                string extension = Path.GetExtension(fileName);
                if (extension != ".xls" && extension != ".xlsx")
                {
                    ShowNotify("不是Excel文件！", MessageBoxIcon.Error);
                    return;
                }
                if (!fileName.Contains("纸板库存明细"))
                {
                    ShowNotify("不是[纸板库存明细]文件！", MessageBoxIcon.Error);
                    return;
                }
                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                string fileFullName = "~/upload/" + fileName;

                FileUploadZhibanKucunExcel.SaveAs(Server.MapPath(fileFullName));



                DataTable table = new ExcelHelper(Server.MapPath(fileFullName)).ExcelToDataTableDaoru(true);


                if (table!=null&&table.Rows.Count > 0)
                {
                    //第一步清空表格
                    //第二步插入信息

                    string sqlInsertTemp = "INSERT INTO `slbz`.`纸板管理库存明细`" +
                        "(`仓库`,`日期`,`生产单号`,`材质`,`楞型`,`供应商`,`客户`,`产品`" +
                        ",`规格`,`数量`,`金额`,`备注`,`单价`)VALUES(" +
                        "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'," +
                        "'{8}','{9}','{10}','{11}','{12}');";
                    List<string> sqlInsertList = new List<string>();
                    sqlInsertList.Add("truncate `slbz`.`纸板管理库存明细`;");

                    foreach (DataRow dr in table.Rows)
                    {
                        sqlInsertList.Add(string.Format(sqlInsertTemp, dr["仓库"], dr["日期"], dr["生产单号"],
                            dr["材质"], dr["楞型"], dr["供应商"], dr["客户"], dr["产品"], dr["规格"],
                            dr["数量"], dr["金额"], dr["备注"], dr["单价"]));
                    }
                   

                    if (MySqlDbHelper.ExecuteSqlTran(sqlInsertList))
                    {
                        ShowNotify("导入[纸板管理库存明细]成功!", MessageBoxIcon.Success);
                    }

                    //删除上传的文件
                    File.Delete(Server.MapPath(fileFullName));
                }
            }
        }

        protected void FileUploadChejianBaogongExcel_FileSelected(object sender, EventArgs e)
        {
            if (FileUploadChejianBaogongExcel.HasFile)
            {
                string fileName = FileUploadChejianBaogongExcel.ShortFileName;
                string extension = Path.GetExtension(fileName);
                if (extension != ".xls" && extension != ".xlsx")
                {
                    ShowNotify("不是Excel文件！", MessageBoxIcon.Error);
                    return;
                }
                if (!fileName.Contains("纸板入库明细"))
                {
                    ShowNotify("不是[纸板入库明细]文件！", MessageBoxIcon.Error);
                    return;
                }
                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                string fileFullName = "~/upload/" + fileName;

                FileUploadZhibanRukuExcel.SaveAs(Server.MapPath(fileFullName));



                DataTable table = new ExcelHelper(Server.MapPath(fileFullName)).ExcelToDataTableDaoru(true);


                if (table != null && table.Rows.Count > 0)
                {
                    //第一步先删除重复的工单
                    //第二步插入信息
                    string sqlDeleteTemp = "DELETE FROM `slbz`.`纸板管理入库明细`WHERE `生产单号`='{0}';";
                    List<string> sqlDeleteList = new List<string>();
                    string sqlInsertTemp = "INSERT INTO `slbz`.`纸板管理入库明细`" +
                        "(`仓库`,`日期`,`生产单号`,`材质`,`楞型`,`供应商`,`客户`,`产品`" +
                        ",`规格`,`数量`,`金额`,`备注`,`入库单号`,`平方价`,`单价`)VALUES(" +
                        "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'," +
                        "'{8}','{9}','{10}','{11}','{12}','{13}','{14}');";
                    List<string> sqlInsertList = new List<string>();


                    foreach (DataRow dr in table.Rows)
                    {
                        sqlDeleteList.Add(string.Format(sqlDeleteTemp, dr["生产单号"]));
                        sqlInsertList.Add(string.Format(sqlInsertTemp, dr["仓库"], dr["日期"], dr["生产单号"],
                            dr["材质"], dr["楞型"], dr["供应商"], dr["客户"], dr["产品"], dr["规格"],
                            dr["数量"], dr["金额"], dr["备注"], dr["入库单号"], dr["平方价"], dr["单价"]));
                    }
                    if (MySqlDbHelper.ExecuteSqlTran(sqlDeleteList))
                    { ShowNotify("删除重复生产单号成功!", MessageBoxIcon.Success); }

                    if (MySqlDbHelper.ExecuteSqlTran(sqlInsertList))
                    {
                        ShowNotify("导入[纸板管理入库明细]成功!", MessageBoxIcon.Success);
                    }
                    //删除上传的文件
                    File.Delete(Server.MapPath(fileFullName));
                }
            }
        }

        protected void FileUploadChengpinRukuExcel_FileSelected(object sender, EventArgs e)
        {

        }
    }
}