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
        VehicleViewModel GetVehicle(Guid id);
        ICollection<VehicleShortViewModel> AllVehicles();
        Task<bool> EditVehicle(VehicleViewModel model);
        Task DeleteVehicle(Guid id);
    }
}
