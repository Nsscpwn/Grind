using Grind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Grind.Controllers
{

    public class MesajController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
    }
}

