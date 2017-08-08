using DaiMengCoolApi.Models;
using DaiMengCoolApi.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DaiMengCoolApi.Controllers
{
    public class HomeController : ApiController
    {
        [Route("home/GetLxflData")]
        [HttpGet]
        public IHttpActionResult GetLxflData(int type=0)//0连续放量，1连续缩量
        {

            string url = "";
            if (type ==0)
            {
                url = "http://money.finance.sina.com.cn/quotes_service/api/jsonp_v2.php/IO.XSRV2.CallbackList['M5a$19K_cODdxgk9']/StatisticsService.getVolumeRiseConList?page=1&num=2000&sort=day_con&asc=0&node=adr_hk";
            }
            else if (type == 1)
            {
                url = "http://money.finance.sina.com.cn/quotes_service/api/jsonp_v2.php/IO.XSRV2.CallbackList['y2PhvJWEK4sZBTJW']/StatisticsService.getVolumeReduceConList?page=1&num=2000&sort=day_con&asc=0&node=adr_hk";
            }
            else if (type == 2)
            {
                url = "http://money.finance.sina.com.cn/quotes_service/api/jsonp_v2.php/IO.XSRV2.CallbackList['1TUU$LlcNl2QZYVR']/StatisticsService.getVolumeRiseList?page=1&num=2000&sort=changes_volume_per&asc=0&node=adr_hk";
            }
            else if (type == 3)
            {
                url = "http://money.finance.sina.com.cn/quotes_service/api/jsonp_v2.php/IO.XSRV2.CallbackList['pkfkImCUmAiy8tnu']/StatisticsService.getVolumeReduceList?page=1&num=2000&sort=changes_volume_per&asc=1&node=adr_hk";
            }
            else if (type == 4)
            {
                url = "http://money.finance.sina.com.cn/quotes_service/api/jsonp_v2.php/IO.XSRV2.CallbackList['t5EMB_i_mXBQgad2']/StatisticsService.getStockRiseConList?page=1&num=2000&sort=day_con&asc=0&node=adr_hk";
            }
            else if (type == 5)
            {
                url = "http://money.finance.sina.com.cn/quotes_service/api/jsonp_v2.php/IO.XSRV2.CallbackList['2oJd$cOKxLwpSUbm']/StatisticsService.getStockReduceConList?page=1&num=2000&sort=day_con&asc=0&node=adr_hk";
            }
            else
            {

            }

            string content = FinanceUtil.GetHtml(url);//WXMsgUtil.GetTulingMsg(info);
            List<VolumeRise> list = JsonConvert.DeserializeObject<List<VolumeRise>>(content);
            //MySqlHelper.InsertVlumeRise(list);
            return Ok(list);
        }
    }
}
