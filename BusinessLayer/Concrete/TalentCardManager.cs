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
    public class TalentCardManager : ITalentCardService
    {
        ITalentCardDal _talentCardDal;

        public TalentCardManager(ITalentCardDal talentCardDal)
        {
            _talentCardDal = talentCardDal;
        }

        public void Add(TalentCard talentCard)
        {
            _talentCardDal.Add(talentCard);
        }

        public void Delete(TalentCard talentCard)
        {
            _talentCardDal.Delete(talentCard);
        }

        public List<TalentCard> GetAll()
        {
          return  _talentCardDal.GetAll();
        }

        public TalentCard GetById(int id)
        {
            return _talentCardDal.Get(x=>x.Id == id);
        }

        public void Update(TalentCard talentCard)
        {
            _talentCardDal.Update(talentCard);
        }
    }
}
