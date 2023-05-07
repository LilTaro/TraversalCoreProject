using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(X => X.GuideName).NotEmpty().WithMessage("Lütfen Rehber Adınız Giriniz");
            RuleFor(X => X.GuideDesc).NotEmpty().WithMessage("Lütfen Rehber Açıklamasını Giriniz");
            RuleFor(X => X.GuideImageUrl).NotEmpty().WithMessage("Lütfen Rehber Görselini Giriniz");
        }
    }
}
