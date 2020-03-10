using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeKartShop.Models
{
    public class UserLoginData
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Min 8 digits required")]
        [MaxLength(15, ErrorMessage = "Max 15 Digits allowed")]
        public string Password { get; set; }
    }
}