using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using MvcKamp.MvcUI.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (validationResult.IsValid)
            {
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