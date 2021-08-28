using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace MvcKamp.MvcUI.EntityFramework
{
    public class EfHeadingDal: GenericRepository<Heading>,IHeadingDal
    {

    }
}