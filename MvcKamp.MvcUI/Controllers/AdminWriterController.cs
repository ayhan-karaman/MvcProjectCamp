using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.IO;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class AdminWriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        WriterValidator validateWriter = new WriterValidator();

        public ActionResult Index()
        {
            var writerValues = _writerManager.GetAll();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator validateWriter = new WriterValidator();
            ValidationResult validationResult = validateWriter.Validate(writer);
            if (Request.Files.Count > 0)
            {
                ImageUpload(writer, "~/Images/WriterAvatars/");
            }
            if (validationResult.IsValid)
            {

                    writer.WriterImage = "/Images/WriterAvatars/defaultavatar.png";
                    _writerManager.Add(writer);
                    return RedirectToAction("Index");
                
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

        private void ImageUpload(Writer file, string imagePath)
        {
            string extension = Path.GetExtension(Request.Files[0].FileName);
            string fileName = Guid.NewGuid().ToString(format: "D") + extension;
            string path = imagePath + fileName;
            Request.Files[0].SaveAs(Server.MapPath(path));
            file.WriterImage = path.Substring(1, path.Length - 1);
        }



        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = _writerManager.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {

           
            ValidationResult validationResult = validateWriter.Validate(writer);
            var fullPath = Server.MapPath("~" + writer.WriterImage);
            if (Request.Files.Count > 0)
            {
                if (System.IO.File.Exists(fullPath) && fullPath !=Server.MapPath("~/Images/WriterAvatars/defaultavatar.png"))
                {
                    System.IO.File.Delete(fullPath);
                }
                
                ImageUpload(writer, "~/Images/WriterAvatars/");
            }
                if (validationResult.IsValid)
            {

                    _writerManager.Update(writer);
                    return RedirectToAction("Index");
                          
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
    }
}