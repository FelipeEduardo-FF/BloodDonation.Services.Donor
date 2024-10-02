using BloodDonation.Services.Donors.Domain.Repositories;
using Shared.Infra.Results.Errors;
using Shared.Infra.Results;
using BloodDonation.Services.Donors.Domain.Entities;
using BloodDonation.Services.Donors.Application.DTO.InputModels;
using BloodDonation.Services.Donors.Application.DTO.ViewModels;
using AutoMapper;

namespace BloodDonation.Services.Donors.Application.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;

        public DonorService(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<Result<DonorViewModel>> GetByIdAsync(int id)
        {
            var donor = await _donorRepository.GetByIdAsync(id);
            if (donor == null)
            {
                return OperationResult.NotFound<DonorViewModel>("Donor not found");
            }

            var donorViewModel = _mapper.Map<DonorViewModel>(donor);
            return OperationResult.Ok(donorViewModel);
        }

        public async Task<Result<List<DonorViewModel>>> GetAllAsync()
        {
            var donors = await _donorRepository.GetAllAsync();
            if (donors == null)
            {
                return OperationResult.NotFound<List<DonorViewModel>>("No donors found");
            }

            var donorViewModels = new List<DonorViewModel>();
            foreach (var donor in donors)
            {
                var donorViewModel = _mapper.Map<DonorViewModel>(donor);
                donorViewModels.Add(donorViewModel);
            }

            return OperationResult.Ok(donorViewModels);
        }

        public async Task<Result<int>> CreateAsync(DonorInputModel inputModel)
        {
            var donor = _mapper.Map<Donor>(inputModel);
            await _donorRepository.AddAsync(donor);
            return OperationResult.Ok(donor.Id);
        }

        public async Task<Result> UpdateAsync(DonorUpdateInputModel inputModel)
        {
            var donor = await _donorRepository.GetByIdAsync(inputModel.Id);
            if (donor == null)
            {
                return OperationResult.NotFound("Donor not found");
            }

            donor.Update(inputModel.FullName,
                        inputModel.Email,
                        inputModel.BirthDate,
                        inputModel.Gender,
                        inputModel.Weight,
                        inputModel.BloodType,
                        inputModel.RhFactor);

            await _donorRepository.UpdateAsync(donor);
            return OperationResult.Ok();
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var donor = await _donorRepository.GetByIdAsync(id);
            if (donor == null)
            {
                return OperationResult.NotFound("Donor not found");
            }

            await _donorRepository.DeleteAsync(donor);
            return OperationResult.Ok();
        }
    }
}
