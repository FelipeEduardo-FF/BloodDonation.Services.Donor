using BloodDonation.Services.Donors.Application.DTO.InputModels;
using FluentValidation;

namespace BloodDonation.Services.Donors.Application.DTO.Validations
{
    public class DonorInputModelValidator : AbstractValidator<DonorInputModel>
    {
        private static readonly string[] ValidBloodTypes = { "A", "B", "AB", "O" }; // Tipos sanguíneos válidos
        private static readonly string[] ValidRhFactors = { "+", "-" }; // Fatores Rh válidos

        public DonorInputModelValidator()
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
                .NotEmpty().WithMessage("Gender cannot be empty.")
                .Must(g => g.Equals("male", StringComparison.OrdinalIgnoreCase) ||
                            g.Equals("female", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Gender must be either 'male' or 'female'.");

            RuleFor(d => d.Weight)
                .GreaterThan(0).WithMessage("Weight must be greater than zero.");

            RuleFor(d => d.BloodType)
                .NotEmpty().WithMessage("Blood Type cannot be empty.")
                .Must(bt => ValidBloodTypes.Contains(bt.ToUpper())).WithMessage("Invalid blood type.");

            RuleFor(d => d.RhFactor)
                .NotEmpty().WithMessage("Rh Factor cannot be empty.")
                .Must(rh => ValidRhFactors.Contains(rh)).WithMessage("Invalid Rh Factor.");
        }
    }

}
