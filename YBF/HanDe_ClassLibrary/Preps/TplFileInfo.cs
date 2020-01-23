using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HandeJobManager.Common;
using HanDe_ClassLibrary.Common.Unit;
using HanDe_ClassLibrary.LogCommon;

namespace HanDe_ClassLibrary.PrinergyEvoFile.Preps
{
    public class TplFileInfo
    {
        /// <summary>
        /// tpl文件的绝对路径
        /// </summary>
        public string TplFullPath { get; set; }
        /// <summary>
        /// 模板名称(实际上就是不带扩展名的文件名)
        /// </summary>
        private string tplName;
        /// <summary>
        /// 模板文件名称(实际上就是带扩展名的文件名)
        /// </summary>
        private string tplFileName;
        /// <summary>
        /// 帖名
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 印张宽度
        /// </summary>
        public double SheetWidth { get; set; }
        /// <summary>
        /// 印张高度
        /// </summary>
        public double SheetHeight { get; set; }
        /// <summary>
        /// 信息条距离咬口位置
        /// </summary>
        private double markSeat;
        /// <summary>
        /// 页面宽度
        /// </summary>
        public double PageWidth { get; set; }
        /// <summary>
        /// 页面高度
        /// </summary>
        public double PageHeight { get; set; }

        private int direction;
        /// <summary>
        /// 页面方向,分别是4,5,6,7这4个数字表示咬口位置
        /// 4:左边,5:上面,6:右边,7:下面
        /// </summary>
        public int Direction
        {
            get { return direction; }
            set 
            {
                if (value>=4&&value<=7)
                {
                    this.direction = value;
                }
                else
                {
                    this.direction = 7; 
                }
            }
        }

        
        /// <summary>
        /// 左边空余
        /// </summary>
        public double LeftFree { get; set; }
        /// <summary>
        /// 页面水平占用
        /// </summary>
        public double PageHorizontal { get; set; }
        
        /// <summary>
        /// 右边空余
        /// </summary>
        public double RightFree{ get; set; }
        /// <summary>
        /// 咬口
        /// </summary>
        public double Bite { get; set; }
        /// <summary>
        /// 页面垂直占用
        /// </summary>
        public double PagePerpendicular { get; set; }
        
        /// <summary>
        /// 上面空余
        /// </summary>
        public double TopFree{ get; set; }


        /// <summary>
        /// 【页面水平放置方式】
        /// 居中是14,有靠身是2.
        /// </summary>
        public int HorizontalType { get; set; }


        /// <summary>
        /// 实例化一个tpl文件实例
        /// </summary>
        /// <param customerName="tplFullPath">tpl文件的绝对路径</param>
        /// <param customerName="sheetWidth">印张宽度(需要转换为pt单位的数值)</param>
        /// <param customerName="sheetHeight">印张高度(需要转换为pt单位的数值)</param>
        /// <param customerName="pageWidth">页面宽度(需要转换为pt单位的数值)</param>
        /// <param customerName="pageHeight">页面高度(需要转换为pt单位的数值)</param>
        /// <param customerName="direction">页面方向</param>
        /// <param customerName="bite">咬口(需要转换为pt单位的数值)</param>
        /// <param customerName="horizontalType">【页面水平放置方式】居中是14,有靠身是2.</param>
        public TplFileInfo
            (string tplFullPath
            , double sheetWidth
            , double sheetHeight
            , double pageWidth
            , double pageHeight
            , int direction
            , double bite
            , int horizontalType)
        {
            //tpl文件的绝对路径
            FileInfo fileInfo = new FileInfo(tplFullPath);
            this.TplFullPath = SetTplFullPath(fileInfo.FullName);
            //模板文件名称
            this.tplFileName = fileInfo.Name;
            //模板名称
            this.tplName = Path.GetFileNameWithoutExtension(tplFullPath);
            //印张宽度
            this.SheetWidth = sheetWidth;
            //印张高度
            this.SheetHeight = sheetHeight;
            //页面高度
            this.PageHeight = pageHeight;
            //页面宽度
            this.PageWidth = pageWidth;
            //页面方向
            this.Direction = direction;
            
            //页面水平占用, 页面垂直占用
            if (this.Direction==4||this.Direction==6)
            {
                this.PageHorizontal = this.PageHeight;
                this.PagePerpendicular = this.PageWidth;
            }
            else
            {
                this.PageHorizontal = this.PageWidth; 
                this.PagePerpendicular = this.PageHeight;
            }

            //左边空余
            this.LeftFree = (this.SheetWidth - this.PageHorizontal) / 2;
            //右边空余
            this.RightFree = this.LeftFree;
            //咬口
            this.Bite = bite;
            // 上面空余
            this.TopFree = Math.Round(this.SheetHeight - this.Bite - this.PagePerpendicular,5);
            //帖名
            this.Signature = Math.Round(this.SheetWidth * ConversionConstant.MM_PER_PT).ToString()
                + "x"
                + Math.Round(this.SheetHeight * ConversionConstant.MM_PER_PT).ToString()
                + "-"
                + Math.Round(this.Bite * ConversionConstant.MM_PER_PT).ToString();            
            //信息条距离咬口位置
            this.markSeat = (this.Bite - 75 >= 35) ? 22 : (this.Bite - 83);

            this.HorizontalType = 14;
        
        }

