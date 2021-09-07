using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
  public  class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetail1).NotEmpty();
            RuleFor(x => x.AboutDetail2).NotEmpty();

            RuleFor(x => x.AboutDetail1).MinimumLength(5);

        }
    }
}
