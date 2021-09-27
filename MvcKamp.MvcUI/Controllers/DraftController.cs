using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
    public class DraftController : Controller
    {
        // GET: Draft
        DraftManager draftManager = new DraftManager(new EfDraftDal());

        public ActionResult WriterDrafts()
        {
            string senderMail = (string)Session["WriterEmail"];
            var draftValue = draftManager.GetByEmailAll(senderMail);
            return View(draftValue);
        }


        public ActionResult GetDraftDetails(int id)
        {
            var draftDetailValue = draftManager.GetById(id);

            return View(draftDetailValue);
        }


    }
}