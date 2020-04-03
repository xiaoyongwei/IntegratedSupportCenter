using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Erweima
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();   //创建一个对话框对象
            ofd.Title = "请选择上传的图片";  //为对话框设置标题
            ofd.Filter = "图片格式|*.bmp";  //设置筛选的图片格式
            ofd.Multiselect = false;        //设置是否允许多选

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = ofd.FileName;//获得文件的完整路径（包括名字后后缀）
                Text = filePath;//将文件路径显示在文本框中
                int position = filePath.LastIndexOf("\\");
                string fileName = filePath.Substring(position + 1);
                using (Stream stream = ofd.OpenFile())
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Create))
                    {
                        stream.CopyTo(fs);
                        fs.Flush();
                    }
                    this.pictureBox1.ImageLocation = fileName;
                }
            }
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg">二维码信息</param>
        /// <returns>图片</returns>
        private Bitmap GenByZXingNet(string msg)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");//编码问题
            writer.Options.Hints.Add(
                EncodeHintType.ERROR_CORRECTION,
                ZXing.QrCode.Internal.ErrorCorrectionLevel.H

            );
            const int codeSizeInPixels = 250;   //设置图片长宽
            writer.Options.Height = writer.Options.Width = codeSizeInPixels;
            writer.Options.Margin = 0;//设置边框
            ZXing.Common.BitMatrix bm = writer.Encode(msg);
            Bitmap img = writer.Write(bm);
            return img;
        }
    }
}
