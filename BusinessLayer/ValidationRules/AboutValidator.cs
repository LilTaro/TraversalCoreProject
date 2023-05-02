using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AboutValidator:AbstractValidator<About>
	{
		public AboutValidator()
		{
			RuleFor(X => X.AboutImage1).NotEmpty().WithMessage("Lütfen Görsel Seçiniz");

			RuleFor(X => X.AboutDesc).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
			RuleFor(X => X.AboutDesc).MinimumLength(20).WithMessage("Lütfen En Az 20 Karakterlik Açıklama Giriniz");
			RuleFor(X => X.AboutDesc).MaximumLength(100).WithMessage("Lütfen Açıklamayı Kısaltın");

			RuleFor(X => X.AboutDesc2).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
			RuleFor(X => X.AboutDesc2).MinimumLength(20).WithMessage("Lütfen En Az 20 Karakterlik Açıklama Giriniz");
			RuleFor(X => X.AboutDesc2).MaximumLength(100).WithMessage("Lütfen Açıklamayı Kısaltın");

			RuleFor(X => X.AboutTitle).NotEmpty().WithMessage("Lütfen Başlık Giriniz");
			RuleFor(X => X.AboutTitle2).NotEmpty().WithMessage("Lütfen Başlık Giriniz");
		}
	}
}
