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
    public class ImageFileManager : IImageFileService
    {

        IImageFileDal _imagefileDal ;

        public ImageFileManager(IImageFileDal imagefileDal)   //Constructor Oluşturuldu
        {
            _imagefileDal = imagefileDal;
        }

        public List<ImageFile> GetList() // Sadece listeleme oluşturulacak.
        {
            return _imagefileDal.List();
        }
    }
}
