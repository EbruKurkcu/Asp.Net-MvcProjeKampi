﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact> //İndirdiğimiz Pakette FluentValidation sınıfını imlement etmemiz gerekiyor
    {
        public ContactValidator()   //Constractor metot tanımlamamız gerekmektedir
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");
            //NotEmpty() =>Boş Geçemezsiniz kodu
            //Hataları yakalamak için bu dğrulama işlemlerini yapmamız gerekmektedir.
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 Karakter Girişi Yapın");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 Karakter Girişi Yapın");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 Karakterden fazla değer girişi yapmayın");
           
        }
    }
}
