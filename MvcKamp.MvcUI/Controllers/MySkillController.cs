using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcKamp.MvcUI.Controllers
{
   
    public class MySkillController : Controller
    {
        TalentCardManager cardManager = new TalentCardManager(new EfTalentCardDal());
        MySkillManager skillManager = new MySkillManager(new EfMySkillDal());
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            var skillValues = skillManager.GetAll();
            return View(skillValues);
        }



        [HttpGet]
        public ActionResult AddSkill(int  id)
        {
            List<SelectListItem> selectCards = SelectListCards();
            ViewBag.Id = id;
            ViewBag.Cards = selectCards;
            return View();
        }


        [HttpPost]
        public ActionResult AddSkill(MySkill mySkill)
        {


            skillManager.Add(mySkill);
            return RedirectToAction("Index","TalentCard");
        }



        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var skillValue = skillManager.GetById(id);

            return View(skillValue);
        }


        [HttpPost]
        public ActionResult UpdateSkill(MySkill mySkill)
        {
            skillManager.Update(mySkill);
            return RedirectToAction("Index", "TalentCard");
        }

        public ActionResult SkillDelete(MySkill mySkill)
        {
            skillManager.Delete(mySkill);
            return RedirectToAction("Index","TalentCard");
        }

        private List<SelectListItem> SelectListCards()
        {
            return (from c in cardManager.GetAll()
                    select new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    }).ToList();
        }
    }
}