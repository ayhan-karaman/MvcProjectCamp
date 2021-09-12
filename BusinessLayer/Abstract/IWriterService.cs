using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        Writer GetById(int id);
        Writer GetByEmailAndPassword(string email, string password);
        Writer GetByEmail(string email);
        void Add(Writer writer);
        void Delete(Writer writer);
        void Update( Writer writer);
    }
}
