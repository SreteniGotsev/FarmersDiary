using FarmersDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Contracts
{
    public interface IVehicleService
    {
        Task<bool> AddVehicle(VehicleViewModel model);
        VehicleViewModel GetVehicle(string number);
        ICollection<VehicleShortViewModel> GetAllVehicles();
        Task<bool> EditVehicle(VehicleViewModel model);
        void DeleteVehicle(string number);
    }
}
