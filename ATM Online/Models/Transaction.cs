using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace ATM_Online.Models
{
    public class Transaction
    {
        public int Id { get; set;}

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public int CheckingAccountId { get; set; }
        public virtual ChekingAccount CheckingAccount { get; set; }

    }
}