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

        [Authorize]
        public ActionResult Inbox()
        {
            var userEmail = (string)Session["AdminUserName"];
            var messageValue = _messageManager.GetAllInbox(userEmail);
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
            var userEmail = (string)Session["AdminUserName"];
            var messageValue = _messageManager.GetAllSendbox(userEmail);
           
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
                var userMail = (string)Session["AdminUserName"];
                message.SenderMail = userMail;
                message.MessageDate = DateTime.Now;
                _messageManager.Add(message);
                return RedirectToAction("Sendbox");
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

        public ActionResult ReadMessage(string mail)
        {
            string user = (string)Session["AdminUserName"];
            mail = user;
            var messages = _messageManager.GetAllReadMessage(mail);
            return View(messages);
        }

        public ActionResult NoReadMessage(string mail)
        {
            string user = (string)Session["AdminUserName"];
            mail = user;
            var messages = _messageManager.GetAllNoReadMessage(mail);
            return View(messages);
        }


        public ActionResult ReadingMessage(int id)
        {
            var valueMessage = _messageManager.GetById(id);
            valueMessage.ReadMessage = true;
            _messageManager.Update(valueMessage);
            return RedirectToAction("Inbox");
        }
    }
}