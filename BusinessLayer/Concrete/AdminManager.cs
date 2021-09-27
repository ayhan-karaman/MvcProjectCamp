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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
             admin.AdminStatus = true;
            admin.RoleId = 5;
            _adminDal.Add(admin);
        }

        public void Delete(Admin admin)
        {
            var result = _adminDal.Get(x => x.Id == admin.Id);
            _ = result.AdminStatus == false ? result.AdminStatus = true : result.AdminStatus = false;
            _adminDal.Update(result);
        }

        public List<Admin> GetAll()
        {
         return   _adminDal.GetAll();
        }

        public Admin GetByAdminUserName(string userName, string userPassword)
        {
            return _adminDal.Get(a => a.AdminUserName == userName && a.AdminPassword == userPassword);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(a=>a.Id == id);
        }

        public void Update(Admin admin)
        {
          
            _adminDal.Update(admin);
        }
    }
}
