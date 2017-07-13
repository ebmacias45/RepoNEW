using ATM_Online.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ATM_Online.Controllers
{
    public class HomeController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.ChekingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ATM Online.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message ="Having Troubles? Send us a message!";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.Message ="Thanks, we got your message!";

            return PartialView("_ContactThanks");
        }
    }
}