using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using HanDe_ClassLibrary.Common.SizeBox;
using HanDe_ClassLibrary.Common.Unit;
using System.Data;
using System.Text;
using HandeJobManager.DAL;

/// <summary>
///印能捷作业记录的实例
/// </summary>
public class EvoProcessInfo
{
    /// <summary>
    /// 唯一标识(GUID)
    /// </summary>
    public string Guid { get; set; }
    /// <summary>
    /// 稿袋号
    /// </summary>
    public string Gaodaihao { get; set; }
    /// <summary>
    /// 作业提交时间
    /// </summary>
    public DateTime SubmissionDate { get; set; }
    /// <summary>
    /// 作业完成时间
    /// </summary>
    public DateTime CompletionTime { get; set; }
    /// <summary>
    ///作业的文件列表
    /// </summary>
    public List<String> FileList { get; set; }
    //public string FileNameString { get; set; }
    /// <summary>
    ///板材
    /// </summary>
    public String Plant { get; set; }
    /// <summary>
    ///颜色列表
    /// </summary>
    public List<String> ColorList { get; set; }
    /// <summary>
    ///颜色数量
    /// </summary>
    public int ColorNumber { get; set; }
    /// <summary>
    ///垂直向下偏移晾
    ///<para>单位:毫米(mm)</para>
    /// </summary>
    public double OffsetY { get; set; }
    /// <summary>
    ///线数
    /// </summary>
    public double RulingOrFeatureSize { get; set; }
    /// <summary>
    ///校准曲线
    /// </summary>
    public String CalibrationTarget { get; set; }
    /// <summary>
    ///网点形状
    /// </summary>
    public String DotShape { get; set; }
    /// <summary>
    /// 板材长边
    /// </summary>
    public int Plant_L { get; set; }
    /// <summary>
    /// 板材短边
    /// </summary>
    public int Plant_S { get; set; }
    /// <summary>
    /// 成像位置
    /// </summary>
    public CREO_TrimBox_Point ImagingPosition { get; set; }
    /// <summary>
    /// 实例化 印能捷作业记录
    /// </summary>
    public EvoProcessInfo()
    {
        InitList();
    }

    /// <summary>
    /// 初始化所有列表集合
    /// </summary>
    private void InitList()
    {
        this.FileList = new List<String>();
        this.CompletionTime = new DateTime();
        this.SubmissionDate = new DateTime();
        this.ColorList = new List<String>();
    }

