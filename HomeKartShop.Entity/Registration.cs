using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartShop.Entity
{
    [Table("State")]
    public class State
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }
        [MaxLength(20)]
        [Required]
        public string StateName { get; set; }
    }
    [Table("City")]
    public class City
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        [MaxLength(20)]
        [Required]
        public string CityName { get; set; }
        public State StateId{ get; set;}
    }
}
