using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService   //İmplement edildi..
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);      //EKLEME KODU
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);   //SİLME KODU
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);  //GÜNCELLEME KODU
        }

        public Contact GetByID(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);   //İLGİLİ ID GETİRİLECEK
        }

        public List<Contact> GetList()
        {
           return _contactDal.List();  //LİSTELEME KODU
        }
        //NOT: VOİD İÇEREN METOTLAR RETURN EDİLEMEZ!!!!!!!!!!!!
    }
}
