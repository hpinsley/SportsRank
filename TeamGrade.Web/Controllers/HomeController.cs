using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamGrade.Web.Controllers {
    public class HomeController : Controller {

        public ActionResult About() {
            ViewBag.Message = "Sports Result Analysis";

            return View();
        }
    }
}
