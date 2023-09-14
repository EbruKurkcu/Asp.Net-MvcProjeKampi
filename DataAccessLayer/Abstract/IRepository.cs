using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
                                     //BURADA METOTLARIMIZI TANIMLADIK. BUNLARIN İÇİNİ GENERİCREPOSİTORİES'TE DOLDURDUK
    public interface IRepository<T>  //HANGİ SINIFI KULLANMAK İSTERSEK ARTIK KULLANABİLİRİZ. WRİTER,ABAOUT,CATEGORY...

                                      //BÜTÜN İNTERFACELERİMİZ İÇİN AYRI AYRI METOTLAR TANIMLAMAMIZA GEREK KALMIYOR.
                                      //<T> DEĞİŞKENİ SINIFLARIMIZA KARŞILIK GELİYOR.
    {
        List<T> List();   //LİSTELEME

        void Insert(T p);    //EKLEMEK

        T Get(Expression<Func<T, bool>> filter);  //BULMAK
        //Tek değer listeleme Bulma Find
        //Sadece bir tane değer listelemek için kullanılır.
        //SingleOrDefault(filter) Sadece tek değer
        //T değeri bir sınıfı temsil ediyor. Category,Writer vb.
        //Örneğin ID'si 5 olan yazarı getir dediğimde Bu Find kullanılacak

        void Update(T p);  //GÜNCELLEME

        void Delete(T p);   //SİLME

        List<T> List(Expression<Func<T, bool>> filter);  // ŞARTLI LİSTELEME
        //Birden fazla değeri listelemek için kullanılır
        //Örneğin ismi Aycan olan yazarları getir dediğimde bu find komutu kullanılacak

    }
}
