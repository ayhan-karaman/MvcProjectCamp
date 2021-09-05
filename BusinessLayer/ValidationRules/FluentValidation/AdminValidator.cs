using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(a => a.AdminUserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(a => a.AdminPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez");


            RuleFor(a => a.AdminUserName).MinimumLength(3).WithMessage("Kullanıcı Adınız En Az 3 Karakter Olmalı");
            RuleFor(a => a.AdminPassword).MinimumLength(6).WithMessage("Şifreniz  En Az 6 Karakter Olmalı");
        }
    }
}
