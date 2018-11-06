using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tryingforvue.Models.VM;
using Vue.BussinessLayer.Services;
using Vue.DataLayer;

namespace Tryingforvue.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            return View();

        }
      public ActionResult Category()
        {
            return View();
        }

    }
}