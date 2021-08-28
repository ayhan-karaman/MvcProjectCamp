using BusinessLayer.Concrete;
using BusinessLayer.DependencyResolvers.Ninject;
using BusinessLayer.ValidationRules.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcKamp.MvcUI.EntityFramework;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class CategoryController : Controller
    {

        // GET: Category
        CategoryManager _category = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllCategory()
        {
            var categoryValues = _category.GetCategoriesList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);


            if (results.IsValid)
            {
                _category.Add(category);
                return RedirectToAction("GetAllCategory");
            }
            else
            {
                foreach (var err in results.Errors)
                {
                    ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                }
            }

            return View();
        }
    }
}