using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmovie.Controllers
{
    public class helloworldController : Controller
    {
        // GET: helloworld
        public ActionResult Index()
        {
            return View();
        }
    }
}