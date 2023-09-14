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
        List<Message> GetListInbox(string p);  //Gelen Mesajları Listeleme
        List<Message> GetListSendbox(string p);  //Gönderilen Mesajları Listeleme

        void MessageAdd(Message message);  //Ekleme

        Message GetByID(int id);  //İlgili değeri getirme yani Find İşlemi Bulma

        void MessageDelete(Message message); //SİLME

        void MessageUpdate(Message message);  //GÜNCELLEME

    }
}
