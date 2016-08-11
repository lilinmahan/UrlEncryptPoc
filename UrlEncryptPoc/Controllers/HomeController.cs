using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var ip= Request.UserHostAddress;
            ViewBag.Message = ip;
            ViewBag.MessageTest = Request.Browser.Browser+Request.Browser.Version;
            IPAddress myIP = IPAddress.Parse(ip);
            IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
            List<string> compName = GetIPHost.HostName.Split('.').ToList();
            ViewBag.MessageName = compName[0];
            ViewBag.SessionId = System.Web.HttpContext.Current.Session.SessionID;

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

        [Throttle(Name = "Test",Milliseconds = 500)]
        [EncryptedActionParameter]
        public ActionResult TestPage(string testString, int testInt)
        {
            ViewBag.Message = "Your contact page.";
            var testPageModel = new TestPageModel() {TestInt = testInt,TestString = testString};
            return View(testPageModel);
        }
    }
}