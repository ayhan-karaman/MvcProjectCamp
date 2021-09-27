using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetContains(string val);
        List<Content> GetByHeadingId(int id);
        List<Content> GetByWriterId(int id);
        Content GetById(int id);
        void Add(Content content);
        void Update(Content content);
        void Delete(Content content);
    }
}
