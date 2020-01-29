using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Security.Cryptography;
using System.IO;
using System.Text;

/// <summary>
///My 的摘要说明
/// </summary>
public class My
{
	public My()
	{
	
	}
    /// <summary>
    /// 原纸库存查询
    /// </summary>
    public enum EnumYuanzhiKucunChaxun
    {
        原纸库存明细_详情=0,
        原纸库存明细_分类=1,
        原纸库存明细_按品牌分类=2,
        原纸库存明细_按UV分类=3
    }

    public  void DataTable(string sqlString)
    {

    }

    // 在此处添加更多操作并使用 [OperationContract] 标记它们
        #region MD5加密
        /// <summary>  
        /// MD5加密  
        /// </summary>  
        /// <param name="strSource">需要加密的字符串</param>  
        /// <returns>MD5加密后的字符串</returns>  
        [OperationContract]
        public string Md5Encrypt(string strSource)
        {
            //把字符串放到byte数组中  
            byte[] bytIn = System.Text.Encoding.Default.GetBytes(strSource);
            //建立加密对象的密钥和偏移量          
            byte[] iv = { 102, 16, 93, 156, 78, 4, 218, 32 };//定义偏移量  
            byte[] key = { 55, 103, 246, 79, 36, 99, 167, 3 };//定义密钥  
            //实例DES加密类  
            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.Key = iv;
            mobjCryptoService.IV = key;
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            //实例MemoryStream流加密密文件  
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
 
            string strOut = System.Convert.ToBase64String(ms.ToArray());
            return strOut;
        }
        #endregion
 
        #region MD5解密
        /// <summary>  
        /// MD5解密  
        /// </summary>  
        /// <param name="Source">需要解密的字符串</param>  
        /// <returns>MD5解密后的字符串</returns>  
        [OperationContract]
        public string Md5Decrypt(string Source)
        {
            //将解密字符串转换成字节数组  
            byte[] bytIn = System.Convert.FromBase64String(Source);
            //给出解密的密钥和偏移量，密钥和偏移量必须与加密时的密钥和偏移量相同  
            byte[] iv = { 102, 16, 93, 156, 78, 4, 218, 32 };//定义偏移量  
            byte[] key = { 55, 103, 246, 79, 36, 99, 167, 3 };//定义密钥  
            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.Key = iv;
            mobjCryptoService.IV = key;
            //实例流进行解密  
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader strd = new StreamReader(cs, Encoding.Default);
            return strd.ReadToEnd();
        }
        #endregion 
    
}