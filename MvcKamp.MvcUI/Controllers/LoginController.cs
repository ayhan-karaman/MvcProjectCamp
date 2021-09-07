using BusinessLayer.Concrete;
using BusinessLayer.Utilities.HashHelper;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKamp.MvcUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager context = new AdminManager(new EfAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var result =   Hashing.CreateHashing(admin.AdminPassword);
            admin.AdminPassword = result;
            var adminUserInfo = context.GetByAdminUserName(admin.AdminUserName, admin.AdminPassword);
            if (adminUserInfo != null )
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName,false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                ViewBag.UserName = adminUserInfo.AdminUserName;
                ToastrService.AddToQueue(new Toastr("Giriş Yapıldı", "Başarılı", ToastrType.Success));
                return RedirectToAction("Index", "AdminCategory");
              
            }
                ToastrService.AddToQueue(new Toastr("Kullanıcı Adı veya Şifre Yanlış", "Kullanıcı Hatası",ToastrType.Error));
                return RedirectToAction("Index");
        }

       

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            ToastrService.AddToQueue(new Toastr("Sistemden Çıkış Yapıldı", "Bilgilendirme", ToastrType.Info));
            return RedirectToAction("Index", "Login");
        }
    }
}