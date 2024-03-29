﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.IO;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager fileManager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = fileManager.GetAll();
            return View(files);
        }

        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ImageFile file)
        {
            if (Request.Files.Count > 0)
            {
                ImageUpload(file, "~/Images/GalleryImages/");
                fileManager.Add(file);
                return RedirectToAction("Index");
            }

            return View();
        }




        private void ImageUpload(ImageFile file, string imagePath)
        {
            string extension = Path.GetExtension(Request.Files[0].FileName);
            string fileName = Guid.NewGuid().ToString(format: "D") + extension;
            string path = imagePath + fileName;
            Request.Files[0].SaveAs(Server.MapPath(path));
            file.ImagePath = path.Substring(1, path.Length - 1);
        }




        public PartialViewResult ImagePartial()
        {
            return PartialView();
        }

        public ActionResult Delete(int id)
        {
            var imageValue = fileManager.GetById(id);
            var fullPath = Server.MapPath("~"+imageValue.ImagePath);

            if (!System.IO.File.Exists(fullPath))
            {
                ToastrService.AddToQueue(new Toastr("Dosya Bulunamadı ", "Silme İşlemi Başrısız"));
                return RedirectToAction("Index");
            }
            else
            {
                System.IO.File.Delete(fullPath);
                fileManager.Delete(imageValue);
                ToastrService.AddToQueue(new Toastr( imageValue.ImageName+" İsimli Fotoğraf Silindi", "Silme İşlemi Başrısız"));
                return RedirectToAction("Index");
            }
        }

    }
}