using BusinessLayer.Concrete;
using BusinessLayer.Utilities.HashHelper;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _category = new CategoryManager(new EfCategoryDal());
        WriterValidator validateWriter = new WriterValidator();
        WriterManager writerManager = new WriterManager(new EfWriterDal());


        [HttpGet]
        public ActionResult WriterProfile()
        {
            int id = (int)Session["Id"];
           var writerValue = writerManager.GetById(id);

            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
           

            ValidationResult validationResult = validateWriter.Validate(writer);
            if (Request.Files.Count > 0)
            {
                ImageUpload(writer, "~/Images/GalleryImages/");
            }
            if (validationResult.IsValid)
            {

                writerManager.Update(writer);
                return RedirectToAction("MyHeading", "WriterPanel");

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

        public ActionResult MyHeading( )
        {
            int myAccount = (int)Session["Id"];
            var values = _headingManager.GetByWriter(myAccount);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> selectCategories = SelectListCategories();
            ViewBag.CategoryList = selectCategories;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {

           int myAccount = (int)Session["Id"];
            heading.HeadingDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            heading.HeadingStatus = true;
            heading.WriterId = myAccount;
            _headingManager.Add(heading);
            ToastrService.AddToQueue(new Toastr("Yeni Başlık Eklendi", "", ToastrType.Success));
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> selectCategories = SelectListCategories();
        
            ViewBag.CategoryList = selectCategories;
            var headingValue = _headingManager.GetHeadingId(id);

            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {

            _headingManager.Update(heading);
            ToastrService.AddToQueue(new Toastr("Başlık Güncellendi..", "", ToastrType.Success));
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = _headingManager.GetHeadingId(id);
            _ = headingValue.HeadingStatus == false ? headingValue.HeadingStatus = true
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
            return RedirectToAction("MyHeading");
        }

        public ActionResult HeadingAll(int? page )
        {
            var headingsValues = _headingManager.GetAll().ToPagedList(page?? 1,4);
            return View(headingsValues);
        }


        

      


        private List<SelectListItem> SelectListCategories()
        {
            return (from c in _category.GetCategoriesList()
                    select new SelectListItem
                    {
                        Text = c.CategoryName,
                        Value = c.Id.ToString()
                    }).ToList();
        }


        private void ImageUpload(Writer file, string imagePath)
        {
            string extension = Path.GetExtension(Request.Files[0].FileName);
            string fileName = Guid.NewGuid().ToString(format: "D") + extension;
            string path = imagePath + fileName;
            Request.Files[0].SaveAs(Server.MapPath(path));
            file.WriterImage = path.Substring(1, path.Length - 1);
        }
    }
}