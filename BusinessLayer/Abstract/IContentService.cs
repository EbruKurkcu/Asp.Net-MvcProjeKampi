using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();  //Listeleme
        List<Content> GetListByWriter(int id);  //Yazara Göre Listeleme

        List<Content> GetListByHeadingID(int id);   //Şartlı Listeleme

        void ContentAdd(Content content);  //Ekleme

        Content GetByID(int id);  //İlgili değeri getirme yani Find İşlemi Bulma

        void ContentDelete(Content content); //SİLME

        void ContentUpdate(Content content);  //GÜNCELLEME

    }
}
