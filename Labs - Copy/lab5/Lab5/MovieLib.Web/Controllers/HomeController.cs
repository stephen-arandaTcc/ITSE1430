// Stephen Aranda
// 12/9/2017
// ITSE 1430
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieLib.Web.Controllers 
{
    public class HomeController : Controller 
    {
        public ActionResult Index()
        {
            return View();
        }        
    }
}