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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)   //Contructor oluşturuldu.
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About about)   
        { 
            _aboutDal.Insert(about);       //EKLEME
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Delete(about);       //SİLME
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);       //GÜNCELLEME
        }

        public About GetByID(int id)
        {
            return _aboutDal.Get(x => x.AboutID == id);      //İD BULMA FİND
        }

        public List<About> GetList()
        {
            return _aboutDal.List();       //LİSTELEME
        }
    }
}
