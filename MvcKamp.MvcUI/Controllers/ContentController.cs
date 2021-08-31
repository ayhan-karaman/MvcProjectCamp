using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
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







    }
}