﻿using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories.EntityFramework
{
   public class EfRoleDal:GenericRepository<Role>, IRoleDal
    {
    }
}
