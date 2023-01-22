using FluentValidation;
using PersonelKontrol.Domain.Entities.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKontrol.Application.Validators
{
    public class EmployeeMovementsValidator : AbstractValidator<PersonelHareketleri>
    {
        public EmployeeMovementsValidator()
        {
            RuleFor(x => x.PersonelId).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
            RuleFor(x => x.Tarih).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
            RuleFor(x => x.GirisSaati).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
            RuleFor(x => x.CikisSaati).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!");
            RuleFor(x => x.AktifMi).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!"); 
            RuleFor(x => x.OlusturulmaZamani).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!"); 
            RuleFor(x => x.AktifMi).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!"); 
            RuleFor(x => x.SilindiMi).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!"); 

        }

    }
}
