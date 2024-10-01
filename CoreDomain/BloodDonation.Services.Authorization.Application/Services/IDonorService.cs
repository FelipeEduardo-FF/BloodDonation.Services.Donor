using BloodDonation.Services.Donors.Application.DTO.InputModels;
using BloodDonation.Services.Donors.Application.DTO.ViewModels;
using Shared.Infra.Results;

namespace BloodDonation.Services.Donors.Application.Services
{
    public interface IDonorService
    {
        Task<Result<int>> CreateAsync(DonorInputModel inputModel);
        Task<Result> DeleteAsync(int id);
        Task<Result<List<DonorViewModel>>> GetAllAsync();
        Task<Result<DonorViewModel>> GetByIdAsync(int id);
        Task<Result> UpdateAsync(DonorUpdateInputModel inputModel);
    }
}