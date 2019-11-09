using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Application.ValueObjects;

namespace Application.Models
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
        public List<string> Okullar { get; set; }
        [NotMapped]
        public List<string> Ogretmenler { get; set; }
    }
}
