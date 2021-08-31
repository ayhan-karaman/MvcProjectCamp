using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = _contactManager.GetAll(); 
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = _contactManager.GetById(id);
            return View(contactValue);
        }

        public PartialViewResult ContanctMenuPartial()
        {
            ViewBag.ContactMessages = _contactManager.GetAll().Count();
            ViewBag.InboxMessages = _messageManager.GetAllInbox().Count();
            ViewBag.SenboxMessages = _messageManager.GetAllSendbox().Count();
            return PartialView();
        }


      
    }
}