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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetByHeadingId(int id)
        {
            return _contentDal.GetAll(c => c.HeadingId == id);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(c => c.Id == id);
        }

        public List<Content> GetByWriterId(int id)
        {
            return _contentDal.GetAll(c => c.WriterId == id);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
