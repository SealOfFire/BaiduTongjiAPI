using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Baidu.Tongji.API;
using System.IO;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Class1.PreLogin("ctrchina", "e798f6e5f99259317259e77b7909e586", "a");
            // Class1.DoLogin("ctrchina", "82015388@ctrchina.cn", "e798f6e5f99259317259e77b7909e586", "a");
        }

        [TestMethod]
        public void TestMethod2()
        {

            byte[] cbytes = null;
            //压缩
            using (MemoryStream cms = new MemoryStream())
            {
                using (System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(cms, System.IO.Compression.CompressionMode.Compress))
                {
                    //将数据写入基础流，同时会被压缩
                    byte[] bytes = Encoding.UTF8.GetBytes("解压缩测试");
                    gzip.Write(bytes, 0, bytes.Length);
                }
                cbytes = cms.ToArray();
            }
            //解压
            using (MemoryStream dms = new MemoryStream())
            {
                using (MemoryStream cms = new MemoryStream(cbytes))
                {
                    using (System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(cms, System.IO.Compression.CompressionMode.Decompress))
                    {
                        byte[] bytes = new byte[1024];
                        int len = 0;
                        //读取压缩流，同时会被解压
                        while ((len = gzip.Read(bytes, 0, bytes.Length)) > 0)
                        {
                            dms.Write(bytes, 0, len);
                        }
                    }
                }
                Console.WriteLine(Encoding.UTF8.GetString(dms.ToArray()));
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Class1.aab();
        }
    }
}
