using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MeetingReminder.Entities;

namespace MeetingReminder.Business.ValidationRules.FluentValidation
{
   public  class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim boş olamaz.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyisim boş olamaz");
            RuleFor(p => p.StartTime).NotEmpty().WithMessage("Başlangıc zamanı boş olamaz");
            RuleFor(p => p.FinishTime).NotEmpty().WithMessage("Bitiş zamanı boş olamaz");
        }
    }
}
