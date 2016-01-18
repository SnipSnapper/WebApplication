using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Test1(string att, Int64 number, string html, bool equal = false, bool greater = false, bool less = false)
        {
            var run = Task.Run(() => Data(att, number, equal, greater, less));
            //PdfSharpConvert(html);
            var result = run.Result;
            list = result;

            ViewBag.position = list;
            ViewBag.Count = ViewBag.position.Count;
            
            return View();

        }

        public async Task<List<HtmlString>> Data(string att, Int64 number, bool equal, bool greater, bool less)
        {

            var positionList = await Task.Run(() => DBQuery.GetPosition(att, number, equal, greater, less).Result);
            System.Diagnostics.Debug.WriteLine(list.Count());
            return positionList;

        }
    }
}
