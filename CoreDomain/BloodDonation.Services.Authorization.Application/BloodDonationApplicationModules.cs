using BloodDonation.Services.Donors.Application.DTO;
using BloodDonation.Services.Donors.Application.Services;
using Microsoft.Extensions.DependencyInjection;

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

    }
}
