using ATM_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM_Online.Services
{
    public class CheckingAccountServices
    {
        private ApplicationDbContext db;

        public CheckingAccountServices(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void Register(string firstName, string lastName, string ID)
        {
            //chequear account number
            var accountnumber = (123456 + db.ChekingAccounts.Count()).ToString().PadLeft(10, '0');
            var chekingaccount = new ChekingAccount
            {
                FirstName = firstName,
                LastName = lastName,
                AccountNumber = accountnumber,
                Balance = 0,
                ApplicationUserId = ID
            };
            db.ChekingAccounts.Add(chekingaccount);
            db.SaveChanges();
        }

        public void UpdateBalance (int checkingAccountId)
        {
            var checkingAccount = db.ChekingAccounts.Find(checkingAccountId);
            checkingAccount.Balance = db.Transactions.Where(c=>c.CheckingAccountId == checkingAccountId).Sum(c=>c.Amount);
            db.SaveChanges();
        }
    }
  
}