using Baidu.Tongji.API;
using Baidu.Tongji.API.JSON.Login;
using Baidu.Tongji.API.JSON.Report;
using Baidu.Tongji.API.JSON.Report.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Login login = new Login("****", "****", "****");
            PreLoginResponse response1 = login.PreLgoin();
            DoLoginResponse response2 = login.DoLogin();
            DoLogoutResponse response3 = login.DoLogout(response2.UCID, response2.ST);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Login login = new Login("****", "****", "****");
            Report report = new Report(login);
            // Baidu.Tongji.API.JSON.Report.SiteList.ReportResponse response1 = report.GetSiteList();
            // 10960085
            Baidu.Tongji.API.JSON.Report.GetData.ReportResponse response2 = report.GetData(10960085, "trend/time/a");
        }

        [TestMethod]
        public void TestMethod3()
        {
            BodyRequest request = new BodyRequest();
            request.EndDate = DateTime.Now;
            request.EndDate2 = DateTime.Now;
            request.StartDate = DateTime.Now;
            request.StartDate2 = DateTime.Now;
            request.Metrics.Add(Metrics.PageViewCount);
            request.Metrics.Add(Metrics.VisitorCount);
            request.Metrics.Add(Metrics.IPCount);

            string json = JsonConvert.SerializeObject(request);
        }

        [TestMethod]
        public void TestMethod4()
        {
            StreamReader sr = new StreamReader(@"D:\03_MyProgram\tongji.baidu.com\BaiduTongjiAPI\UnitTestProject\json1.json");
            string json = sr.ReadToEnd();
            Baidu.Tongji.API.JSON.Report.GetData.ReportResponse response = JsonConvert.DeserializeObject<Baidu.Tongji.API.JSON.Report.GetData.ReportResponse>(json);

            int debug = 0;
            debug++;
        }

        [TestMethod]
        public void TestMethod5()
        {
            Login login = new Login("****", "****", "****");
            Report report = new Report(login);
            BodyRequest body = new BodyRequest();
            body.Method = "trend/time/a";
            body.SiteId = 10960085;
            // 时间
            body.StartDate = DateTime.Now.AddDays(-2);
            body.EndDate = DateTime.Now;
            // 指标
            body.Metrics.Add(Metrics.PageViewCount);
            body.Metrics.Add(Metrics.VisitorCount);
            body.Metrics.Add(Metrics.IPCount);
            body.Metrics.Add(Metrics.BounceRatio);
            body.Metrics.Add(Metrics.AVGVisitTime);
            // 时间粒度
            body.Gran = Gran.Hour;
            // 查询
            Baidu.Tongji.API.JSON.Report.GetData.ReportResponse response2 = report.GetData(body);

            int debug = 0;
            debug++;
        }
    }
}
