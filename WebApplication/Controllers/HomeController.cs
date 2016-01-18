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
