using Rotativa;
using SelectPdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Windows.Forms;
using System.Text.RegularExpressions;

/// <summary>
/// this class handles every action the viewer does and returns views.
/// </summary>
namespace WebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // return the Index view
        public ActionResult Index()
        {
            return View();
        }

        // receive the data from the view pass it through to the DataSpeed method. get the data back from the database and put it in a list and send it back to the view.
        public ActionResult SpeedData(Int64 number, bool equal = false, bool greater = false, bool less = false, bool between = false, Int64 number2 = 0)
        {
            var run = Task.Run(() => DataSpeed(number, equal, greater, less, between, number2));
            var result = run.Result;
            List<HtmlString> list = new List<HtmlString>();
            list = result;
            ViewBag.speed = list;

            return View();

        }
        //  get data and pass it through to the model class. then get the data back put it in a list and return it.
        public async Task<List<HtmlString>> DataSpeed(Int64 number, bool equal, bool greater, bool less, bool between, Int64 number2 = 0)
        {

            var positionList = await Task.Run(() => DBQuery.GetSpeedData(number, equal, greater, less, between, number2).Result);
            return positionList;

        }

        // receive the data from the view pass it through to the DataSpeed method. get the data back from the database and put it in a list and send it back to the view.
        public ActionResult UnitIdData(long unitAtt, bool UnitSpeed = false, bool UnitLocation = false)
        {
            var run = Task.Run(() => DataUnitId(unitAtt, UnitSpeed, UnitLocation));
            var result = run.Result;
            List<HtmlString> list = new List<HtmlString>();
            list = result;

            ViewBag.UnitId = list;

            return View();


        }
        //  get data and pass it through to the model class. then get the data back put it in a list and return it.
        public async Task<List<HtmlString>> DataUnitId(long unitAtt, bool UnitSpeed, bool UnitLocation)
        {

            var unitIdList = await Task.Run(() => DBQuery.GetUnitIdData(unitAtt, UnitSpeed, UnitLocation).Result);
            return unitIdList;

        }
        // receive the data from the view pass it through to the DataSpeed method. get the data back from the database and put it in a list and send it back to the view.
        public ActionResult DateData(string dateTime, long UnitID, bool DateSpeed = false, bool DateUnitID = false)
        {

            var run = Task.Run(() => Date(dateTime, UnitID, DateSpeed, DateUnitID));
            var result = run.Result;
            List<HtmlString> list = new List<HtmlString>();
            list = result;

            ViewBag.Date = list;

            return View();
        }
        //  get data and pass it through to the model class. then get the data back put it in a list and return it.
        public async Task<List<HtmlString>> Date(string dateTime, long UnitID, bool DateSpeed, bool DateUnitID)
        {

            var positionList = await Task.Run(() => DBQuery.GetDate(dateTime, UnitID, DateSpeed, DateUnitID).Result);
            return positionList;

        }
        // receive the data from the view pass it through to the DataSpeed method. get the data back from the database and put it in a list and send it back to the view.
        public ActionResult SoftwareData(long softwareCarID, string softwareSort)
        {

            var run = Task.Run(() => Software(softwareCarID, softwareSort));
            var result = run.Result;
            List<HtmlString> list = new List<HtmlString>();
            list = result;

            ViewBag.Software = list;

            return View();
        }
        //  get data and pass it through to the model class. then get the data back put it in a list and return it.
        public async Task<List<HtmlString>> Software(long softwareCarID, string softwareSort)
        {

            var softwareList = await Task.Run(() => DBQuery.GetSoftwareData(softwareCarID, softwareSort).Result);
            return softwareList;

        }

        // receive the data from the view pass it through to the DataSpeed method. get the data back from the database and put it in a list and send it back to the view.
        public ActionResult HardwareData(long hardwareCarID, string hardwareSort)
        {
            var run = Task.Run(() => DataHardware(hardwareCarID, hardwareSort));
            var result = run.Result;
            List<HtmlString> list = new List<HtmlString>();
            list = result;

            ViewBag.Hardware = list;
            return View();
        }
        //  get data and pass it through to the model class. then get the data back put it in a list and return it.
        public async Task<List<HtmlString>> DataHardware(long hardwareCarID, string hardwareSort)
        {

            var hardwareList = await Task.Run(() => DBQuery.GetHardwareData(hardwareCarID, hardwareSort).Result);
            return hardwareList;

        }

        //public ActionResult DownloadViewPDF()
        //{
        //    return new Rotativa.ViewAsPdf("Index")
        //    {
        //        FileName = Server.MapPath("~/Account/Login?ReturnUrl=%2F")
        //    };
        //}
    }
}
