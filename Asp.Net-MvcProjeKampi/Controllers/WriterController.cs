using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Asp.Net_MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer

        WriterManager wm = new WriterManager(new EfWriterDal());

        WriterValidator validationRules = new WriterValidator();
        public ActionResult Index()
        {
            var writervalues = wm.GetList();
            return View(writervalues);
        }



        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddWriter(Writer p)  //Ekleme Yaparken kullanıcıdan doğrulama isteyeceğiz.
                                                 //Minimum, Maksimm, Boş Geçme durumlarının kontrolü sağlanmalıdır.

        {

            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
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


        [HttpGet]
        public ActionResult EditWriter(int id)   //Profili Düzenle alanı yani Güncelleme Alanıdır.
        {
            var writervalues = wm.GetByID(id);   //Düzenlenecek olan kayıtı bulacak id'ye göre
            return View(writervalues);
        }


        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {

            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
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