using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm=new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }



        [HttpGet]  
        public ActionResult AddHeading()         //Ekleme Kodu
        {
            List<SelectListItem> valuecategori = (from x in cm.GetList()      //DROPDOWNLİST
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
              
                                                  }) .ToList();


            List<SelectListItem> valuewriter = (from y in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = y.WriterName + " " + y.WriterSurName,
                                                    Value = y.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlw = valuewriter;
            ViewBag.vlc = valuecategori;
            return View();
        }



        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult EditHeading(int id)   //Güncelleme sayfasına taşıma işlemi
        {
            List<SelectListItem> valuecategori = (from x in cm.GetList()      //DROPDOWNLİST
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();

            ViewBag.vlc = valuecategori;
            var headingvalues = hm.GetByID(id);
            return View(headingvalues);
        }


        [HttpPost]
        public ActionResult EditHeading(Heading p)  //Güncelleme Kodu
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteHeading(int id)   //Silme
        {
            var headingvalues = hm.GetByID(id);
            headingvalues.HeadingStatus = false;
            hm.HeadingDelete(headingvalues);
            return RedirectToAction("Index");
        }
    }
}
