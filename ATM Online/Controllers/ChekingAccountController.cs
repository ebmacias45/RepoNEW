using ATM_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ATM_Online.Controllers
{
    [Authorize]
    public class ChekingAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ChekingAccount
        public ActionResult Index()
        {
           return View();
        }

        // GET: ChekingAccount/Details
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId(); 
            var chekingaccount = db.ChekingAccounts.Where(c=>c.ApplicationUserId == userId).First();
            return View(chekingaccount);
        }

        // GET: ChekingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChekingAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChekingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChekingAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChekingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChekingAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Statement()
        { 
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.ChekingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            var checkingaccount = db.ChekingAccounts.Find(checkingAccountId);
            return View(checkingaccount.Transactions.ToList());
        }
     }
}
