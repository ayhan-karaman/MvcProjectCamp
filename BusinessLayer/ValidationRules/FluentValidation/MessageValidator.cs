using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
 public   class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.ReceiverMail).NotEmpty();
            RuleFor(m => m.Subject).NotEmpty();
            RuleFor(m => m.MessageContent).NotEmpty();

            RuleFor(m => m.Subject).MinimumLength(3);
            RuleFor(m => m.MessageContent).MinimumLength(10);
            RuleFor(m => m.Subject).MaximumLength(100);


            RuleFor(m => m.ReceiverMail).EmailAddress().WithMessage("Geçersiz Bir Email Girdiniz");
        }
    }
}
