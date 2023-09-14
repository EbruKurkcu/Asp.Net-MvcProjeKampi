﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext  // [:] ne demek? Birbaşka sınıftan verileri kalıtımsal yollardan erişmek demektir
    {

        //Burada about sınıfını kullanmamıza izin verilmiyor. Çünkü about sınıfı EntityLayer katmanında bizim bulunduğumuz
        //katman ise DataAccessLayer katmanı farklı katmanlarda sınıflarını, propertylerini
        //kullanmamız için bazı değişiklikler yapmamız gerekiyor.
        //O değişiklik ise kullanmak istediğimiz sınıfın katmanını referans(başvuru) olarak eklememiz gerekiyor.

        public DbSet<About>  Abouts { get; set; }
        public DbSet<Category>  Categories { get; set; } //"Category" =>EntityLayer katmanı içindeki Concrete klasöründe yer alan sınıfın ismi
                                                         //"Categories" => Sql tarafına yansıyacak olan tablonun ismi
        public DbSet<Contact>  Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
