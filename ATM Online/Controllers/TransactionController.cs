using ATM_Online.Models;
using ATM_Online.Services;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ATM_Online.Controllers
{     
    [Authorize]
    public class TransactionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Deposit(int CheckingAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Deposit(Transaction Transaction )
        {
            if (ModelState.IsValid)
            { 
            db.Transactions.Add(Transaction);
            db.SaveChanges();
            var service = new CheckingAccountServices(db);
            service.UpdateBalance(Transaction.CheckingAccountId);
            return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Withdrawal(int CheckingAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Withdrawal(Transaction Transaction)
        {
            var checkingaccount = db.ChekingAccounts.Find(Transaction.CheckingAccountId);

            if (checkingaccount.Balance < Transaction.Amount)
            {
                ModelState.AddModelError("Amount", "You have insufficient funds");
            }
            if(ModelState.IsValid)
            {
                Transaction.Amount = -Transaction.Amount;
                db.Transactions.Add(Transaction);
                db.SaveChanges();
                var service = new CheckingAccountServices(db);
                service.UpdateBalance(Transaction.CheckingAccountId);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Transfer(int CheckingAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Transfer(TransferViewModel Transfer)
        {
            var sourceCheckingAccount = db.ChekingAccounts.Find(Transfer.CheckingAccountId);
            if (sourceCheckingAccount.Balance < Transfer.Amount)
            {
                ModelState.AddModelError("Amount", "You have insufficient funds");
            }
            var destCheckingAccount = db.ChekingAccounts.Where(c => c.AccountNumber == Transfer.DestinationAccountNumber).FirstOrDefault();
            if (destCheckingAccount == null)
            {
                ModelState.AddModelError("DestinationAccountNumber", "Invalid Destination Checking Account Number");
            }
            if (ModelState.IsValid)
            {
                db.Transactions.Add(new Transaction { CheckingAccountId = Transfer.CheckingAccountId, Amount = -Transfer.Amount });
                db.Transactions.Add(new Transaction { CheckingAccountId = destCheckingAccount.Id, Amount = Transfer.Amount });
                db.SaveChanges();
                var service = new CheckingAccountServices(db);
                service.UpdateBalance(Transfer.CheckingAccountId);
                service.UpdateBalance(destCheckingAccount.Id);
                return PartialView("_TransferSuccess", Transfer);

            }
            return PartialView("_TransferForm");
        }

        public ActionResult TransChart(int id,Transaction T)
        {
            var list = new object[db.Transactions.Count()];
            int j = 0;
            foreach (var i in db.Transactions.Where(c=>c.CheckingAccountId == id))
            {
                list[j] = new object[] { i.CheckingAccountId.ToString(), Math.Abs(i.Amount) };
                j++;
            }
            string datastr = JsonConvert.SerializeObject(list, Formatting.None);
            ViewBag.dataj = new HtmlString(datastr);
            return View();
        }


    }
}