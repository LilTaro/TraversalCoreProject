using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(X => X.AnnouncementTitle).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(X => X.AnnouncementContent).NotEmpty().WithMessage("İçerik Boş Geçilemez");
            RuleFor(X => X.AnnouncementTitle).MinimumLength(5).WithMessage("Başlık En Az 5 Karakter Olmalı");
            RuleFor(X => X.AnnouncementContent).MinimumLength(20).WithMessage("İçerik En Az 20 Karakter Olmalı");
        }
    }
}
