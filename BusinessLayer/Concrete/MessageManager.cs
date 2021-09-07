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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

       

        public List<Message> GetAllInbox(string email)
        {
            return _messageDal.GetAll(m => m.ReceiverMail == email);
        }

        public List<Message> GetAllNoReadMessage(string mail)
        {
            return _messageDal.GetAll(x => x.ReceiverMail == mail).Where(y => y.ReadMessage == false).ToList();
        }

        public List<Message> GetAllReadMessage(string mail)
        {
            return _messageDal.GetAll(x => x.ReceiverMail == mail).Where(y => y.ReadMessage == true).ToList();
        }

        public List<Message> GetAllSendbox(string email)
        {
            return _messageDal.GetAll(m => m.SenderMail ==  email);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(m => m.Id == id);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
