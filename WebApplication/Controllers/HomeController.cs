using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test1()
        {
            DBQuery.Data();
            ViewData["data"] = DBQuery.list;
            return View();

        }
        public void TestMethod() {

            


        }
    }
}
