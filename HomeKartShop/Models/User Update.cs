using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeKartShop.Models
{
    public class User_Update
    {

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name Required")]
        [RegularExpression("[A-Z][a-z-A-Z]+$", ErrorMessage = "Enter a valid name")]
        [MinLength(8, ErrorMessage = "Min 8 digits required")]
        [MaxLength(20, ErrorMessage = "Max 20 Digits allowed")]
        public string CustomerFirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required")]
        [RegularExpression("[A-Z][a-z-A-Z]+$", ErrorMessage = "Enter a valid name")]
        [MinLength(8, ErrorMessage = "Min 8 digits required")]
        [MaxLength(20, ErrorMessage = "Max 20 Digits allowed")]
        public string CustomerSecondName { get; set; }
        [Display(Name = "State")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "State Required")]
        public string State { get; set; }
        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "City Required")]
        public string City { get; set; }
        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Required")]
        [RegularExpression(@"^[\w\.\,\-\/]{10,50}$", ErrorMessage = "Enter a valid address")]
        [MinLength(10, ErrorMessage = "Min 10 digits required")]
        [MaxLength(50, ErrorMessage = "Max 50 Digits allowed")]
        public string Address { get; set; }
        [Display(Name = "Cell Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Cell Number Required")]
        [RegularExpression(@"[6789]\d{9}", ErrorMessage = "Enter a valid cellnumber")]
        public long CellNumber { get; set; }
        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Enter a valid cellnumber")]
        public string Email { get; set; }
        [Display(Name = "Date of Birth")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of Birth Required")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "PinCode")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PinCode Required")]
        [DataType(DataType.PostalCode)]
        public int PinCode { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Min 8 digits required")]
        [MaxLength(15, ErrorMessage = "Max 15 Digits allowed")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender Required")]
        public string gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }
    }
}
