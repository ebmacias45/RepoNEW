using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM_Online.Models
{
    public class TransferViewModel
    {
        [Required]
        [Key]
        public int TransferViewModelId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public int CheckingAccountId { get; set; }

        [Required]
        [Display(Name = "To Account #")]
        public string DestinationAccountNumber { get; set; }
    }
}