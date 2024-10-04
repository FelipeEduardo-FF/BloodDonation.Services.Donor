using BloodDonation.Services.Donors.Application.DTO.InputModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Services.Donors.Application.DTO.Validations
{
    public class DonorUpdateInputModelValidator:AbstractValidator<DonorUpdateInputModel>
    {
        public DonorUpdateInputModelValidator()
        {
            RuleFor(d => d.FullName)
                .NotEmpty().WithMessage("Full Name cannot be empty.");

            RuleFor(d => d.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(d => d.BirthDate)
                .NotEmpty().WithMessage("Birth Date cannot be empty.")
                .Must(b => b != default(DateTime)).WithMessage("Birth Date cannot be the default value.");

            RuleFor(d => d.Gender)
                .NotEmpty().WithMessage("Gender cannot be empty.");

            RuleFor(d => d.Weight)
                .GreaterThan(0).WithMessage("Weight must be greater than zero.");

            RuleFor(d => d.BloodType)
                .NotEmpty().WithMessage("Blood Type cannot be empty.");

            RuleFor(d => d.RhFactor)
                .NotEmpty().WithMessage("Rh Factor cannot be empty.");
        }
    }
}
