using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService    //İmplement edildi..
    {


        //Solid prensiplerinden Dependency Injection kullanıldı.


        //Burada amaç CategoryManager Sınıfı içerisindeki GenericRepository new 'lemeden GenericRepository 'e bağımlılığımı minimize ederek
        //GenericRepository 'i newlemeden o sınıfa erişim sağladım.
        //Nasıl? ICategoryDal sayesinde.   //CONSTROCTUR OLUŞTURULDU.  ICategoryDal IRepositoryi imlement etti. 
        //IRepository içerisindeki metotları ise GenericRepositoryde doldurduk.
        //Soyutlama sayesinde ICategoryDaldan GenericRepositorye newlemeden erişim sağladık.
        //GenericRepository sınıfının içerisindeki değerlere erişim sağlamış olduk. Bağımlılıklar azaltılmış oldu
        //Daha önce aşağıda newledik GenericRepositoryi hatalı kullanım.
        //Newleme işlemi yapmadan sınıflar arasında imlement ederek iç içe bir şekilde GenericRepository e erişşim sağlıyoruz.


        ICategoryDal _categoryDal;          //CONSTROCTUR OLUŞTURULDU.

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

       

        public List<Category> GetList()    //LİSTELEME KODU
        {
            return _categoryDal.List();
        }



        // GenericRepository<Category> repo = new GenericRepository<Category>();   //GenericRepositoriesten bir nesne türettik.

        //public List<Category> GetAllBL()  //Sonundaki Bl BusinessLayer demek.
        //{
        //    return repo.List();   //LİSTELEME KODU
        //}



        //public void CategoryAddBL(Category p)     //EKLEME KODU
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryStatus == false || p.CategoryName.Length >= 51)
        //    {
        //        Hata Mesajı Gelecek
        //    }
        //    else
        //    {
        //        repo.Insert(p);
        //    }
        //}


        public void CategoryAdd(Category category)  //EKLEME KODU
        {          
            _categoryDal.Insert(category);  //_categorydal . (nokta) dediğimde IRepository sınıfında tanımladığım metotlar listeleniyor.
        }



        public Category GetByID(int id)  //Bulma Find
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public void CategoryDelete(Category category)  //Silme
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)  //Güncelleme
        {
            _categoryDal.Update(category);
        }
    }
}
