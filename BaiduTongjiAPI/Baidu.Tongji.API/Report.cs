using Baidu.Tongji.API.JSON.Login;
using Baidu.Tongji.API.JSON.Report;
using Baidu.Tongji.API.JSON.Report.DataStructure;
using Newtonsoft.Json;
using System;

namespace Baidu.Tongji.API
{
    public class Report
    {
        public const string URL = "https://api.baidu.com/json/tongji/v1/ReportService";

        private Login login;
        private DoLoginResponse loginResponse;

        public Report(Login login)
        {
            this.login = login;
        }

        /// <summary>
        /// 
        /// </summary>
        public JSON.Report.SiteList.ReportResponse GetSiteList()
        {
            try
            {
                if (this.loginResponse == null || loginResponse.ReturnCode != 0)
                    // 重新登录
                    this.loginResponse = this.login.DoLogin();

                ReportRequest data = new ReportRequest();
                data.Header.AccountType = "1";
                data.Header.Password = this.loginResponse.ST;
                data.Header.Token = this.login.Token;
                data.Header.UserName = this.login.UserName;

                string value = HttpManager.RequestReport(Report.URL + "/getSiteList", this.loginResponse.UCID, data);
                JSON.Report.SiteList.ReportResponse response = JsonConvert.DeserializeObject<JSON.Report.SiteList.ReportResponse>(value);
                return response;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.loginResponse != null || loginResponse.ReturnCode == 0)
                    // 登出
                    this.login.DoLogout(this.loginResponse.UCID, this.loginResponse.ST);
            }
        }

        /// <summary>
        /// 获取数据
        /// 默认显示前一天和今天，时间粒度为天
        /// 访问量，访问人数，ip数，跳出率，平均访问时常
        /// </summary>
        public JSON.Report.GetData.ReportResponse GetData(uint siteId, string method)
        {
            try
            {
                if (this.loginResponse == null || loginResponse.ReturnCode != 0)
                    // 重新登录
                    this.loginResponse = this.login.DoLogin();

                ReportRequest data = new ReportRequest();
                data.Header.AccountType = "1";
                data.Header.Password = this.loginResponse.ST;
                data.Header.Token = this.login.Token;
                data.Header.UserName = this.login.UserName;

                data.Body = new BodyRequest();
                data.Body.Method = method;
                data.Body.SiteId = siteId;
                data.Body.StartDate = DateTime.Now.AddDays(-2);
                data.Body.EndDate = DateTime.Now;
                data.Body.Metrics.Add(Metrics.PageViewCount);
                data.Body.Metrics.Add(Metrics.VisitorCount);
                data.Body.Metrics.Add(Metrics.IPCount);
                data.Body.Metrics.Add(Metrics.BounceRatio);
                data.Body.Metrics.Add(Metrics.AVGVisitTime);
                data.Body.Gran = Gran.Hour;

                string value = HttpManager.RequestReport(Report.URL + "/getData", this.loginResponse.UCID, data);
                JSON.Report.GetData.ReportResponse response = JsonConvert.DeserializeObject<JSON.Report.GetData.ReportResponse>(value);
                return response;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.loginResponse != null || loginResponse.ReturnCode == 0)
                    // 登出
                    this.login.DoLogout(this.loginResponse.UCID, this.loginResponse.ST);
            }
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        public JSON.Report.GetData.ReportResponse GetData(BodyRequest bodyData)
        {
            try
            {
                if (this.loginResponse == null || loginResponse.ReturnCode != 0)
                    // 重新登录
                    this.loginResponse = this.login.DoLogin();

                ReportRequest data = new ReportRequest();
                data.Header.AccountType = "1";
                data.Header.Password = this.loginResponse.ST;
                data.Header.Token = this.login.Token;
                data.Header.UserName = this.login.UserName;

                data.Body = bodyData;

                string value = HttpManager.RequestReport(Report.URL + "/getData", this.loginResponse.UCID, data);
                JSON.Report.GetData.ReportResponse response = JsonConvert.DeserializeObject<JSON.Report.GetData.ReportResponse>(value);
                return response;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.loginResponse != null || loginResponse.ReturnCode == 0)
                    // 登出
                    this.login.DoLogout(this.loginResponse.UCID, this.loginResponse.ST);
            }
        }
    }
}
