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
    public class DraftManager : IDraftService
    {

        IDraftDal _drafDal;

        public DraftManager(IDraftDal drafDal)
        {
            _drafDal = drafDal;
        }

        public void Add(Message message,string senderMail)
        {
            var draft = new Draft();
            draft.DraftDate = DateTime.Now;
            draft.DraftValue = message.MessageContent;
            draft.ReceiverMail = message.ReceiverMail;
            draft.Subject = message.Subject;
            draft.SenderMail = senderMail;
            _drafDal.Add(draft);
        }

        public void Delete(Draft draft)
        {
            _drafDal.Delete(draft);
        }

        public List<Draft> GetAll()
        {
            return _drafDal.GetAll();
        }

        public List<Draft> GetByEmailAll(string senderMail)
        {
            return _drafDal.GetAll(x => x.SenderMail == senderMail);
        }

        public Draft GetById(int id)
        {
            return _drafDal.Get(x => x.Id == id);
        }

        public void Update(Draft draft)
        {
            _drafDal.Update(draft);
        }
    }
}