    /// <summary>
    /// 实例化 印能捷作业记录
    /// </summary>
    public EvoProcessInfo(string processId)
    {
        InitList();

        DataTable dt = SQLiteList.BackupProcess.ExecuteDataTable
                ("select * from filename where ProcessID='" + processId + "';");
            if (dt.Rows.Count != 0)
            {
                // 读取文本文件的所有行
                string[] AllLine = dt.Rows[0]["ProcessCreationInfo"].ToString()
                    .Replace("\r\n", "\n").Split('\n');
                int index = AllLine[3].IndexOf(':') + 1; ;
                //提取出时间                    
                string str = AllLine[3].Substring(index).Trim();
                char[] split = new char[] { '-', '.' };
                string[] dateStr = str.Split(split, 8);
                DateTime dateTime = new DateTime(Convert.ToInt32(dateStr[0])
                    , Convert.ToInt32(dateStr[1])
                    , Convert.ToInt32(dateStr[2])
                    , Convert.ToInt32(dateStr[3])
                    , Convert.ToInt32(dateStr[4])
                    , Convert.ToInt32(dateStr[5])
                    );
                //**提交时间
                this.SubmissionDate = dateTime;
                //**完成时间
                this.CompletionTime =
                    Convert.ToDateTime(dt.Rows[0]["CompleteTime"]);

                //***提取出GUID
                index = AllLine[2].IndexOf(":") + 1;
                str = AllLine[2].Substring(index).Trim();
                if (str.Equals(processId, StringComparison.OrdinalIgnoreCase))
                {
                    this.Guid = str;
                }

                // ***提取文件名
                for (int i = 12; i < AllLine.Length; i++)
                {
                    String processFilename = AllLine[i];
                    this.FileList.Add(processFilename);
                }
                //***文件名字符串
               // this.FileNameString = GetFileNameString();

                // ****提取板材和提取颜色*******
                string allText = dt.Rows[0]["PrintingToDevice"].ToString();
                int lastIndex;
                // ***提取板材
                index = allText.IndexOf("/Ct (");
                lastIndex = allText.IndexOf("\n", index);
                str = allText.Substring(index, lastIndex - index);
                // 定位下划线
                index = str.LastIndexOf('_');
                // 定位符合')'
                lastIndex = str.LastIndexOf(')');
                str = str.Substring(index + 1, lastIndex - index);
                Regex regex = new Regex("\\d+");
                MatchCollection matchs = regex.Matches(str);
                this.Plant = matchs[0].Value + "*" + matchs[1].Value;

                // ***提取颜色数量和颜色列表
                index = allText.LastIndexOf("\n/CO [\n");
                lastIndex = allText.IndexOf(" ]/CP [\n", index);
                str = allText.Substring(index + 7, lastIndex - index);
                // 去除str最后的字符
                str = str.Replace("]/CP [", "");
                // 取出str最前面的符号'/'
                str = str.TrimStart('/').Trim();
                // 对颜色进行拆分
                String[] colors = str.Split('/');
                this.ColorNumber = colors.Length * this.FileList.Count;

                foreach (String color in colors)
                {
                    this.ColorList.Add(color.Replace("#3d", "=").Replace("#20", " ").Replace("\n", "").Trim());
                }

                // ***垂直偏移
                index = allText.IndexOf("/CPC_MediaOffset ");
                lastIndex = allText.IndexOf("\n", index);
                str = allText.Substring(index, lastIndex - index);
                str = str.Replace("/CPC_MediaOffset ", "");
                str = str.Trim();
                // 定位要相应数据的位置
                str = "\n" + str.Replace("R", "obj\n");
                index = allText.IndexOf(str);
                index = allText.IndexOf("[", index);
                lastIndex = allText.IndexOf("]", index);
                str = allText.Substring(index, lastIndex - index);
                //识别数字
                matchs = new Regex("\\d+\\.\\d+").Matches(str);
                this.OffsetY = Math.Round(Double.Parse(matchs[1].Value) * ConversionConstant.MM_PER_PT);
                // ***线数
                index = allText.IndexOf("/CPC_RulingOrFeatureSize");
                lastIndex = allText.IndexOf("\n", index);
                str = allText.Substring(index, lastIndex - index);
                str = str.Replace("/CPC_RulingOrFeatureSize", "");
                str = str.Trim();
                this.RulingOrFeatureSize = Double.Parse(str);

                // ***校准曲线
                index = allText.IndexOf("/CPC_CalibrationTarget");
                lastIndex = allText.IndexOf("\n", index);
                str = allText.Substring(index, lastIndex - index);
                // 定位左右圆括号
                index = str.IndexOf("(");
                lastIndex = str.LastIndexOf(")");
                str = str.Substring(index + 1, lastIndex - index - 1);
                this.CalibrationTarget = str;

                // ***网点形状
                index = allText.IndexOf("/CPC_DotShape");
                lastIndex = allText.IndexOf("\n", index);
                str = allText.Substring(index, lastIndex - index);
                // 定位左右圆括号
                index = str.IndexOf("(");
                lastIndex = str.LastIndexOf(")");
                str = str.Substring(index + 1, lastIndex - index - 1);
                this.DotShape = str;

                //***板材长边和短边
                string[] plantArray = this.Plant.Split('*');
                if (plantArray.Length == 2)
                {
                    int side_L = Convert.ToInt32(plantArray[1]);
                    int side_S = Convert.ToInt32(plantArray[0]);
                    if (side_L < side_S)
                    {
                        side_L = side_L + side_S;
                        side_S = side_L - side_S;
                        side_L = side_L - side_S;
                    }
                    this.Plant_L = side_L;
                    this.Plant_S = side_S;
                }
                //****成像位置
                string txt = allText.Replace('\n', '\0');
                regex = new Regex(@"\]/Cl \[.*\]/D");
                if (regex.IsMatch(txt))
                {
                    MatchCollection mc = new Regex(@"-?\d+(\.\d+)?")
                        .Matches(regex.Match(txt).Value);
                    if (mc != null && mc.Count == 4)
                    {
                        double left = Convert.ToDouble(mc[0].Value);
                        double down = Convert.ToDouble(mc[1].Value);
                        double right = Convert.ToDouble(mc[2].Value);
                        double top = Convert.ToDouble(mc[3].Value);
                        ImagingPosition = new CREO_TrimBox_Point(
                            new Point_Unit(top), new Point_Unit(down), new Point_Unit(left), new Point_Unit(right));
                    }
                }
                //***稿袋号
            }
        //}
        //catch (Exception ex)
        //{
        //    ErrorMessageShow.Show(ex.Message);
        //}
    }
    /// <summary>
    /// 获取出版文件列表的字符串形式
    /// </summary>
    /// <returns></returns>
    public string GetFileNameString()
    {
        StringBuilder FileNameString = new StringBuilder();
        foreach (string fileName in this.FileList)
        {
            FileNameString.AppendLine(
                Path.GetFileNameWithoutExtension(fileName));
        }
        return FileNameString.ToString().Trim();
    }
    /// <summary>
    /// 获取出版文件列表(完整路径)的字符串形式
    /// </summary>
    /// <returns></returns>
    public string GetFileDirectoryNameString()
    {
        StringBuilder FileNameString = new StringBuilder();
        foreach (string fileName in this.FileList)
        {
            FileNameString.AppendLine(Path.GetDirectoryName(fileName));
            break;
        }
        return FileNameString.ToString().Trim();
    }

    
    public string GetColorString()
    {
        StringBuilder ColorString = new StringBuilder();
        foreach (string color in this.ColorList)
        {
            ColorString.AppendLine(color);
        }
        return ColorString.ToString().Trim();
    }

    public bool Equals(EvoProcessInfo evo)
    {
        if (this == evo)
        {
            return true;
        }
        foreach (string file in evo.FileList)
        {
            if (this.FileList.Contains(file))
            {
                if (this.Plant_L != evo.Plant_L || this.Plant_S != evo.Plant_S || this.OffsetY != evo.OffsetY
                    || this.RulingOrFeatureSize != evo.RulingOrFeatureSize
                    || this.DotShape != evo.DotShape || this.CalibrationTarget != evo.CalibrationTarget)
                {
                    return false;
                }
                foreach (string color in evo.ColorList)
                {
                    if (!this.ColorList.Contains(color))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

}