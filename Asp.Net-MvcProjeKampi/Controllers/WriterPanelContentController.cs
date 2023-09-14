using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent

        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {

            p = (String)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();//FirstOrDefault()=Sadece 1 değer taşımak için
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);

            //Böylece sisteme kiminle otantike olduysam onun bilgilerini taşıyacak
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (String)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()  //Yapılcakların Listesi
        {
            return View();
        }

    }
}