using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Asp.Net_MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            //FirstOrDefault(); geriye sadece bir tane değer döndüreceğimiz için bu kodu kullanıyoruz.Sisteme sadece bir tane
            //admin üzerinden giriş yapılacağından dolayı bu kod.
            var adminuser = c.Admins.FirstOrDefault(x=>x.AdminUserName==p.AdminUserName && x.AdminPassword==p.AdminPassword);
            if (adminuser != null)
            {
                FormsAuthentication.SetAuthCookie(adminuser.AdminUserName, false);//Sisteme giriş yapacak kişinin bilgilerini hazırlıyoruz
                Session["AdminUserName"] = adminuser.AdminUserName;              //AdminUserName=Sisteme giriş yapan kişinin bilgisini bu koddan alıyoruz
                //Sisteme otantike olan kullanıcın bilgisi bu kod ile gelecek     //false=Kalıcı cookie oluştursun mu hayır oluşturmasın demek
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //var writeruser = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            var writeruserinfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
            
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);//Sisteme giriş yapacak kişinin bilgilerini hazırlıyoruz
                Session["WriterMail"] = writeruserinfo.WriterMail;              //AdminUserName=Sisteme giriş yapan kişinin bilgisini bu koddan alıyoruz
                //Sisteme otantike olan kullanıcın bilgisi bu kod ile gelecek     //false=Kalıcı cookie oluştursun mu hayır oluşturmasın demek
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else 
            {
                return RedirectToAction("WriterLogin");
            }

            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}