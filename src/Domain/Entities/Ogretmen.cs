using Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Ogretmen
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
        public List<string> Ogrenciler { get; set; }
    }
}
