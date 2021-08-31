using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class MessageController : Controller
    {

        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messageValue = _messageManager.GetAllInbox();
            return View(messageValue);
        }

        public ActionResult GetInboxMessageDetaiLs(int id)
        {
            var messageDetailValue = _messageManager.GetById(id);
           
            return View(messageDetailValue);
        }
      

        // Mesaj gönderme metotları
        public ActionResult Sendbox()
        {
            var messageValue = _messageManager.GetAllSendbox();
           
            return View(messageValue);
        }


        public ActionResult GetSendboxMessageDetaiLs(int id)
        {
            var messageDetailValue = _messageManager.GetById(id);
            return View(messageDetailValue);
        }




        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult NewMessage(Message message)
        {
         
            ValidationResult validationResult = messageValidator.Validate(message);
            if (validationResult.IsValid)
            {
                message.MessageDate = DateTime.Now;
                _messageManager.Add(message);
                return RedirectToAction("Inbox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}