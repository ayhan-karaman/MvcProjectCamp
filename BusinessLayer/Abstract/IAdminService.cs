using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {
        List<Admin> GetAll();
        Admin GetById(int id);
        Admin GetByAdminUserName(string userName,string userPassword);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
