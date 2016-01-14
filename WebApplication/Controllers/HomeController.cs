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

        public ActionResult GoogleMap()
        {
            string d1 = "56.156167";
            string d2 = "56.256167";
            Vector2 vec1 = new Vector2(d1, d2);
            string d3 = "56.356166";
            Vector2 vec2 = new Vector2(d2, d3);
            

            List<Vector2> list = new List<Vector2>();

            list.Add(vec1);
            list.Add(vec2);

            ViewBag.Message = list;
            return View();
        }

        public ActionResult Chart()
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
