using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService   //İMPLEMENT EDİLDİ.
    {

        EfMessageDal _messageDal;

        public MessageManager(EfMessageDal messageDal)  //CONSTROCTUR OLUŞTURULDU.
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);//ReceiverMail= Alıcı mail demek
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);//SenderMail= Gönderici mail demek
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);  //Mesaj ekleme
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