        /// <summary>
        /// 制作tpl文件
        /// </summary>
        /// <returns></returns>
        public bool MakeTplFile()
        {

            try
            {
                //string tplCon = "%!PS\r\n% This: 模板文件: 【tpl文件的绝对路径】\r\n%%FileEncoding: 134217984\r\n%%Creator: Preps 5.3.2   Windows Win32\r\n%SSiPrepsVer: 1\r\n%SSiLayout: |【模版名称】| |【模板文件名称】| 1 1 841.88970 595.27560 8 ''\r\n%SSiPressSheet: 【印张宽度】 【印张高度】 0.00000 141.73230 0 283.46460 1 17.00800 0\r\n%SSiPrshPage: 0.00000 0.00000 0.00000 0.00000 3 1 2 8.50400 8.50400 8.50400 8.50400 24580 0.00000 1.00000 0.00000 1 0.00000 0.00000 1\r\n%SSiSignature: |【帖名】| 1 6 1 1 ''\r\n%SSiPressSheet: 【印张宽度】 【印张高度】 0.00000 0.00000 3 283.46457 4 0.00000 2\r\n%SSiSmartMarkStart:  3 2\r\ncustomerName: |无标题_自定义|\r\ntext: |信息条-1.eps|\r\ndupflags: 33\r\nsigstart: 1\r\nsigmod: 1\r\ncolortype: 0\r\ncolor1: 100\r\ncolor2: 100\r\ncolor3: 100\r\ncolor4: 100\r\nrotation: 0\r\nsmartoffsetx: 0.00000\r\nsmartoffsety: 【信息条距离咬口位置】\r\nrefentity: 2\r\nrefanchor: 6\r\nmarkanchor: 6\r\nsection: 0\r\nwidth: 1345.23050\r\nheight: 53.37750\r\norigingroup: ||\r\n%SSiSmartMarkEnd:\r\n%SSiSmartMarkStart:  3 1\r\ncustomerName: |111|\r\ntext: |$jobname-$sig|\r\ndupflags: 33\r\nsigstart: 1\r\nsigmod: 1\r\ncolortype: 0\r\ncolor1: 100\r\ncolor2: 100\r\ncolor3: 100\r\ncolor4: 100\r\nrotation: 0\r\nsmartoffsetx: 8.50394\r\nsmartoffsety: 28.34646\r\nrefentity: 2\r\nrefanchor: 7\r\nmarkanchor: 7\r\nsection: 0\r\nwidth: 52.00000\r\nheight: 8.00000\r\norigingroup: |????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????M\r\nflatid: true\r\nverticaltext: false\r\ntextscriptsystem: 2\r\n%SSiSmartMarkEnd:\r\n%SSiPrshMatrix: 1 1.00000 0.00000 1\r\n%SSiPrshMatrix: 8 【页面宽度】 0.00000 1\r\n%SSiPrshMatrix: 9 【页面高度】 0.00000 1\r\n%SSiPrshMatrix: 11 0.00000 0.00000 1\r\n%SSiPrshMatrix: 10 1.00000 0.00000 1\r\n%SSiPrshMatrix: 12 【页面方向】 0.00000 1\r\n%SSiPrshMatrix: 【页面水平放置方式】 0.00000 0.00000 1\r\n%SSiPrshMatrix: 4 【左边空余】 0.00000 3\r\n%SSiPrshMatrix: 5 【页面水平占用】 0.00000 1\r\n%SSiPrshMatrix: 4 0.00000 【右边空余】 3\r\n%SSiPrshMatrix: 3 0.00000 0.00000 1\r\n%SSiPrshMatrix: 4 【咬口】 0.00000 2\r\n%SSiPrshMatrix: 5 【页面垂直占用】 0.00000 0\r\n%SSiPrshMatrix: 4 0.00000 【上面空余】 2\r\n%SSiPrshPage: 【左边空余】 【咬口】 【页面宽度】 【页面高度】 【页面方向】 1 0 8.50400 8.50400 8.50400 8.50400 24580 0.00000 1.00000 0.00000 1 0.00000 0.00000 1\r\n%SSiPrshMatrix: 7 -1.00000 0.00000 0\r\n";
                string tplCon = "%!PS\r\n% This: 模板文件:【tpl文件的绝对路径】\r\n%%FileEncoding: 134217984\r\n%%Creator: Preps 5.3.2   Windows Win32\r\n%SSiPrepsVer: 1\r\n%SSiLayout: |【模版名称】| |【模板文件名称】| 1 1 841.88970 595.27560 8 ''\r\n%SSiPressSheet: 【印张宽度】 【印张高度】 0.00000 141.73230 0 283.46460 1 17.00800 0\r\n%SSiPrshPage: 0.00000 0.00000 0.00000 0.00000 3 1 2 8.50400 8.50400 8.50400 8.50400 24580 0.00000 1.00000 0.00000 1 0.00000 0.00000 1\r\n%SSiSignature: |【帖名】| 1 6 1 1 ''\r\n%SSiPressSheet: 【印张宽度】 【印张高度】 0.00000 0.00000 3 283.46457 4 0.00000 3\r\n%SSiSmartMarkStart:  3 1\r\nname: |111|\r\ntext: |$jobname-$sig|\r\ndupflags: 33\r\nsigstart: 1\r\nsigmod: 1\r\ncolortype: 0\r\ncolor1: 100\r\ncolor2: 100\r\ncolor3: 100\r\ncolor4: 100\r\nrotation: 0\r\nsmartoffsetx: 8.50394\r\nsmartoffsety: 28.34646\r\nrefentity: 2\r\nrefanchor: 7\r\nmarkanchor: 7\r\nsection: 0\r\nwidth: 52.00000\r\nheight: 8.00000\r\norigingroup: |????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????M|\r\nflatid: true\r\nverticaltext: false\r\ntextscriptsystem: 2\r\n%SSiSmartMarkEnd:\r\n%SSiSmartMarkStart:  3 2\r\nname: |无标题_自定义|\r\ntext: |信息条-1.eps|\r\ndupflags: 33\r\nsigstart: 1\r\nsigmod: 1\r\ncolortype: 0\r\ncolor1: 100\r\ncolor2: 100\r\ncolor3: 100\r\ncolor4: 100\r\nrotation: 0\r\nsmartoffsetx: 0.00000\r\nsmartoffsety: 【信息条距离咬口位置】\r\nrefentity: 2\r\nrefanchor: 6\r\nmarkanchor: 6\r\nsection: 0\r\nwidth: 1345.23050\r\nheight: 53.37750\r\norigingroup: ||\r\n%SSiSmartMarkEnd:\r\n%SSiSmartMarkStart:  3 1\r\nname: |111567456734|\r\ntext: |$jobname-$sig|\r\ndupflags: 33\r\nsigstart: 1\r\nsigmod: 1\r\ncolortype: 0\r\ncolor1: 100\r\ncolor2: 100\r\ncolor3: 100\r\ncolor4: 100\r\nrotation: 0\r\nsmartoffsetx: 8.50394\r\nsmartoffsety: -22.67717\r\nrefentity: 2\r\nrefanchor: 1\r\nmarkanchor: 1\r\nsection: 0\r\nwidth: 88.00000\r\nheight: 8.00000\r\norigingroup: |????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????M|\r\nflatid: true\r\nverticaltext: false\r\ntextscriptsystem: 2\r\n%SSiSmartMarkEnd:\r\n%SSiPrshMatrix: 1 1.00000 0.00000 1\r\n%SSiPrshMatrix: 8 【页面宽度】 0.00000 1\r\n%SSiPrshMatrix: 9 【页面高度】 0.00000 1\r\n%SSiPrshMatrix: 11 0.00000 0.00000 1\r\n%SSiPrshMatrix: 10 1.00000 0.00000 1\r\n%SSiPrshMatrix: 12 【页面方向】 0.00000 1\r\n%SSiPrshMatrix: 【页面水平放置方式】 0.00000 0.00000 1\r\n%SSiPrshMatrix: 4 【左边空余】 0.00000 3\r\n%SSiPrshMatrix: 5 【页面水平占用】 0.00000 1\r\n%SSiPrshMatrix: 4 0.00000 【右边空余】 3\r\n%SSiPrshMatrix: 3 0.00000 0.00000 1\r\n%SSiPrshMatrix: 4 【咬口】 0.00000 2\r\n%SSiPrshMatrix: 5 【页面垂直占用】 0.00000 0\r\n%SSiPrshMatrix: 4 0.00000 【上面空余】 2\r\n%SSiPrshPage: 【左边空余】 【咬口】 【页面宽度】 【页面高度】 【页面方向】 1 0 8.50400 8.50400 8.50400 8.50400 24580 0.00000 1.00000 0.00000 1 0.00000 0.00000 1\r\n%SSiPrshMatrix: 7 -1.00000 0.00000 0\r\n";
                tplCon = tplCon.Replace("【tpl文件的绝对路径】", this.TplFullPath);
                tplCon = tplCon.Replace("【模版名称】", this.tplName);
                tplCon = tplCon.Replace("【模板文件名称】", this.tplFileName);
                tplCon = tplCon.Replace("【印张宽度】", this.SheetWidth.ToString());
                tplCon = tplCon.Replace("【印张高度】", this.SheetHeight.ToString());
                tplCon = tplCon.Replace("【帖名】", this.Signature);
                tplCon = tplCon.Replace("【信息条距离咬口位置】", this.markSeat.ToString());
                tplCon = tplCon.Replace("【页面宽度】", this.PageWidth.ToString());
                tplCon = tplCon.Replace("【页面高度】", this.PageHeight.ToString());
                tplCon = tplCon.Replace("【页面方向】", this.Direction.ToString());
                tplCon = tplCon.Replace("【左边空余】", this.LeftFree.ToString());
                tplCon = tplCon.Replace("【页面水平占用】", this.PageHorizontal.ToString());
                tplCon = tplCon.Replace("【右边空余】", this.RightFree.ToString());
                tplCon = tplCon.Replace("【咬口】", this.Bite.ToString());
                tplCon = tplCon.Replace("【页面垂直占用】", this.PagePerpendicular.ToString());
                tplCon = tplCon.Replace("【上面空余】", this.TopFree.ToString());
                tplCon = tplCon.Replace("【页面水平放置方式】", this.HorizontalType.ToString());
                
                File.WriteAllText(this.TplFullPath, tplCon);
            }
            catch (Exception ex)
            {
               Log.WriteLog(ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// 给模板文件的全路径赋值
        /// 截断到300的长度(只是文件名,不包括路径)
        /// </summary>
        /// <param customerName="tplName">需要优化的模板的全路径</param>
        /// <returns>返回优化后的模板全路径名称</returns>
        private string SetTplFullPath(string tplFileFullName)
        {
            string tplName = string.Empty;
            string tplFullName = Path.GetFileNameWithoutExtension(tplFileFullName);
            foreach (char item in tplFullName)
            {
                string tempStr = tplName + item.ToString();
                if (Uri.EscapeDataString(tempStr).Length < 300)
                {
                    tplName = tempStr;
                }
                else
                {
                    break;
                }
            }
            return Path.GetDirectoryName(tplFileFullName)+"\\" + tplName + ".tpl";
        }


    }
}
    

