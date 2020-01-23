using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HanDe_ClassLibrary.PrinergyEvoFile.Preps;
using HanDe_ClassLibrary.PrepressFile.Adobe.Acrobat;
using System.IO;
using System.Text.RegularExpressions;
using YBF.Properties;
using Aspose.Pdf;



namespace HanDe_ClassLibrary.PrinergyEvoFile.Preps
{
    public static class JobDefinitionFormat
    {
        private static string GetPointString(double mm)
        {
            return Math.Round(mm * 72 / 25.4, 5).ToString();
        }
        private static string GetMilliMetreString(double pt)
        {
            return Math.Round(pt * 25.4 / 72, 5).ToString();
        }
        /// <summary>
        /// 生成JDF文件
        /// </summary>
        /// <param name="pdfFullName">PDF文件的全路径名称</param>
        /// <param name="JDFMarksFlatsPdf">JDF标记文件的全路径名称</param>
        /// <param name="BleedMargin">出血(单位:毫米)</param>
        /// <param name="Bite">咬口(单位:毫米)</param>
        /// <param name="SheetWidth">板材宽度(单位:毫米)</param>
        /// <param name="SheetHeight">板材高度(单位:毫米)</param>
        /// <param name="PageWidth">PDF文件的宽度(单位:毫米)</param>
        /// <param name="PageHeight">PDF文件的高度(单位:毫米)</param>
        /// <param name="outPath">JDF文件的输出路径</param>
        /// <param name="xuanzhuan">旋转</param>
        public static void MakeJDF(string pdfFullName, string JDFMarksFlatsPdf, double BleedMargin, double Bite
            , double SheetWidth, double SheetHeight, double PageWidth, double PageHeight, string outPath, Rotation xuanzhuan)
        {
            StringBuilder JdfTemplate =
                new StringBuilder(YBF.Properties.Resources.JdfTemplate);
            //匹配所有GUID
            //  \*GUID_\d\d\d\*
            Regex regex = new Regex(@"\*GUID_\d\d\d\*");
            List<string> guidList = new List<string>();
            foreach (Match item in regex.Matches(JdfTemplate.ToString()))
            {
                if (!guidList.Contains(item.Value))
                {
                    guidList.Add(item.Value);
                }
            }
            foreach (string guid in guidList)
            {
                JdfTemplate.Replace(guid, "A" + Guid.NewGuid().ToString());
            }
            //开始匹配各个单独数据
            //2018-07-30T02:24:12+08:00
            JdfTemplate.Replace("*文件名称*", Path.GetFileNameWithoutExtension(pdfFullName))//PDF绝对路径
            .Replace("*时间_000*", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .Replace("*出血页边空白*", GetPointString(BleedMargin))
            .Replace("*印张宽度*", GetPointString(SheetWidth))
            .Replace("*印张高度*", GetPointString(SheetHeight))
            .Replace("*左边空余*", GetPointString((SheetWidth - PageWidth) / 2))
            .Replace("*下面空余*", GetPointString(Bite))
            .Replace("*内容显示框_左*", GetPointString((SheetWidth - PageWidth) / 2 - BleedMargin))
            .Replace("*内容显示框_下*", GetPointString((Bite - BleedMargin)))
            .Replace("*内容显示框_右*", GetPointString((SheetWidth + PageWidth) / 2 + BleedMargin))
            .Replace("*内容显示框_上*", GetPointString(Bite + PageHeight + BleedMargin))
            .Replace("*成品左边界限*", GetPointString((SheetWidth - PageWidth) / 2))
            .Replace("*成品下边界限*", GetPointString(Bite))
            .Replace("*成品右边界限*", GetPointString((SheetWidth + PageWidth) / 2))
            .Replace("*成品上边界限*", GetPointString(Bite + PageHeight))
            .Replace("*成品宽度*", GetPointString(PageWidth))
            .Replace("*成品高度*", GetPointString(PageHeight))
            .Replace("*出版PDF全路径*", Uri.EscapeDataString(pdfFullName.Replace('/', '\\')).Replace("%5C", "/"))
            .Replace("*标记PDF全路径*", Uri.EscapeDataString(JDFMarksFlatsPdf).Replace("%5C", "/"));
            //匹配方向和定位
            string direction = "1 0. 0. 1";
            string ctm1 = GetPointString((SheetWidth - PageWidth) / 2);
            string ctm2 = GetPointString(Bite);
            switch (xuanzhuan)
            {
                case Rotation.on180:
                    direction = "-1 0. 0. -1";
                    ctm1 = GetPointString((SheetWidth + PageWidth) / 2);
                    ctm2 = GetPointString(Bite+PageHeight);
                    break;
                case Rotation.on270:
                    direction = "0. 1 -1 0.";
                    ctm1 = GetPointString((SheetWidth + PageHeight) / 2);
                    ctm2 = GetPointString(Bite);
                    break;
                case Rotation.on90:
                    direction = "0. -1 1 0.";
                    ctm1 = GetPointString((SheetWidth - PageHeight) / 2);
                    ctm2 = GetPointString(Bite + PageWidth);
                    break;
            case Rotation.None:
                default:
                    break;


            }


            JdfTemplate.Replace("*方向000*", direction)
                .Replace("*定位111*", ctm1)
                .Replace("*定位222*", ctm2);
                        
            File.WriteAllText(outPath.TrimEnd('\\') + "\\" + Path.GetFileNameWithoutExtension(pdfFullName) + ".jdf", JdfTemplate.ToString());
        }



        //public static void MakeJDF(
        //    TplFileInfo tplInfo, JobFile jobFile, string outPath)
        //{
        //    string JDFMarksFlatsPdf = @"\\128.1.30.144\Backup_ev08382-01\xiaoyongwei\out\JDFMarksFlats\JDFMarksFlats.pdf";
        //    double BleedMargin =0;
        //    //double BleedMargin = Math.Round(20 * 72 / 25.4, 5);
        //    StringBuilder JdfTemplate =
        //        new StringBuilder(Resources.JdfTemplate);
        //    //匹配所有GUID
        //    //  \*GUID_\d\d\d\*
        //    Regex regex = new Regex(@"\*GUID_\d\d\d\*");
        //    List<string> guidList = new List<string>();
        //    foreach (Match item in regex.Matches(JdfTemplate.ToString()))
        //    {
        //        if (!guidList.Contains(item.Value))
        //        {
        //            guidList.Add(item.Value);
        //        }
        //    }
        //    foreach (string guid in guidList)
        //    {
        //        JdfTemplate.Replace(guid, "A" + Guid.NewGuid().ToString());
        //    }
        //    //开始匹配各个单独数据
        //    //2018-07-30T02:24:12+08:00
        //    JdfTemplate.Replace("*文件名称*", Path.GetFileNameWithoutExtension(jobFile.PdfFullPath_0))//PDF绝对路径
        //    .Replace("*时间_000*", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        //    .Replace("*出血页边空白*", GetPointString(BleedMargin))
        //    .Replace("*印张宽度*", tplInfo.SheetWidth.ToString())
        //    .Replace("*印张高度*", tplInfo.SheetHeight.ToString())
        //        //.Replace("*左边空余*", tplInfo.LeftFree.ToString())
        //        //.Replace("*下面空余*", tplInfo.Bite.ToString())
        //    .Replace("*内容显示框_左*", (tplInfo.LeftFree - BleedMargin).ToString())
        //    .Replace("*内容显示框_下*", (tplInfo.Bite - BleedMargin).ToString())
        //    .Replace("*内容显示框_右*", (tplInfo.LeftFree + tplInfo.PageHorizontal + BleedMargin).ToString())
        //    .Replace("*内容显示框_上*", (tplInfo.Bite + tplInfo.PagePerpendicular + BleedMargin).ToString())
        //    .Replace("*成品左边界限*", tplInfo.LeftFree.ToString())
        //    .Replace("*成品下边界限*", tplInfo.Bite.ToString())
        //    .Replace("*成品右边界限*", (tplInfo.LeftFree + tplInfo.PageHorizontal).ToString())
        //    .Replace("*成品上边界限*", (tplInfo.Bite + tplInfo.PagePerpendicular).ToString())
        //    .Replace("*成品宽度*", tplInfo.PageWidth.ToString())
        //    .Replace("*成品高度*", tplInfo.PageHeight.ToString())
        //    .Replace("*出版PDF全路径*", Uri.EscapeDataString(jobFile.PdfFullPath.Replace('/', '\\')).Replace("%5C", "/"))
        //    .Replace("*标记PDF全路径*", Uri.EscapeDataString(JDFMarksFlatsPdf).Replace("%5C", "/"));
        //    //匹配方向和定位
        //    string direction = "1 0. 0. 1";
        //    string ctm1 = tplInfo.LeftFree.ToString();
        //    string ctm2 = tplInfo.Bite.ToString();
        //    switch (tplInfo.Direction)
        //    {
        //        case 4://左
        //            direction = "0. 1 -1 0.";
        //            ctm1 = (tplInfo.LeftFree + tplInfo.PageHorizontal).ToString();
        //            ctm2 = tplInfo.Bite.ToString();
        //            break;
        //        case 5://上
        //            direction = "-1 0. 0. -1";
        //            ctm1 = (tplInfo.LeftFree + tplInfo.PageHorizontal).ToString();
        //            ctm2 = (tplInfo.Bite + tplInfo.PagePerpendicular).ToString();
        //            break;
        //        case 6://右
        //            direction = "0. -1 1 0.";
        //            ctm1 = tplInfo.LeftFree.ToString();
        //            ctm2 = (tplInfo.Bite + tplInfo.PagePerpendicular).ToString();
        //            break;
        //        default:
        //            break;
        //    }
        //    JdfTemplate.Replace("*方向000*", direction)
        //        .Replace("*定位111*", ctm1)
        //        .Replace("*定位222*", ctm2);

        //    File.WriteAllText(outPath + Path.GetRandomFileName() + ".jdf", JdfTemplate.ToString());
        //}






    }

}
