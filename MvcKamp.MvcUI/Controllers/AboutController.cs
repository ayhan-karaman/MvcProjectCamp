using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = _aboutManager.GetAll();
        // ToastrService.AddToQueue(new Toastr("Hakkımızda Sayfası Yükledi", "", ToastrType.Success));
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About  about)
        {
            _aboutManager.Add(about); 
             ToastrService.AddToQueue(new Toastr("Hakkımızda Bilgisi", "Ekleme İşlemi", ToastrType.Success));
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }


        //Delete Action
        public ActionResult Delete(int id)
        {
            var aboutValue = _aboutManager.GetById(id);
            _ = aboutValue.AboutStatus == false ? aboutValue.AboutStatus = true
                : aboutValue.AboutStatus = false;
            if (aboutValue.AboutStatus == false)
                ToastrService.AddToQueue(new Toastr("Hakkımızda Metni Pasif Edildi", "", ToastrType.Warning));
            else ToastrService.AddToQueue(new Toastr("Hakkımızda Metni Aktif Edildi", "", ToastrType.Success));

            _aboutManager.Update(aboutValue);
            return RedirectToAction("Index");


        }
    }
}