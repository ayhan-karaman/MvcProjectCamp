using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using System;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    [AllowAnonymous]
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetAllContent()
        {
              var  values = _contentManager.GetAll();
                return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentByHeadingIdValues = _contentManager.GetByHeadingId(id);

            foreach (var item in contentByHeadingIdValues)
            {
                ViewBag.dd += item.ContentDate.ToString();
            }


            return View(contentByHeadingIdValues);
        }


          [HttpGet]
          public ActionResult NewContentAdd()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewContentAdd(Content content)
        {
            content.ContentDate = DateTime.Now;
            _contentManager.Add(content);
            return RedirectToAction("ContentByHeading");
        }

    }
}