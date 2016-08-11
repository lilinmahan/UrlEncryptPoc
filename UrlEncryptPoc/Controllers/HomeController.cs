using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrlEncryptPoc.Helper;
using UrlEncryptPoc.Models;

namespace UrlEncryptPoc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [EncryptedActionParameter]
        public ActionResult TestPage(string testString, int testInt)
        {
            ViewBag.Message = "Your contact page.";
            var testPageModel = new TestPageModel() {TestInt = testInt,TestString = testString};
            return View(testPageModel);
        }
    }
}