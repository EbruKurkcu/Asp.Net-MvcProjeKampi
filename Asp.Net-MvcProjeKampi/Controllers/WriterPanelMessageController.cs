using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager cm = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();
        Context c = new Context();

        public ActionResult Inbox()  //Inbox = Gelen Mesajlar Listelenecek
        {
           string p = (String)Session["WriterMail"];
            var messageList = cm.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult Sendbox()  //Sendbox = Gönderilen Mesajlar Listelenecek
        {
            string p = (String)Session["WriterMail"];
            var messageList = cm.GetListSendbox(p);
            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (String)Session["WriterMail"];
            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid)
            {
                p.SenderMail =sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                cm.MessageAdd(p);
                return RedirectToAction("Sendbox");
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