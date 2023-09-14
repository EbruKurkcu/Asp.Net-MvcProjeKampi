using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{

    //Burada ilgili metodun ismini tanımlıyoruz. Ardından ilgili metodun içini CategoryManager da doldur.
    public interface ICategoryService 
    {
        List<Category> GetList();  //Listeleme

        void CategoryAdd(Category category);  //Ekleme

        Category GetByID(int id);  //İlgili değeri getirme yani Find İşlemi Bulma

        void CategoryDelete(Category category); //SİLME

        void CategoryUpdate(Category category);  //GÜNCELLEME



    }
}
