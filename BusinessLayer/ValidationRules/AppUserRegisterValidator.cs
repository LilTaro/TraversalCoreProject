using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(X => X.Name).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(X => X.Surname).NotEmpty().WithMessage("Soyad Boş Geçilemez");
            RuleFor(X => X.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(X => X.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(X => X.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");
            RuleFor(X => X.confirmPassword).NotEmpty().WithMessage("Şifre Tekrar Boş Geçilemez");
            RuleFor(X => X.Username).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakterlik Kullanıcı Adı Giriniz");
            RuleFor(X => X.Username).MaximumLength(15).WithMessage("Lütfen En Fazla 15 Karakterlik Kullanıcı Adı Giriniz");
            RuleFor(X => X.Password).Equal(y => y.confirmPassword).WithMessage("Şifreler Aynı Değil");
        }
    }
}
