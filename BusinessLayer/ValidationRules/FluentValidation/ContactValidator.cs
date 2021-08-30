using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
  public  class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.UserMail).NotEmpty();
            RuleFor(c => c.Subject).NotEmpty();
            RuleFor(c => c.UserName).NotEmpty();

            RuleFor(c => c.Subject).MinimumLength(3);
            RuleFor(c => c.UserName).MinimumLength(3);
            RuleFor(c => c.Subject).MaximumLength(50);


        }
    }
}
