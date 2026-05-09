using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTrip.Models.Siniflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen bir başlık giriniz")]
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez")]
        public string Aciklama { get; set; }
        public string BlogImage { get; set; }
        public ICollection<Yorumlar> Yorumlars { get; set; }
    }
}