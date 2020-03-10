using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartShop.Entity
{
    [Table("User")]
    public class User
    {
        
        public string CustomerFirstName { get; set; }
        public string CustomerSecondName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public long CellNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RegistrationNumber { get; set; }
        public int PinCode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [StringLength(450)]
        [Index(IsUnique =true)]
        public string UserName { get; set; }
        public string gender { get; set; }
        public string Search { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
    }
}
