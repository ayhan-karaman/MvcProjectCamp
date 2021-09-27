using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager _category = new CategoryManager(new EfCategoryDal());

       
        public ActionResult Index()
        {
            var categoriesValues = _category.GetCategoriesList();
            return View(categoriesValues);
          
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validateCategory = new CategoryValidator();
            ValidationResult validationResult = validateCategory.Validate(category);
            if (validationResult.IsValid)
            {
                _category.Add(category);
                ToastrService.AddToQueue(new Toastr("Kategori Eklendi", "Ekleme İşlemi", ToastrType.Success));
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ToastrService.AddToQueue(new Toastr(item.ErrorMessage, "", ToastrType.Success));
                }
            }

            return View();
        }


        // Delete post
       
        public ActionResult Delete(int id)
        {
            var categoryValue = _category.GetCategoryId(id);
            _ = categoryValue.CategoryStatus == false ? categoryValue.CategoryStatus = true 
                : categoryValue.CategoryStatus = false;
            _category.Update(categoryValue);
            ToastrService.AddToQueue(new Toastr("Kategori Durumu Değiştirildi..", "Durum Güncelleme", ToastrType.Info));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = _category.GetCategoryId(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
             
            _category.Update(category);
            ToastrService.AddToQueue(new Toastr("Kategori Güncellendi", "Güncelleme İşlemi"));
            return RedirectToAction("Index");
        }

    }
}