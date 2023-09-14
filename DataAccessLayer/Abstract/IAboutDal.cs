using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDal:IRepository<About>
    {


        //Daha detaylı anlatmak için tek tek her sınıfta CRUD metodlarını eklemek yerine tek bir sınıfta(IRepository) tanımlayıp
        //diğer sınıflardan o sınıfı interface yoluyla kullanmamızı sağlıyor. Miras kalıtım yoluyla. 
        //Yeni bir metot eklemek istediğimizde bütün sınıflara eklemek yerine sadece ana sınıfa IRepository sınıfına ekleyip diğer sınıflardan 
        //kalıtım yoluyla implement ediyoruz.


    }
}
