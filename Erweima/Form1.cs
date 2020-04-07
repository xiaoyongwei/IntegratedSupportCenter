using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;


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
            string nrText = DateTime.Now.Millisecond + "_成品_彩盒_C200401018_2h-2_998";
            HebingPicture(CreateCode_Simple(nrText,nrText),
                "background1.jpg",nrText);
        }
        //生成二维码方法一
        private static string CreateCode_Simple(string nr,string filename)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 8;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.Drawing.Image image = qrCodeEncoder.Encode(nr);
            string FileFullFileName = "picture\\" + filename+".jpg";
            System.IO.FileStream fs = new System.IO.FileStream(FileFullFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

            fs.Close();
            image.Dispose();
            return FileFullFileName;
        }

        /// <summary>
        /// 合并图片
        /// </summary>
        private void HebingPicture(string erweimaFile,string backgroundFile,string text)
        {
            pictureBox1.Image = Image.FromFile(erweimaFile); //设置背景图片
            string imgPath = backgroundFile;  //要插入的二维码图片路径
            Image QRcodePic; //用来存储读取的二维码图片
            //读取二维码图片文件流
            FileStream fileStream = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
            int byteLength = (int)fileStream.Length;    //二维码图片字节数
            byte[] fileBytes = new byte[byteLength];    //根据图片字节数创建一个存储该图片的字节数组
            fileStream.Read(fileBytes, 0, byteLength);  //读取二维码图片到数组
            fileStream.Close();                 //关闭文件流，解除对外部文件的锁定
            //取得二维码图片image对象
            QRcodePic = Image.FromStream(new MemoryStream(fileBytes));
            Graphics g = Graphics.FromImage(pictureBox1.Image);  //创建背景图片的Graphics对象（调用该对象在背景图片上绘图）
            //在背景图片上插入二维码图片
            g.DrawImage(QRcodePic, 500, 120, QRcodePic.Width, QRcodePic.Height);
            //在背景照片上添加文字 
            PointF drawPoint = new PointF(55.0F, 160.0F);//
            AddFont(g, drawPoint, text);
            //drawPoint = new PointF(55.0F, 220.0F);//
            //AddFont(g, drawPoint, "MoviePark:IT爱好者");
            //drawPoint = new PointF(55.0F, 280.0F);//
            //AddFont(g, drawPoint, "Blog:blog.csdn.net/u012577474");
            //刷新pictureBox1
            pictureBox1.Refresh();
        }


        /*在图片上添加文字
         * Graphics g  ，目标Graphics对象     
         * string data  ，准备添加的字符串
         */
        private void AddFont(Graphics g, PointF drawPoint, string data)
        {
            //   Graphics g = Graphics.FromImage(pictureBox1.Image);
            SolidBrush mybrush;
            mybrush = new SolidBrush(Color.Red);  //设置默认画刷颜色
            Font myfont;
            myfont = new Font("黑体", 10, FontStyle.Bold);         //设置默认字体格式   
            g.DrawString(data, myfont, mybrush, drawPoint); //图片上添加文字
            pictureBox1.Refresh();

        }

    }
}
