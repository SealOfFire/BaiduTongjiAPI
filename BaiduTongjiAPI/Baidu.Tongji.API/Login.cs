using Baidu.Tongji.API.JSON.Login;
using Newtonsoft.Json;

namespace Baidu.Tongji.API
{
    public class Login
    {
        public const string URL = "https://api.baidu.com/sem/common/HolmesLoginService";

        private Header header;
        private string password;
        private Request request;

        public string UserName { get { return this.header.UserName; } set { this.header.UserName = value; } }
        public string Token { get { return this.header.Token; } set { this.header.Token = value; } }

        public Login()
        {
            this.header = new Header();
        }

        public Login(string userName, string password, string token)
        {
            this.header = new Header();
            this.header.UserName = userName;
            this.header.Token = token;
            this.password = password; ;
        }

        public PreLoginResponse PreLgoin()
        {
            this.header.FunctionName = "preLogin";
            this.request = new PreLoginRequest();
            this.header.Request = request;

            PreLoginResponse value = this.Request<PreLoginResponse>();
            return value;
        }

        public DoLoginResponse DoLogin()
        {
            this.header.FunctionName = "doLogin";
            this.request = new DoLoginRequest();
            this.header.Request = request;
            (this.request as DoLoginRequest).Password = this.password;

            DoLoginResponse value = this.Request<DoLoginResponse>();
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        public DoLogoutResponse DoLogout(long ucid, string st)
        {
            this.header.FunctionName = "doLogout";
            this.request = new DoLogoutRequest();
            this.header.Request = request;
            (this.request as DoLogoutRequest).UCID = ucid;
            (this.request as DoLogoutRequest).ST = st;

            DoLogoutResponse value = this.Request<DoLogoutResponse>();
            return value;
        }

        public T Request<T>()
        {
            string value = HttpManager.RequestLogin(Login.URL, "1", this.header);
            T response = JsonConvert.DeserializeObject<T>(value);
            return response;
        }
    }
}
