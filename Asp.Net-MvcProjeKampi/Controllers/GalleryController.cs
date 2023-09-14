using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery

        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var imagefiles = ifm.GetList();
            return View(imagefiles);
        }
    }
}