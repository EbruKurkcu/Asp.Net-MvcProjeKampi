 using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    //Burada ilgili metodun ismini tanımlıyoruz. Ardından ilgili metodun içini HeadingManager da doldur.
    public interface IHeadingService
    {
        List<Heading> GetList();  //Listeleme
        List<Heading> GetListByWriter(int id);  // Şartlı Listeleme

        void HeadingAdd(Heading heading);  //Ekleme

        Heading GetByID(int id);  //İlgili değeri getirme yani Find İşlemi Bulma

        void HeadingDelete(Heading heading); //SİLME

        void HeadingUpdate(Heading heading);  //GÜNCELLEME
    }
}
