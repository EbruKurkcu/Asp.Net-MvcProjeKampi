using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{

    //EntityFramework içerisinde sadece ilgili entitye özgü metotların içi doldurulacak :)
    //Hem GenericRepository deki Category sınıfının değerlerini hemde ICategoryDal sınıfı içerisinde yer alan değerlerede ulaş al
   // Böylelikle katmanlarımı katmanların içerisinde yer alan sınıfları birbirleriyle haberlştirerek her bir katmanın yadan sınıfın
   //içindeki komut sadece kendisine ait işlemleri gerçekleştirsin. istiyorum.
   //EfCategoryDal kullanarak Genericrepositorye ulaşmış oldum aynı zamandada ICategoryDala da ulaştım.
    public class EfCategoryDal:GenericRepository<Category>, ICategoryDal
    {
    }
}
