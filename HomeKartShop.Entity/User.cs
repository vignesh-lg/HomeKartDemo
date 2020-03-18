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
        [MaxLength(20)]
        [Required]
        public string CustomerFirstName { get; set; }
        [MaxLength(20)]
        [Required]
        public string CustomerSecondName { get; set; }
        [MaxLength(20)]
        [Required]
        public string State { get; set; }
        [MaxLength(20)]
        [Required]
        public string City { get; set; }
        [MaxLength(70)]
        [Required]
        public string Address { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public long CellNumber { get; set; }
        [MaxLength(50)]
        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(20)]
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public int PinCode { get; set; }
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }
        [MaxLength(20)]
        [Required]
        [StringLength(450)]
        [Index(IsUnique =true)]
        public string UserName { get; set; }
        [MaxLength(20)]
        [Required]
        public string gender { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
    }
}
