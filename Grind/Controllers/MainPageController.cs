using Grind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grind.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MainPage
        public ActionResult Index()
        {
            Main main= new Main();
            return View(main);
        }
    }
}