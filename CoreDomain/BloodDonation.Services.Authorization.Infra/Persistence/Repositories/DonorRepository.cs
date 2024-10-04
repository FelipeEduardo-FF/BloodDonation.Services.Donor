using BloodDonation.Services.Donors.Domain.Entities;
using BloodDonation.Services.Donors.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Services.Donors.Infra.Persistence.Repositories
{
    public class DonorRepository: IDonorRepository
    {
        private readonly AppDbContext _context;

        public DonorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Donor?> GetByIdAsync(int id)
        {
            return await _context.Donors.FindAsync(id);
        }

        public async Task<bool> ExistsDonorWithEmail(string email)
        {
            return await _context.Donors.AnyAsync(d=>d.Email.ToLower()==email.ToLower());
        }

        public async Task<List<Donor>> GetAllAsync()
        {
            return await _context.Donors.ToListAsync();
        }

        public async Task AddAsync(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Donor donor)
        {
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }
    }
}
