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

namespace Asp.Net_MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        //BusinessLayer katmanında oluşturduğumuz CategoryManager sınıfını çağırmalıyız.
        CategoryManager cm = new CategoryManager(new EfCategoryDal());   //CategoryManager sınıfından metotlarımıza ulaştık


        public ActionResult GetCategoryList()   //Kategori Elamanlarını Listeleme
        {
           var categoryvalues = cm.GetList();  //CategoryManager sınıfı içerisindeki metoda erişim sağladık.
            return View(categoryvalues);
        }




        [HttpGet]  //Sayfa Yüklendiği zaman Get Çalışacak
        public ActionResult AddCategory()  
        {
            return View();   //Bu sayfayı geriye döndürmek
        }




        [HttpPost]  //Butona bastığım zaman post çalışacak.Basma işlemi gerçekleşmediği zaman herhangi bir veri ekleme işlemi yapılmayacak
        public ActionResult AddCategory(Category p)
        {
            // cm.CategoryAddBL(p);

            //Oluşturduğumuz CategoryValidatior sınıfına erişim sağlıyoruz newleyerek.

            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult result = categoryValidatior.Validate(p);  //Validate geçerliliğini kontrol etmek demektir

            if (result.IsValid)   //Eğer sonuç geçerli ise aşağıdaki işlemleri yap. Yani
                                  //kategori ekleme işleminde textboxlara yazdıklarım validasyon kurallarına uygunsa 
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in result.Errors) 
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }
    }
}