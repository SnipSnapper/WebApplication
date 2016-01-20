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

        public string attribute;

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SpeedData(Int64 number2, Int64 number, bool equal = false, bool greater = false, bool less = false)
        {
            var run = Task.Run(() => DataSpeed(number2, number, equal, greater, less));
            var result = run.Result;
            List<HtmlString> list = new List<HtmlString>();
            list = result;
            ViewBag.speed = list;

            return View();

        }

        public ActionResult UnitIdData(long unitAtt, bool UnitSpeed = false, bool UnitLocation = false)
        {
            var run = Task.Run(() => DataUnitId(unitAtt, UnitSpeed, UnitLocation));
            var result = run.Result;
            List<HtmlString> list = new List<HtmlString>();
            list = result;

            ViewBag.UnitId = list;

            return View();


        }

        public async Task<List<HtmlString>> DataSpeed(Int64 number2, Int64 number, bool equal, bool greater, bool less)
        {

            var positionList = await Task.Run(() => DBQuery.GetSpeedData(number2, number, equal, greater, less).Result);
            return positionList;

        }
        public async Task<List<HtmlString>> DataUnitId(long unitAtt, bool UnitSpeed, bool UnitLocation)
        {

            var speedList = await Task.Run(() => DBQuery.GetUnitIdData(unitAtt, UnitSpeed, UnitLocation).Result);
            return speedList;

        }

        public void ChangeAtt(string Attribute) {

            attribute = Attribute;

        }
    }
}
