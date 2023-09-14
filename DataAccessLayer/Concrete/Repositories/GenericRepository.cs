using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{

    //IREPOSİTORİESTE TANIMLADIĞIMIZ METOTLARIN İÇERİĞİNİ BURADA DOLDURUYORUZ. YANİ TANIMLANAN METOTLARA GÖREVLERİNİ KODLUYORUZ.

    //BÜTÜN BİLEŞENLERİN TAMAMINI KAPSIYOR.
    //TEK TEK CATEGORYREPOSİTORY, WRİTERREPOSİTORY,HEADİNGREPOSİTORY YAPMAK YERİNE GENEL BİR SINIF TANIMLAMAK YETERLİ OLUYOR.

    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Context c = new Context();  //GEREKLİ TANIMLAMALARIMIZI YAPTIK
        DbSet<T> _object;




        public GenericRepository()      //T değerine karşılık olarak gelecek sınıfı CONSTRUCTOR metodu tanımlayarak bulacağız.
                                        //Böylece dışarıdan hangi Entity gönderirsek sınıfı o olacak ve tek tek ayrı ayrı oluşturmaktan
                                        //kurtulmuş olduk.Contructor metodu sayesinde
        {
            _object = c.Set<T>();   //_object 'e değer ataması gerçekleştirdik. T 'nin karşılığı olan sınıfın hangisi olduğunu
                                    //bilebilmemiz için değer ataması şart.
                                    //Bu işlemde Constructor yapıcı metod sayesinde gerçekleştiriliyor.
        }



        public void Delete(T p)  //SİLME  //Entity State komutları ile silme yapmak
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            // _object.Remove(p);    Önceden oluşturduğum silme komutuna ihtiyacım kalmadı.
            c.SaveChanges();
        }



        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
    //SingleOrDefault bir dizide veya listede sadece bir tane değer geriye döndürmek için  kullanılan  EntityFramework LİNQ metodudur.
        }



        public void Insert(T p)  //EKLEME   //Entity State komutları ile ekleme yapmak
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;  //Oluşturduğum  addedEntity değişkeninin durumu
           // _object.Add(p);   Önceden oluşturduğum ekleme komutuna ihtiyacım kalmadı.
            c.SaveChanges();
        }



        public List<T> List()   //LİSTELEME
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)  //ŞARTLI LİSTELEME
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)   //GÜNCELLEME    Entity State komutları ile güncelleme yapmak
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;  //Modified biçimlendir düzenle anlamında
            c.SaveChanges();
        }
    }


}
