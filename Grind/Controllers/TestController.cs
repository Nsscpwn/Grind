using Grind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Services;

namespace Grind.Controllers
{
    public class TestController : ApiController
    {
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        public JsonResult<int> Test(int UserID)
        {
            Main main = new Main();
            main.FightDet.getFight(UserID);
            return Json(main.StatsModel.Health);
        }
    }
}