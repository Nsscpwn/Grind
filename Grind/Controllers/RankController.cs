using Grind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grind.Controllers
{
    public class RankController : Controller
    {
        // GET: Rank
        public ActionResult Rank()
        {
            Main main = new Main();
            main.SQL.getRankLvl();
            main.SQL.getRankNames();
            main.SQL.totalplayers();
            return View("Rank",main);
        }
    }
}