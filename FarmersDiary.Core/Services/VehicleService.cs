using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class VehicleService : IVehicleService
    {
        public Task<bool> AddVehicle(VehicleViewModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(string number)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditVehicle(VehicleViewModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<VehicleShortViewModel> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public VehicleViewModel GetVehicle(string number)
        {
            throw new NotImplementedException();
        }
    }
}
