using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKamp.MvcUI.EntityFramework
{
    public class EfCategoryDal:GenericRepository<Category>, ICategoryDal
    {
    }
}