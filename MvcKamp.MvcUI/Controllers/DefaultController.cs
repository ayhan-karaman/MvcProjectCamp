using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
      
        public PartialViewResult Index(int id=0)
        {
            var contentList = contentManager.GetByHeadingId(id);
          
            return PartialView(contentList);
        }

        public ActionResult Headings()
        {
            var headingValues = headingManager.GetAll();
           
            return View(headingValues);
        }
    }
}