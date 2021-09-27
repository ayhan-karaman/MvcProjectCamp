using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using MvcKamp.MvcUI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ByCategoryHeadingChart()
        {

            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult HeadingIndex()
        {
            return View();
        }

        public ActionResult ByHeadingContentChart()
        {
            return Json(BlogContentList(), JsonRequestBehavior.AllowGet);
        }



        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            foreach (var item in categoryManager.GetCategoriesList())
            {
                categoryClasses.Add(new CategoryClass()
                {
                    CategoryName = item.CategoryName,
                    ByCategoryHeadingCount = headingManager.GetAllCategoryId(item.Id).Count()
                }) ;
            };
       
           
            return categoryClasses;
        }




        
        public List<HeadingClass> BlogContentList()
        {
            List<HeadingClass> headingClasses = new List<HeadingClass>();
            foreach (var item in headingManager.GetAll())
            {
                headingClasses.Add(new HeadingClass()
                {
                    HeadingName = item.HeadingName,
                    ByHeadingContentCount = contentManager.GetByHeadingId(item.Id).Count()
                });
            };


            return headingClasses;
        }
    }
}