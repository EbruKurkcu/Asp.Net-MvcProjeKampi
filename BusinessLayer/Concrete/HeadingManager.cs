using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService      //İmplement edildi..
    {

        IHeadingDal _headingDal;            //CONSTRUCTOR OLUŞTURULDU

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)     //Bulma Find
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()   //Listeleme
        {
           return _headingDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public void HeadingAdd(Heading heading)    //Ekleme
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)    //Ekleme
        {
             //heading.HeadingStatus = false; //Başlıkları tamamen silmek yerine durumunu false haline getir veritabanında kayıtlı kalsın.

            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)    //Update
        {
            _headingDal.Update(heading);
        }
    }
}
