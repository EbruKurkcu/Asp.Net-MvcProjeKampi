using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();  //Listeleme

        void AboutAdd(About about);  //Ekleme

        About GetByID(int id);  //İlgili değeri getirme yani Find İşlemi Bulma

        void AboutDelete(About about); //SİLME

        void AboutUpdate(About about);  //GÜNCELLEME
    }
}
