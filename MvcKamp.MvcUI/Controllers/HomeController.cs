using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        MessageManager messageManager = new MessageManager (new EfMessageDal());

     
        public ActionResult HomePage()
        {
          
           var imageValues = imageFileManager.GetAll();

            return View(imageValues);
        }

        [HttpPost]
        public ActionResult HomePage(Message message)
        {
            message.MessageDate = DateTime.Now;
            message.ReceiverMail = "ayhan@gmail.com";

            messageManager.Add(message);
            return RedirectToAction("HomePage", "Home");
        }

    }
}