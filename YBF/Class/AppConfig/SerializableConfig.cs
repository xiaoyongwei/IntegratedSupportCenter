//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;
//using YBF.Class.Comm;

//namespace FYBF.Class.Comm
//{
//    public class SerializableConfig
//    {

//        private static string binFile = "Data\\config.bin";
//        ///// <summary>
//        ///// 用户
//        ///// </summary>
//        //public static Config config;

//        /// <summary>
//        /// 保存(序列化)
//        /// </summary>
//        public static bool Save(AppConfig config)
//        {
//            FileStream fs = null;
//            try
//            {
//                fs = new FileStream(binFile, FileMode.Create);
//                BinaryFormatter bf = new BinaryFormatter();
//                bf.Serialize(fs, config);
//            }
//            catch
//            {
//                return false;
//            }
//            finally
//            {
//                if (fs != null)
//                {
//                    fs.Close();
//                }    
//            }
//            return true;
//        }

//        /// <summary>
//        /// 读取(反序列化)
//        /// </summary>
//        /// <returns></returns>
//        public static AppConfig Load()
//        {
//            FileStream fs = null;
//            AppConfig config = null;
//            try
//            {
//                if (!File.Exists(binFile))
//                {
//                    return null;
//                }
//                fs = new FileStream(binFile, FileMode.Open);
//                BinaryFormatter bf = new BinaryFormatter();
//                config = bf.Deserialize(fs) as AppConfig;
                
//            }
//            catch
//            {
//                config = null;
//            }
//            finally
//            {
//                if (fs!=null)
//                {
//                    fs.Close();
//                }                
//            }
//            return config;
//        }
//    }
//}
