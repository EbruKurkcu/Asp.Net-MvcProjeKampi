using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    //Burada ilgili metodun ismini tanımlıyoruz. Ardından ilgili metodun içini WriterManager da doldur.
    public interface IWriterService
    {
        List<Writer> GetList();   //LİSTELEME

        void WriterAdd(Writer writer);    //EKLEME

        void WriterDelete(Writer writer);   //SİLME

        void WriterUpdate(Writer writer);   //GÜNCELLEME

        Writer GetByID(int id);    //FİND İLGİLİ IDYE AİT VERİLERİ BULMA
    }
}
