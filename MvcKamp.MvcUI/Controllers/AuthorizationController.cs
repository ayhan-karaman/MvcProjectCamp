using BusinessLayer.Concrete;
using BusinessLayer.Utilities.HashHelper;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());

        public ActionResult Index()
        {
            var adminValues = adminManager.GetAll();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> selectRoles = SelectListRoles();
            ViewBag.SelectRoles = selectRoles;

            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            var result =  Hashing.HashString(admin.AdminPassword);
            admin.AdminPassword = result;
            adminManager.Add(admin);
            return RedirectToAction("Index");
        }





        public ActionResult AdminStatusEdit(Admin admin)
        {
            adminManager.Delete(admin);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult EditAdmin(int id)
        {

            var adminValue = adminManager.GetById(id);
            List<SelectListItem> selectRoles = SelectListRoles();
            ViewBag.SelectRoles = selectRoles;
            
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {

            adminManager.Update(admin);
            ToastrService.AddToQueue(new Toastr("Yetkilendirme Değiştirildi.", "Güncelleme İşlemi"));
            return RedirectToAction("Index");
        }




        private List<SelectListItem> SelectListRoles()
        {
            return (from r in roleManager.GetAll()
                    select new SelectListItem
                    {
                        Text = r.Name,
                        Value = r.Id.ToString()
                    }).ToList();
        }
    }
}