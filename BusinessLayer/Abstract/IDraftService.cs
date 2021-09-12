using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IDraftService
    {
        List<Draft> GetAll();
        Draft GetById(int id);
        List<Draft> GetByEmailAll(string senderMail);
        void Add(Message message, string senderMail);
        void Delete(Draft draft);
        void Update(Draft draft);
    }
}
