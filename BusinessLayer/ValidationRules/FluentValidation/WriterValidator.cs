using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
  public  class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty();
            RuleFor(w => w.WriterSurname).NotEmpty();
            RuleFor(w => w.WriterAbout).NotEmpty();
            RuleFor(w => w.WriterTitle).NotEmpty();

            RuleFor(w => w.WriterName).MinimumLength(3);
            RuleFor(w => w.WriterName).MaximumLength(30);



            RuleFor(w => w.WriterSurname).MinimumLength(3);
            RuleFor(w => w.WriterSurname).MaximumLength(30);

           

           // RuleFor(w => w.WriterAbout).Must(ContainsWithA).WithMessage("Hakkında kısmı A harfi içermelidir");
        }

        private bool ContainsWithA(string arg)
        {
           

            return arg.Contains("a");
            
        }
    }


  
}
