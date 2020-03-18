using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartShop.Entity
{
    [Table("Inventory")]
    public class Inventory
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [MaxLength(20)]
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Price { get; set; }
        [MaxLength(20)]
        [Required]
        public string Quantity { get; set; }
        [MaxLength(20)]
        [Required]
        public string Category { get; set; }
        [Required]
        public int TotalStock { get; set; }
        [Required]
        public int TotalSold { get; set; }
        [Required]
        public int Remaining { get; set; }
    }
}
