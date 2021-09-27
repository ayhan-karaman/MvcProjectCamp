
using DataAccessLayer.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class StatisticsController : Controller
    {


        Context context = new Context();
        

        public ActionResult Index()
        {

            ViewBag.CategoryCount = context.Categories.Count().ToString();
            ViewBag.Heading = context.Headings.Count(h => h.Category.CategoryName == "Yazılım");
            ViewBag.Writer = context.Writers.Count(w => w.WriterName.Contains("a"));
            HeadingMaxCategories();
            ViewBag.StatusDiffrerent = context.Categories.Count(s => s.CategoryStatus == true)
                - context.Categories.Count(s => s.CategoryStatus == false);
            ViewBag.ContentCount = context.Contents.Count().ToString();


            return View();
        }

        private void HeadingMaxCategories()
        {
            ViewBag.HeadingMax = context.Categories.Where(x => x.Id ==
            context.Headings.GroupBy(a => a.CategoryId).OrderByDescending(a => a.Count())
            .Select(a => a.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
        }


    }
}