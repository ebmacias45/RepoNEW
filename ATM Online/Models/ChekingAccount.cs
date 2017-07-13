using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATM_Online.Models
{
    public class ChekingAccount
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Account Number")]
        [StringLength(10)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"\d{6,10}",ErrorMessage ="The Account Number lenght must be between 6 and 10 digits")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Name
        {
            get
            {
                return String.Format("{0} {1}",this.FirstName, this.LastName);
            }
        }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}