using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
  public  class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty();
            RuleFor(c => c.CategoryDescription).NotEmpty();
            RuleFor(c => c.CategoryName).MinimumLength(3);
            RuleFor(c => c.CategoryName).MaximumLength(20);

        }
    }
}
