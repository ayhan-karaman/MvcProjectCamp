using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetAllCategoryId(int id);
        List<Heading> GetByWriter(int id);

        Heading GetHeadingId(int id);
        void Add(Heading heading);
        void Update(Heading heading);
        void Delete(Heading heading);

    }
}
