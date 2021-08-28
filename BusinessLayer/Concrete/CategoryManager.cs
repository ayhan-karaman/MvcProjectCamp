using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

    
     
        public void Add(Category category)
        {

            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetCategoriesList()
        {
            return _categoryDal.GetAll();
        }

        public Category GetCategoryId(int id)
        {
            return _categoryDal.Get(c => c.Id == id);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
