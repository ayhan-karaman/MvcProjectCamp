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
            TimeSpan result = ContentDateTimeDifference(contentByHeadingIdValues);

            ViewBag.ContentDateDifference = result.TotalDays.ToString();

            return View(contentByHeadingIdValues);
        }







        private static TimeSpan ContentDateTimeDifference(List<Content> contentByHeadingIdValues)
        {
            string contentDate = "";

            foreach (var item in contentByHeadingIdValues)
            {
                contentDate = item.ContentDate.ToString("dd-MM-yyyy");
            }
            DateTime bDate = Convert.ToDateTime(contentDate);
            DateTime kDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            TimeSpan result = kDate - bDate;
            return result;
        }
    }
}