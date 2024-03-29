﻿
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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }

        public List<Heading> GetAllCategoryId(int id)
        {
            return _headingDal.GetAll(h => h.CategoryId == id);
        }

        public List<Heading> GetByWriter(int id)
        {
            return _headingDal.GetAll(x => x.WriterId == id);
        }

        public Heading GetHeadingId(int id)
        {
            return _headingDal.Get(h => h.Id == id);
        }

        public void Update(Heading heading)
        {
          
            _headingDal.Update(heading);
        }
    }
}
