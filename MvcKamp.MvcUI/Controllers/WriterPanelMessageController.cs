using BusinessLayer.Concrete;
using BusinessLayer.Utilities.MultipleButtonAttirbutes;
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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        DraftManager draftManager = new DraftManager(new EfDraftDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var userEmail = (string)Session["WriterEmail"];

            var messageValue = _messageManager.GetAllInbox(userEmail);
            return View(messageValue);
        }


        public ActionResult GetInboxMessageDetaiLs(int id)
        {
            var messageDetailValue = _messageManager.GetById(id);

            return View(messageDetailValue);
        }

        public ActionResult Sendbox()
        {
            var userEmail =(string)Session["WriterEmail"];
            var messageValue = _messageManager.GetAllSendbox(userEmail);

            return View(messageValue);
        }
        public ActionResult GetSendboxMessageDetaiLs(int id)
        {
            var messageDetailValue = _messageManager.GetById(id);
            return View(messageDetailValue);
        }
        public PartialViewResult MessageListMenu()
        {
            var userMail = (string)Session["WriterEmail"];

            ViewBag.InboxMessages = _messageManager.GetAllInbox(userMail).Count();
            ViewBag.SenboxMessages = _messageManager.GetAllSendbox(userMail).Count();
            ViewBag.MessageRead = _messageManager.GetAllReadMessage(userMail).Count();
            ViewBag.MessageNotRead = _messageManager.GetAllNoReadMessage(userMail).Count();
            ViewBag.DraftMessage = draftManager.GetByEmailAll(userMail).Count();
            return PartialView();
        }

        //@Html.Action("MessageListMenu", "WriterPanelMessage")


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [MultipleButton(Argument ="SendMessage", Name ="action")]
        public ActionResult NewMessage(Message message)
        {

            ValidationResult validationResult = messageValidator.Validate(message);
            if (validationResult.IsValid)
            {
                var userMail = (string)Session["WriterEmail"];
                message.SenderMail = userMail;
                message.MessageDate = DateTime.Now;
               
                _messageManager.Add(message);
              
                return RedirectToAction("Inbox", "WriterPanelMessage");
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
            string user = (string)Session["WriterEmail"];
            mail = user;
            var messages = _messageManager.GetAllReadMessage(mail);
            return View(messages);
        }

        public ActionResult NoReadMessage(string mail)
        {
            string user = (string)Session["WriterEmail"];
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

        [HttpPost]
        [MultipleButton(Argument = "SaveDraft", Name = "action")]
        public ActionResult DraftSave(Message message)
        {
            string senderMail = (string)Session["WriterEmail"];
            draftManager.Add(message, senderMail);
            return RedirectToAction("NewMessage", "WriterPanelMessage");
        }

       
        public ActionResult DeleteStatusUpdate(Message message)
        {
            
            _messageManager.Update(message);
            return RedirectToAction("NewMessage", "WriterPanelMessage");
        }

    }
}