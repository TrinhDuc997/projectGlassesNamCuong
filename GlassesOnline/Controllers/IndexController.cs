using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlassesOnline.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult ViewIndex()
        {
            return View();
        }
    }
}