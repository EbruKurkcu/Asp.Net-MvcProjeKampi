using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidatior:AbstractValidator<Category>  //İndirdiğimiz Pakette FluentValidation sınıfını imlement etmemiz gerekiyor
    {

        //Constractor metot tanımlamamız gerekmektedir
        public CategoryValidatior()
        {
            //NotEmpty() =>Boş Geçemezsiniz kodu
            //Hataları yakalamak için bu dğrulama işlemlerini yapmamız gerekmektedir.
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");

        }
    }
}
