using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using YBF.Properties;
using System.Text.RegularExpressions;
using HandeJobManager.DAL;
using HanDe_ClassLibrary.LogCommon;
using YBF.Class.Comm;
using HandeJobManager.Common;

namespace YBF.WinForm.Jdf
{
    public partial class FormSelectIllustrator : Form
    {
        private string ScriptingSupportAip = "";
        private string guid = "";
        private string dllFullPath = "";
        private string loaclMacAddress = ComputerComm.GetMacAddress();

        public FormSelectIllustrator()
        {
            InitializeComponent();
        }

        private void FormSelectIllustrator_Load(object sender, EventArgs e)
        {
            Dictionary<RegistryKey, string> dic = GetIllustratorTypeLib();
            int mmmm = 0;
            foreach (RegistryKey key in dic.Keys)
            {
                RadioButton rb = new RadioButton();
                rb.Location = new Point(10, 50 + mmmm * 25);
                rb.Text = dic[key];
                rb.Size = new System.Drawing.Size(rb.Text.Length * 10, rb.Height);
                rb.Tag = key;
                this.Controls.Add(rb);
                mmmm++;
            }

            //判断哪个是已经被选中的
            string guid = AppConfig_Local.IllustratorAppGuid;
            if (!string.IsNullOrWhiteSpace(guid))
            {
                foreach (Control item in this.Controls)
                {
                    if (item is RadioButton)
                    {
                        RegistryKey regKey = item.Tag as RegistryKey;
                        if (regKey.Name.Contains(guid))
                        {
                            (item as RadioButton).Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        private static Dictionary<RegistryKey, string> GetIllustratorTypeLib()
        {
            Dictionary<RegistryKey, string> dic = new Dictionary<RegistryKey, string>();
            //List<RegistryKey> regKeyList = new List<RegistryKey>();
            //获取系统使用的typelib
            RegistryKey RegKeyCR = Registry.ClassesRoot.OpenSubKey("TypeLib");
            string[] subKeys = RegKeyCR.GetSubKeyNames();
            foreach (string subKey in subKeys)//guid
            {
                Match match = Regex.Match(subKey, @"^\{[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}\}$", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string guid = subKey;
                    RegistryKey RegKey = RegKeyCR.OpenSubKey(subKey);

                    //判断guid下的子项是否存在
                    if (RegKey.SubKeyCount > 0)
                    {
                        subKeys = RegKey.GetSubKeyNames();//读取guid下面的子项
                        //打开第一项子项
                        RegKey = RegKey.OpenSubKey(subKeys[0]);
                        // 遍历所有的键名
                        //判断是否存在建
                        if (RegKey.ValueCount > 0)
                        {
                            String[] keyNameArray = RegKey.GetValueNames();
                            foreach (string keyName in keyNameArray)
                            {
                                string value = (string)RegKey.GetValue(keyName);
                                if (value.IndexOf("Illustrator", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    dic.Add(RegKey, value.Replace("Type Library", ""));
                                    //Console.WriteLine(value.Replace("Type Library", ""));
                                }
                            }
                        }
                    }
                }
            }
            return dic;
        }

        /// <summary>
        /// 2.遍历指定项下的所有键值对
        /// </summary>
        /// <param name="regKey"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetKeyValue(RegistryKey regKey)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (regKey.ValueCount > 0)
            {
                foreach (string valueName in regKey.GetValueNames())
                {
                    dic.Add(valueName, regKey.GetValue(valueName));
                }
            }

            return dic;
        }



        /// <summary>
        /// 1.遍历指定项下的项(是否包含子项)
        /// </summary>
        public static List<RegistryKey> enumerateKeys(RegistryKey HKLM, string keyPath, string findTxt, bool isAll)
        {
            List<RegistryKey> regKeyList = new List<RegistryKey>();
            try
            {
                RegistryKey RegKeyPatent = HKLM.OpenSubKey(keyPath);
                string[] subKeys = RegKeyPatent.GetSubKeyNames();

                foreach (string subKey in subKeys)
                {
                    string fullPath = (keyPath + "\\").TrimStart('\\') + subKey;
                    RegistryKey RegKey = RegKeyPatent.OpenSubKey(subKey);
                    if (fullPath.Contains(findTxt))
                    {
                        regKeyList.Add(RegKey);
                        if (!isAll)
                        {
                            continue;
                        }
                    }

                    regKeyList.AddRange(enumerateKeys(HKLM, fullPath, findTxt, isAll));


                }
            }
            catch
            {
            }
            return regKeyList;
        }


        private void SetRowBackColor(DataGridViewRow row, Color color)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = color;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                RadioButton rb = control as RadioButton;
                if (rb == null || !rb.Checked)
                {
                    continue;
                }

                RegistryKey regKey = control.Tag as RegistryKey;
                //遍历注册表项下面的所有子项,并读取每个子项的键值对,
                //目的是找到ScriptingSupport.aip
                bool isOk = false;
                foreach (RegistryKey key in enumerateKeys(regKey, "", "", true))
                {
                    //找到ScriptingSupport.aip
                    foreach (object item in GetKeyValue(key).Values)
                    {
                        if (item.ToString().IndexOf
                            ("ScriptingSupport.aip", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            Regex regex = new Regex(@"\{[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}\}", RegexOptions.IgnoreCase);
                            guid = regex.Match(key.Name).Value;
                            ScriptingSupportAip = item.ToString();
                            isOk = true;
                            break;
                        }
                    }
                    if (isOk)
                    {
                        break;
                    }
                }
                if (isOk)
                {
                    //如果Aip文件存在
                    if (File.Exists(ScriptingSupportAip))
                    {
                        //进行dll的转换
                        string TlbImpPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Bin\\TlbImp.exe";
                        dllFullPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Dll\\" + Environment.MachineName + "_Illustrator.dll";
                        string cmdRerutnStr = BaseHandle.ExecuteCom(string.Format("\"{0}\" \"{1}\" /out:\"{2}\"", TlbImpPath, ScriptingSupportAip, dllFullPath), true);
                        //如果转换成功则写入到数据库
                        //Type library imported to D:\GZ-20160416DNOK_Illustrator.dll
                        bool bl1 = cmdRerutnStr.IndexOf("Type library imported to " + dllFullPath, StringComparison.OrdinalIgnoreCase) > 0;
                        bool bl2 = File.Exists(dllFullPath);
                        bool bl3 = File.GetLastWriteTime(dllFullPath).AddMinutes(1) >= DateTime.Now;
                        if (bl1 && bl2 && bl3)
                        {
                            AppConfig_Local.IllustratorDllName = dllFullPath;
                            AppConfig_Local.IllustratorAppGuid = guid;
                            AppConfig_Local.Save();
                        }
                        else
                        {
                            Log.WriteLog("生成ai的Dll文件失败:____");
                           Comm_Method.ShowErrorMessage("生成失败");
                        }
                    }
                }
                break;
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("测试前请确定是否已经打开所选择的Illustrator的软件", "确定?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //空间名+类名
                string spaceName = Path.GetFileNameWithoutExtension(AppConfig_Local.IllustratorDllName) + ".ApplicationClass";

                //加载程序集(dll文件地址)，使用Assembly类   
                Assembly assembly = Assembly.LoadFile(AppConfig_Local.IllustratorDllName);

                //获取类型，参数（名称空间+类）   
                Type type = assembly.GetType(spaceName);

                //创建该对象的实例，object类型，参数（名称空间+类）   
                object instance = assembly.CreateInstance(spaceName);


                ////设置Show_Str方法中的参数类型，Type[]类型；如有多个参数可以追加多个   
                //Type[] params_type = new Type[1];
                //params_type[0] = Type.GetType("System.String");
                ////设置Show_Str方法中的参数值；如有多个参数可以追加多个   
                //Object[] params_obj = new Object[1];
                //params_obj[0] = "alert('测试');";

                ////执行Show_Str方法   
                // type.GetMethod("DoJavaScript", params_type).Invoke(instance, params_obj);


                //方法名称
                string strMethod = "DoJavaScript";
                // 获取方法信息
                // 注意获取重载方法，需要指定参数类型
                MethodInfo method = type.GetMethod(strMethod);
                object[] parameters = new object[] 
                { Resources.IllustratorTest.Replace("*当前时间*",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    , null, null };
                // 调用方法，有参数
                Console.WriteLine(method.Invoke(instance, parameters));
            }
        }
    }
}
