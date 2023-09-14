using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key] //Birincil Anahtar
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; } /* Aktif Pasif Durumu*/




        //Heading-Content Tablo İlişkisi
        //İçerik Tablosunda birden fazla kez başlık yer alabiliyor.
        //BireÇok ilişkinin çok kısmı

        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }




        //Content-Writer Tablo İlişkisi
        //İçerik Tablosunda birden fazla kez yazar yer alabiliyor.
        //BireÇok ilişkinin çok kısmı

        public int? WriterID { get; set; }  //Benim yazar İD'm boş olabilir.Bir değer giriş yapılmak zorunda değil.O yüzden nullable type tanımlayabiliriz.
        public virtual Writer Writer { get; set; }
    }
}
