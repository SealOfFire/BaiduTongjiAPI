using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Baidu.Tongji.API
{
    public class HttpManager
    {
        #region http

        /// <summary>
        /// 登录请求
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="accountType"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static string RequestLogin(string uri, string accountType, Baidu.Tongji.API.JSON.Login.Header jsonData)
        {
            jsonData.UUID = Guid.NewGuid().ToString("N");
            string json = JsonConvert.SerializeObject(jsonData);
            byte[] zipData = Compression(json);

            // encrypt加密
            byte[] postData = Encrypt(zipData);

            byte[] responseData = HttpManager.RequestLogin(uri, jsonData.UUID, accountType, postData);

            // 解压gzip 从第8个字节开始是正式数据
            string value = Decompress(responseData.Skip(8).Take(responseData.Length - 8).ToArray());
            return value;
        }

        /// <summary>
        /// 数据请求
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="accountType"></param>
        /// <param name="userId"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static string RequestReport(string uri, long userId, Baidu.Tongji.API.JSON.Report.ReportRequest jsonData)
        {
            string json = JsonConvert.SerializeObject(jsonData);
            byte[] bytes = Encoding.UTF8.GetBytes(json);

            byte[] responseData = HttpManager.RequestReport(uri, userId, bytes);

            string value = Encoding.UTF8.GetString(responseData);
            return value;
        }

        /// <summary>
        /// 登录请求
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="uuid"></param>
        /// <param name="accountType"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static byte[] RequestLogin(string uri, string uuid, string accountType, byte[] postData)
        {
            // Guid uuid = Guid.NewGuid();

            WebRequest request = HttpWebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "data/gzencode and rsa public encrypt;charset=UTF-8";
            request.Headers.Add("UUID", uuid);
            request.Headers.Add("ACCOUNT_TYPE", accountType);

            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(postData, 0, postData.Length);
            myRequestStream.Close();

            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            int count = (int)response.ContentLength;
            int offset = 0;
            byte[] buf = new byte[count];
            while (count > 0)
            {
                int n = responseStream.Read(buf, offset, count);
                if (n == 0) break;
                count -= n;
                offset += n;
            }
            response.Close();

            return buf;
        }

        /// <summary>
        /// 数据请求
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="uuid"></param>
        /// <param name="accountType"></param>
        /// <param name="userId"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static byte[] RequestReport(string uri, long userId, byte[] postData)
        {
            Guid uuid = Guid.NewGuid();
            WebRequest request = HttpWebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "data/json;charset=UTF-8";
            request.Headers.Add("UUID", uuid.ToString("N"));
            request.Headers.Add("USERID", userId.ToString());

            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(postData, 0, postData.Length);
            myRequestStream.Close();

            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            List<byte> bytes = new List<byte>();
            int temp = responseStream.ReadByte();
            while (temp != -1)
            {
                bytes.Add((byte)temp);
                temp = responseStream.ReadByte();
            }
            response.Close();
            return bytes.ToArray();

            //int count = 1024; // (int)response.ContentLength;
            //int offset = 0;
            //byte[] buf = new byte[count];
            //while (count > 0)
            //{
            //    int n = responseStream.Read(buf, offset, count);
            //    if (n == 0) break;
            //    count -= n;
            //    offset += n;
            //}

            //return buf;
        }

        #endregion

        #region 压缩

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

        #endregion

        #region ras

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static byte[] Encrypt(byte[] data)
        {
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
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            rsa.FromXmlString("<RSAKeyValue><Modulus>x5/4X70y0V1YgV05gYTWBCCXhhhg5Jq2AcQkXpa4ixGBHK8Fq86dGrvZxCEqYzJV3hFuPk/NmwjNtviVF2aSIGuanQaz5I1NPCrX+Z+zbHe5/WXiNGKACgrm97pVRMXMRnkt0VcRWovaMxEZWr6aEznVMxB+mFhz+K3hX6TKS88=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"); //rsa2 导入 rsa1 的公钥，用于加密信息
            // rsa2.FromXmlString("<RSAKeyValue><Modulus>3TY7mJK3DWt/kFo6i/vgqJQ13Kc8mb7wEB7FKad40DFqHtxlXRcZup/B5U3C5kUvLvD2/36vCIt8aH8GwslQFOsmflN42/mKv0LpdIltW0nDI60BuNSDpGmMZtRk4k+bJvN+9+056AZduu3BCRJxgk3qn8xsdeWbp+um42j4uLs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"); //rsa2 导入 rsa1 的公钥，用于加密信息

            //rsa2开始加密
            byte[] cipherbytes;
            cipherbytes = rsa.Encrypt(data, false);
            return cipherbytes;
        }

        #endregion
    }
}
