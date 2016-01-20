using Rotativa;
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

        string attribute;
        public ActionResult Index()
        {
            return View();
        }

        public void ChooseData(string Attribute) {

            attribute = Attribute;
        }

        public ActionResult SpeedData(Int64 number2, Int64 number, bool equal = false, bool greater = false, bool less = false)
        {
            string att = attribute;
            var run = Task.Run(() => DataSpeed(att, number2, number, equal, greater, less));
            var result = run.Result;
            List<HtmlString> list = new List<HtmlString>();
            list = result;
            ViewBag.speed = list;

            return View();

        }
        public ActionResult DownloadViewPDF()
        {
            return new Rotativa.ViewAsPdf("Index")
            {
                FileName = Server.MapPath("~/Account/Login?ReturnUrl=%2F")
            };
        }


        public void UnitIdData(string att, string unitAtt, bool UnitSpeed = false, bool UnitLocation = false)
        {
            var run = Task.Run(() => DataUnitId(att, unitAtt, UnitSpeed, UnitLocation));
            var result = run.Result;
            List<HtmlString> list = new List<HtmlString>();
            list = result;

            ViewBag.UnitId = list;
            ViewBag.Count = ViewBag.position.Count;


        }

        public async Task<List<HtmlString>> DataSpeed(string att, Int64 number2, Int64 number, bool equal, bool greater, bool less)
        {

            var positionList = await Task.Run(() => DBQuery.GetSpeedData(att, number2, number, equal, greater, less).Result);
            return positionList;

        }
        public async Task<List<HtmlString>> DataUnitId(string att, string unitAtt, bool UnitSpeed, bool UnitLocation)
        {

            var speedList = await Task.Run(() => DBQuery.GetUnitIdData(att, unitAtt, UnitSpeed, UnitLocation).Result);
            return speedList;

        }
    }
}
