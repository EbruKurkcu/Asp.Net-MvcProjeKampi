using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            //NotEmpty() =>Boş Geçemezsiniz kodu
            //Hataları yakalamak için bu dğrulama işlemlerini yapmamız gerekmektedir.
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("AlıcıAdresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 Karakterden Fazla Değer Girişi Yapmayın");
           
        }
    }
}
