using BloodDonation.Services.Donors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Services.Donors.Domain.Repositories
{
    public interface IDonorRepository
    {
        Task<Donor?> GetByIdAsync(int id);
        Task<List<Donor>> GetAllAsync();
        Task AddAsync(Donor donor);
        Task UpdateAsync(Donor donor);
        Task DeleteAsync(Donor donor);
    }
}
