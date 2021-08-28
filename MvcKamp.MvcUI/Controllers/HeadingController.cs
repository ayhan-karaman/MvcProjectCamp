using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using MvcKamp.MvcUI.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _category = new CategoryManager(new EfCategoryDal());
        WriterManager _writer= new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = _headingManager.GetAll();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> selectCategories = (from c in _category.GetCategoriesList()
                                                     select new SelectListItem
                                                     {
                                                         Text = c.CategoryName,
                                                         Value = c.Id.ToString()
                                                     }
                                                     ).ToList();
            List<SelectListItem> selectWriters = (from w in _writer.GetAll()
                                                     select new SelectListItem
                                                     {
                                                         Text = w.WriterName + " "+ w.WriterSurname,
                                                         Value = w.Id.ToString()
                                                     }
                                                    ).ToList();
            ViewBag.CategoryList = selectCategories;
            ViewBag.WriterList = selectWriters;
            return View();

        }

        [HttpPost]
        public  ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _headingManager.Add(heading);
            return RedirectToAction("Index");
        }
    }
}