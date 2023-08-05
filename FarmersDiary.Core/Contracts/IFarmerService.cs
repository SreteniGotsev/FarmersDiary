using FarmersDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Contracts
{
    public interface IFarmerService
    {
        Task<bool> AddFarmer(FarmerViewModel model);
        FarmerViewModel GetFarmer();
        Task<bool> EditFarmer(FarmerViewModel model);
        void DeleteFarmer();

    }
}
