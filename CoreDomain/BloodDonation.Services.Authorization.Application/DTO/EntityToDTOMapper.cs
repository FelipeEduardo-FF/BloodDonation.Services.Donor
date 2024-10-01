using AutoMapper;
using BloodDonation.Services.Donors.Application.DTO.InputModels;
using BloodDonation.Services.Donors.Application.DTO.ViewModels;
using BloodDonation.Services.Donors.Domain.Entities;

namespace BloodDonation.Services.Donors.Application.DTO
{
    public class EntityToDTOMapper:Profile
    {
        public EntityToDTOMapper()
        {
            CreateMap<Donor, DonorInputModel>().ReverseMap();
            CreateMap<Donor, DonorViewModel>().ReverseMap();

        }
    }
}
