using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGuardian.Models;

namespace TheGuardian.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Welcome()
        {


            return View();
        }
        public ActionResult ShowData()
        {
            GuardianDBEntities db = new GuardianDBEntities();
            List<UserData> list = new List<UserData>();

            var data = from tbl in db.TBL_USERRECORD select tbl;
            foreach (var item in data)
            {
                UserData model = new UserData();
                model.THREADTYPE = item.THREAD_TYPE;
                model.BODY = item.MSG_BODY;
                model.PHONE_NUMBER = item.PHONE_NUMBER;
                model.TYPE = item.TYPE;
                model.DATE_TIME = item.DATE_TIME;
                model.CALL_DURATION = item.CALL_DURATION;
                model.TITLE = item.LINK_TITLE;
                model.URL = item.LINK_URL;
                model.LONGITUDE = item.LONGITUDE;
                model.LATITUDE = item.LATITUDE;

                list.Add(model);


            }






            return View(list.AsEnumerable());
        }

        public void Delete(int id)
        {
            //logic to delete the data with this id.
        }
    }
}
