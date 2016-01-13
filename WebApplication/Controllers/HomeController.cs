using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static List<HtmlString> list = new List<HtmlString>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test1()
        {
            var run = Task.Run(() => Data());
            var result = run.Result;
            list = result;

            ViewBag.position = list;
            ViewBag.Count = ViewBag.position.Count;
            
            return View();

        }

        public async Task<List<HtmlString>> Data() {

            var positionList = await Task.Run(() => DBQuery.GetPosition().Result);
            System.Diagnostics.Debug.WriteLine(list.Count());
            return positionList;

        }
    }
}
