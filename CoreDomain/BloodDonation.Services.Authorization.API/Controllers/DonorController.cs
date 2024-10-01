using BloodDonation.Services.Donors.API.Extensions;
using BloodDonation.Services.Donors.Application.DTO.InputModels;
using BloodDonation.Services.Donors.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Infra.Results;

namespace BloodDonation.Services.Donors.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _donorService.GetByIdAsync(id);

            return result.Match(
                onSuccess: (donor) => Ok(donor),
                onFailure: (error) => error.ToProblemDetails()
            );
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _donorService.GetAllAsync();

            return result.Match(
                onSuccess: (donors) => Ok(donors),
                onFailure: (error) => error.ToProblemDetails()
            );
        }

   
        [HttpPost]
        public async Task<IActionResult> Create( DonorInputModel inputModel)
        {
            var result = await _donorService.CreateAsync(inputModel);

            return result.Match(
                onSuccess: (id) => Ok(new { id=result.Value}),
                onFailure: (error) => error.ToProblemDetails()
            );
        }

  
        [HttpPut]
        public async Task<IActionResult> Update( DonorUpdateInputModel inputModel)
        {
            var result = await _donorService.UpdateAsync(inputModel);

            return result.Match(
                onSuccess: NoContent,
                onFailure: (error) => error.ToProblemDetails()
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _donorService.DeleteAsync(id);

            return result.Match(
                onSuccess: NoContent,
                onFailure: (error) => error.ToProblemDetails()
            );
        }
    }
}
