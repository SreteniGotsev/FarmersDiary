using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Contracts
{
    public interface IFarmService
    {
        Task<bool> AddFarm(FarmViewModel model);
        FarmViewModel GetFarm(AnimalCategory category);
        ICollection<FarmShortViewModel> GetAllFarms();
        Task<bool> EditFarm(FarmViewModel model);
        void DeleteFarm(AnimalCategory category);

    }
}
