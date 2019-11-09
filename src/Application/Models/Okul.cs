using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models
{
    public class Okul
    {
        [Key]
        public int _id { get; set; }
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Sehir { get; set; }
        [Required]
        public string Ilce { get; set; }
        [NotMapped]
        public List<string> Ogrenciler { get; set; }
    }
}
