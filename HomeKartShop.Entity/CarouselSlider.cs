using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKartShop.Entity
{
    [Table("CarouselSlider")]
    public class CarouselSlider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(100)]
        [Required]
        public string FileName { get; set; }
        [Required]
        public int FileSize { get; set; }
        [MaxLength(100)]
        [Required]
        public string FilePath { get; set; }
    }
}
