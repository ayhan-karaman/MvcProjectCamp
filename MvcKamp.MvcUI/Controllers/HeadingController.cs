using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using System;
using System.Collections.Generic;

using System.Web.Mvc;
using System.Linq;

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


        public ActionResult HeadingReport()
        {
            var headingValues = _headingManager.GetAll();
            return View(headingValues);
        }

        public ActionResult GetByCategoryId(int id)
        {
            var headingValues = _headingManager.GetAllCategoryId(id);
            return PartialView(headingValues);
        }


        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> selectCategories = SelectListCategories();
            List<SelectListItem> selectWriters = SelectListWrites();
            ViewBag.CategoryList = selectCategories;
            ViewBag.WriterList = selectWriters;
            return View();

        }



        [HttpPost]
        public  ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _headingManager.Add(heading);
            ToastrService.AddToQueue(new Toastr("Yeni Başlık Eklendi", "", ToastrType.Success));
            return RedirectToAction("Index");
        }

      
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> selectCategories = SelectListCategories();
            List<SelectListItem> selectWriters = SelectListWrites();
            ViewBag.CategoryList = selectCategories;
            ViewBag.WriterList = selectWriters;

            var headingValue = _headingManager.GetHeadingId(id);
        
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
          
            _headingManager.Update(heading);
            ToastrService.AddToQueue(new Toastr("Başlık Güncellendi..", "", ToastrType.Success));
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = _headingManager.GetHeadingId(id);
            _=headingValue.HeadingStatus == false ? headingValue.HeadingStatus = true 
                : headingValue.HeadingStatus = false;
            if (headingValue.HeadingStatus == false)
            {
                ToastrService.AddToQueue(new Toastr("Başlık Pasif Edildi", "", ToastrType.Warning));
            }
            else
            {
                ToastrService.AddToQueue(new Toastr("Başlık Aktif Edildi", "", ToastrType.Success));
            }
            _headingManager.Delete(headingValue);
            return RedirectToAction("Index");
        }













        //pravite methods
        private List<SelectListItem> SelectListCategories()
        {
            return (from c in _category.GetCategoriesList()
                    select new SelectListItem
                    {
                        Text = c.CategoryName,
                        Value = c.Id.ToString()
                    }).ToList();
        }


        private List<SelectListItem> SelectListWrites()
        {
            return (from w in _writer.GetAll()
                    select new SelectListItem
                    {
                        Text = w.WriterName + " " + w.WriterSurName,
                        Value = w.Id.ToString()
                    } ).ToList();
        }
    }
}