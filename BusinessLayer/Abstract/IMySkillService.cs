using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMySkillService
    {
        List<MySkill> GetAll();
        MySkill GetById(int id);
        MySkill GetByTalentCardId(int id);
        void Add(MySkill mySkill);
        void Delete(MySkill mySkill);
        void Update(MySkill mySkill);
    }
}
