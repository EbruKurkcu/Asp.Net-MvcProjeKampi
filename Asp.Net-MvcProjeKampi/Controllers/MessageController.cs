using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager cm = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        public ActionResult Inbox(string p)  //Inbox = Gelen Mesajlar Listelenecek
        {
            var messageList = cm.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult Sendbox(string p)  //Sendbox = Gönderilen Mesajlar Listelenecek
        {
            var messageList = cm.GetListSendbox(p);
            return View(messageList);
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
            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid)
            {
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