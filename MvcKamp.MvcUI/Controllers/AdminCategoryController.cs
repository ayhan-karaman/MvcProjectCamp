using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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


        // Delete post
       
        public ActionResult Delete(int id)
        {
            var categoryValue = _category.GetCategoryId(id);
            _category.Delete(categoryValue);

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
            return RedirectToAction("Index");
        }

    }
}