using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();  //Listeleme

        void ContactAdd(Contact contact);  //Ekleme

        Contact GetByID(int id);  //İlgili değeri getirme yani Find İşlemi Bulma

        void ContactDelete(Contact contact); //SİLME

        void ContactUpdate(Contact contact);  //GÜNCELLEME

    }
}
