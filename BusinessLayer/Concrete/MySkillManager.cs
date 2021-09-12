using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MySkillManager : IMySkillService
    {
        IMySkillDal _mySkillDal;

        public MySkillManager(IMySkillDal mySkillDal)
        {
            _mySkillDal = mySkillDal;
        }

        public void Add(MySkill mySkill)
        {
            _mySkillDal.Add(mySkill);
        }

        public void Delete(MySkill mySkill)
        {
            _mySkillDal.Delete(mySkill);
        }

        public List<MySkill> GetAll()
        {
            return _mySkillDal.GetAll();
        }

        public MySkill GetById(int id)
        {
            return _mySkillDal.Get(x => x.Id == id);
        }

        public MySkill GetByTalentCardId(int id)
        {
            return _mySkillDal.Get(x => x.TalentCardId == id);
        }

        public void Update(MySkill mySkill)
        {
            _mySkillDal.Update(mySkill);
        }
    }
}
