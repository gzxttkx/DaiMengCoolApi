using System;
using System.Net;
using System.Text;

namespace DaiMengCoolApi.Utils
{
    public class FinanceUtil
    {
        public static string GetHtml(string url)
        {

            WebClient MyWebClient = new WebClient();


            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

            Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据

            string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句  
            pageHtml = pageHtml.Substring(pageHtml.IndexOf("[{"),pageHtml.Length- pageHtml.IndexOf("[{")-1);

            return pageHtml;
        }
    }
}
