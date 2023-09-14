using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace Asp.Net_MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        Context c = new Context();


        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (String)Session["WriterMail"];
            ViewBag.d = p;
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writervalue = wm.GetByID(id);
            ViewBag.a = id;
            return View(writervalue);
        }


        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {

            ValidationResult result = writervalidator.Validate(p);

            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
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
            public ActionResult MyHeading(string p)
        {
            // id = 4;

            p = (String)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valuecategori = (from x in cm.GetList()      //DROPDOWNLİST
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valuecategori;
            return View();
        }


        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (String)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");

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
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)   //Silme
        {
            var headingvalues = hm.GetByID(id);
            headingvalues.HeadingStatus = false;
            hm.HeadingDelete(headingvalues);
            return RedirectToAction("MyHeading");
        }


        public ActionResult AllHeading(int sayfa=1)  //Sayfalama işleminin kaçtan başlayacağını gösteriyor bu atama işlemi
        {
            var headings = hm.GetList().ToPagedList(sayfa, 4); //1 den başlasın her sayfada 4 tane kayıt olsun
            return View(headings);
        }
    }


}