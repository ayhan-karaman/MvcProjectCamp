using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
     
             

        public ActionResult MyContent()
        {
            string myAccount = (string)Session["WriterEmail"];
            var myIdInfo = writerManager.GetByEmail(myAccount);
            var myContentValues = _contentManager.GetByWriterId(myIdInfo.Id);

            return View(myContentValues);
        }
        [HttpGet]
        public ActionResult NewContent(int id)
        {
            ViewBag.id = id;
            return View();
        }

         [HttpPost]
        public ActionResult NewContent(Content content)
        {
            content.ContentDate =DateTime.Now;
            content.WriterId = (int)Session["Id"];
            content.ContentStatus = true;

            _contentManager.Add(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }

    }
}