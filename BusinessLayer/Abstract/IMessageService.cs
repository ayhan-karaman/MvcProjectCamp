using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {
        List<Message> GetAllInbox(string email);
        List<Message> GetAllSendbox(string email);
        Message GetById(int id);
        List<Message> GetAllReadMessage(string mail);
        List<Message> GetAllNoReadMessage(string mail);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);

    }
}
