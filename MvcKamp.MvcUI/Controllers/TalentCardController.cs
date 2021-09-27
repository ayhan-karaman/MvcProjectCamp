using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.IO;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
 
    public class TalentCardController : Controller
    {
        TalentCardManager cardManager = new TalentCardManager(new EfTalentCardDal());
        MySkillManager skillManager = new MySkillManager(new EfMySkillDal());

        // GET: TalentCard
        public ActionResult Index()
        {
            var cardValues = cardManager.GetAll();
            return View(cardValues);
        }

        [HttpGet]
        public ActionResult NewTalentCard()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewTalentCard(TalentCard talentCard)
        {

            if (Request.Files.Count > 0)
            {
                ImageUpload(talentCard, "~/Images/TalentProfileImg/");
                cardManager.Add(talentCard);
                return RedirectToAction("Index");
            }
          
            cardManager.Add(talentCard);
            return RedirectToAction("Index");

        }


        private void ImageUpload(TalentCard file, string imagePath)
        {
            string extension = Path.GetExtension(Request.Files[0].FileName);
            string fileName = Guid.NewGuid().ToString(format: "D") + extension;
            string path = imagePath + fileName;
            Request.Files[0].SaveAs(Server.MapPath(path));
            file.ProfileImage = path.Substring(1, path.Length - 1);
        }


    }
}