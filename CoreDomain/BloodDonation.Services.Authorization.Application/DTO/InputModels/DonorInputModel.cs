using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Services.Donors.Application.DTO.InputModels
{
    public class DonorInputModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public string BloodType { get; set; }
        public string RhFactor { get; set; }
    }

}
