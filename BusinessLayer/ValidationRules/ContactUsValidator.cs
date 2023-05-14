using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactUsValidator : AbstractValidator<SendMessageDTO>
    {
        public ContactUsValidator()
        {
            RuleFor(X => X.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(X => X.Subject).NotEmpty().WithMessage("Konu Alanı Boş Geçilemez");
            RuleFor(X => X.MessageBody).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");
            RuleFor(X => X.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
        }
    }
}
