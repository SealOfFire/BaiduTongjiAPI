using Baidu.Tongji.API.JSON;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Baidu.Tongji.API
{
    public class Class1
    {
        public static void PreLogin(string userName, string token, string uuid)
        {
            Header header = new Header();
            header.UserName = userName;
            header.Token = token;
            header.FunctionName = "preLogin";
            header.UUID = uuid;

            PreLoginRequest request = new PreLoginRequest();
            header.Request = request;

            // 压缩数据
            string json = JsonConvert.SerializeObject(header);

            // GZIP压缩
            // string value = Compression(json);
        }

        public static void DoLogin(string userName, string password, string token, string uuid)
        {
            Header header = new Header();
            header.UserName = userName;
            header.Token = token;
            header.FunctionName = "doLogin";
            header.UUID = uuid;

            DoLoginRequest request = new DoLoginRequest();
            request.Password = password;
            header.Request = request;

            string json = JsonConvert.SerializeObject(header);

            // GZIP压缩
            string json2 = "{\"username\": \"ctrchina\", \"token\": \"e798f6e5f99259317259e77b7909e586\", \"request\": {\"password\": \"82015388@ctrchina.cn\"}, \"functionName\": \"doLogin\", \"uuid\": \"a\"}";
            byte[] value = Compression(json);
            // string value2 = Decompress(value);
            // GzipBundle.GzipBundle g = new GzipBundle.GzipBundle();
            // Stream s = new GZipOutputStream();
            //value[4] = 0xa9;
            //value[5] = 0x70;
            //value[6] = 0x70;
            //value[7] = 0x59;
            //value[8] = 0x02;
            //value[9] = 0xff;
            // encrypt加密
            byte[] data = Encrypt(value);

            // 发送http请求
            Request(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static byte[] Encrypt(byte[] data)
        {
            // List<byte[]> ret = new List<byte[]>();
            int n = (int)Math.Ceiling(data.Length * 1.0 / 117);
            byte[] ret = new byte[n * 128];
            for (int i = 0; i < n; i++)
            {
                int length = 117;
                if (i == n - 1)
                {
                    // 计算最后剩余的数量
                    length = data.Length - i * 117;
                }
                byte[] gzdata = new byte[length];
                Array.Copy(data, i * 117, gzdata, 0, length);
                // ret.Add(aaa(gzdata));
                Array.Copy(RSAEncrypt(gzdata), 0, ret, i * 128, 128);
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(byte[] data)
        {
            RSACryptoServiceProvider rsa2 = new RSACryptoServiceProvider();

            rsa2.FromXmlString("<RSAKeyValue><Modulus>x5/4X70y0V1YgV05gYTWBCCXhhhg5Jq2AcQkXpa4ixGBHK8Fq86dGrvZxCEqYzJV3hFuPk/NmwjNtviVF2aSIGuanQaz5I1NPCrX+Z+zbHe5/WXiNGKACgrm97pVRMXMRnkt0VcRWovaMxEZWr6aEznVMxB+mFhz+K3hX6TKS88=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"); //rsa2 导入 rsa1 的公钥，用于加密信息
            // rsa2.FromXmlString("<RSAKeyValue><Modulus>3TY7mJK3DWt/kFo6i/vgqJQ13Kc8mb7wEB7FKad40DFqHtxlXRcZup/B5U3C5kUvLvD2/36vCIt8aH8GwslQFOsmflN42/mKv0LpdIltW0nDI60BuNSDpGmMZtRk4k+bJvN+9+056AZduu3BCRJxgk3qn8xsdeWbp+um42j4uLs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"); //rsa2 导入 rsa1 的公钥，用于加密信息

            //rsa2开始加密
            byte[] cipherbytes;
            cipherbytes = rsa2.Encrypt(data, false);
            // cipherbytes = rsa2.Encrypt(new byte[] { 0x61, 0x62, 0x63 }, false);
            return cipherbytes;
            // return (string)(Convert.ToBase64String(cipherbytes));
        }

        /// <summary>
        /// GZIP压缩
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] Compression(string text)
        {
            string value;
            byte[] cbytes;
            using (MemoryStream cms = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(cms, CompressionLevel.Optimal, false))
                {
                    //将数据写入基础流，同时会被压缩
                    byte[] bytes = UTF8Encoding.UTF8.GetBytes(text);
                    gzip.Write(bytes, 0, bytes.Length);
                }
                cbytes = cms.ToArray();
                value = UTF8Encoding.UTF8.GetString(cbytes);
                byte[] buffer = UTF8Encoding.UTF8.GetBytes(value);
                // UTF8Encoding utf8 = new UTF8Encoding();
                // value = Encoding.UTF8.GetString(cbytes);
                // byte[] buffer = Encoding.UTF8.GetBytes(value);
                // string buffer2 = Encoding.UTF8.GetString(buffer);
            }
            return cbytes;
        }

        /// <summary>
        /// GZIP解压
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decompress(byte[] buffer)
        {
            // byte[] buffer = UTF8Encoding.UTF8.GetBytes(text);
            using (MemoryStream dms = new MemoryStream())
            {
                using (MemoryStream cms = new MemoryStream(buffer))
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
                return Encoding.UTF8.GetString(dms.ToArray());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Zip(string text)
        {
            byte[] buffer = System.Text.Encoding.Unicode.GetBytes(text);
            MemoryStream ms = new MemoryStream();
            using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }

            //ms.Position = 0;
            //MemoryStream outStream = new MemoryStream();

            //byte[] compressed = new byte[ms.Length];
            //ms.Read(compressed, 0, compressed.Length);

            //byte[] gzBuffer = new byte[compressed.Length + 4];
            //System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            //System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            //return Convert.ToBase64String(gzBuffer);

            StreamReader sr = new StreamReader(new MemoryStream(ms.ToArray()));
            string value = sr.ReadToEnd();
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compressedText"></param>
        /// <returns></returns>
        public static string UnZip(string compressedText)
        {
            // byte[] gzBuffer = Convert.FromBase64String(compressedText);
            byte[] gzBuffer = Encoding.UTF8.GetBytes(compressedText);
            using (MemoryStream ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;
                using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }

                return System.Text.Encoding.Unicode.GetString(buffer, 0, buffer.Length);
            }
        }

        public static void Request(byte[] postData)
        {
            WebRequest request = HttpWebRequest.Create("https://api.baidu.com/sem/common/HolmesLoginService");
            request.Method = "POST";
            request.ContentType = "data/gzencode and rsa public encrypt;charset=UTF-8";
            request.Headers.Add("UUID", "a");
            request.Headers.Add("ACCOUNT_TYPE", "1");

            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(postData, 0, postData.Length);
            myRequestStream.Close();
            //StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8"));
            //myStreamWriter.Write(postData);
            //myStreamWriter.Close();

            // post到服务器
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            //byte[] buffer = new byte[ responseStream.Length];
            //responseStream.Read(buffer,0,buffer.Length);
            //responseStream.Close();

            //string content;
            //using (StreamReader sr = new StreamReader(responseStream))
            //{
            //    content = sr.ReadToEnd();
            //}

            int count = (int)response.ContentLength;
            int offset = 0;
            byte[] buf = new byte[count];
            while (count > 0)
            {
                int n = responseStream.Read(buf, offset, count);
                if (n == 0) break;
                count -= n;
                offset += n;
                // Console.WriteLine("in loop " + getString(buf)); //测试循环次数
            }
            // string content = Encoding.Default.GetString(buf, 0, buf.Length);
            response.Close();

            // 前8字节是消息头


            // 解压gzip
            string value = Decompress(buf.Skip(8).Take(buf.Length - 8).ToArray());


        }
    }
}
