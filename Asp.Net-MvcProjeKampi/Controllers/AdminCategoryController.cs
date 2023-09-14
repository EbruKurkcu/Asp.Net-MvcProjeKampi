using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Asp.Net_MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory

        //CategoryManager 'dan bir nesne türettim. İçerisine de CategoryDaldan nesne türettim
        //Neden bu şekilde bir kullanım mevcut? Çünkü projeler ileride değiştiğinde sadece ilgili alanı değiştirip
        //bütün sayfalarda değişiklik yapmak yerine küçük dokunuşlar ile değişiklik yaparak projede ilerlenebilmesi için 
        // new EfCategoryDal() bu kısım kullanılıyor.
        //Projede bağımlılıkları en aza indirmek için bu şekilde kullanılması en doğru yöntem.


        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles="B")]  //Sadece Brolüne sahip olan kişiler bu sayfayı görüntüleyebilsin
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }



        [HttpGet]
        public ActionResult AddCategory()  //EKLEME
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Category p)  //EKLEME
        {
            //CategoryValidatior çağırıyoruz öncelikle çünkü geçerlilik sorgulaması yapılacak.
            CategoryValidatior categoryvalidator = new CategoryValidatior();
            ValidationResult result = categoryvalidator.Validate(p);  // Sonucu kontrol işlemi


            if (result.IsValid)  //Eğer sonuç geçerliyse Ekleme işlemini yap
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else  //Validasyon geçerli değilse
            {
               foreach (var item in result.Errors)   //Eğer sonuç yanlışsa
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }



        //SİLME ACTİONU
        public ActionResult DeleteCategory(int id)   //Dışarıdan bir id parametresi alacak
        {
            var categoryvalue = cm.GetByID(id);  //Değeri bulduk Find
            cm.CategoryDelete(categoryvalue);    //Değeri sileceğiz
            return RedirectToAction("Index");
        }



        //GÜNCELLEME ACTİONU

        [HttpGet]  //Sayfa yüklendiği zaman çalış
        public ActionResult UpdateCategory(int id)   //İlgili satırın kayıtlarını getiren bulan sayfa
        {
            var categoryvalue = cm.GetByID(id);  //İlgili ID'ye ait verileri Güncelleme sayfasına taşıyacak
                                                  //Güncellenecek id 'ye ait kayıtın sayfasına yönlendirecek
            return View(categoryvalue);
        }


        [HttpPost]   //Güncelle Butonuna bastığımda çalışacak

        public ActionResult UpdateCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}