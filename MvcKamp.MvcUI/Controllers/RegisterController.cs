using BusinessLayer.Concrete;
using BusinessLayer.Utilities.HashHelper;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        AdminValidator validations = new AdminValidator();
        

    
       

     

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(Admin admin)
        {
            ValidationResult validationResult = validations.Validate(admin);
            if (validationResult.IsValid)
            {
               var  hashPassword =  Hashing.CreateHashing(admin.AdminPassword);
                admin.AdminPassword = hashPassword;
                adminManager.Add(admin);
                ToastrService.AddToQueue(new Toastr("Kaydınız Oluşturuldu Giriş Yapınız", "Başarılı İşlem", ToastrType.Success));
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    ToastrService.AddToQueue(new Toastr(item.ErrorMessage,"", ToastrType.Error));
                }
            }

            return View();





        }
    }
}