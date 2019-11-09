using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Ogrenci
    {
        [Key]
        public int _id { get; set; }
        [Required]
        public string Isim { get; set; }
        [Required]
        public string SoyIsım { get; set; }
        [Required]
        public string KimlikNo { get; set; }
        [NotMapped]
        public Counter<string> Okullar { get; set; }
        [NotMapped]
        public Counter<string> Ogretmenler { get; set; }
    }
}
