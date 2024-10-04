using BloodDonation.Services.Donors.Application.DTO;
using BloodDonation.Services.Donors.Application.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using BloodDonation.Services.Donors.Application.DTO.Validations;

namespace BloodDonation.Services.Donors.Application
{
    public static class  BloodDonationApplicationModules
    {
        public static IServiceCollection AddBloodDonationApplicationModules(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntityToDTOMapper));
            services.AddServices();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDonorService, DonorService>();
            return services;
        }

        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<DonorInputModelValidator>();
            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}
