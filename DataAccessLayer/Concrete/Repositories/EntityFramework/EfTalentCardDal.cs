using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.Repositories.EntityFramework
{
  public  class EfTalentCardDal:GenericRepository<TalentCard>,ITalentCardDal
    {
    }
}
