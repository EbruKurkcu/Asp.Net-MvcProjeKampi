using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        public bool HeadingStatus { get; set; }



        //Category-Heading Tablo İlişkisi
        //Heading Tablosunda birden fazla kez Kategori yer alabiliyor. Bire Çok ilişkinin çok kısmı
        //Bir kategori birden fazla başlık oluşturabilir
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }  //CategoryId 'nin ilişkide olup olmadığını virtual anahtar kelimesiyle anlıyoruz.




        //Heading-Writer Tablo İlişkisi
        //Heading Tablosunda birden fazla kez yazar yer alabiliyor.
        //BireÇok ilişkinin çok kısmı
        //Bir Başlıkta birden fazla Yazar yer alabiliyor.
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }




        //Heading-Content Tablo İlişkisi
        //Bir başlığın yalnızca bir içeriği olabilir
        //BireÇok ilişkinin bir kısmı
        public ICollection<Content> Contents { get; set; }

    }
}
