using FluentValidation;
using PersonelKontrol.Domain.Entities.Concrates;

namespace PersonelKontrol.Application.Validators
{
    public class EmployeeValidator : AbstractValidator<Personel>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.KimlikNo).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
            RuleFor(x => x.Adi).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
            RuleFor(x => x.Soyadi).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
            RuleFor(x => x.Telefon).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");            
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");            
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required")
                                 .EmailAddress().WithMessage("{PropertyName} is not valid");
            RuleFor(x => x.OlusturulmaZamani).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
            RuleFor(x => x.AktifMi).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
            RuleFor(x => x.SilindiMi).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
        }

    }
}