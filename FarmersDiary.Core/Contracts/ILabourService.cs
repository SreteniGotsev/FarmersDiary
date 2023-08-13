using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Contracts
{
    public interface ILabourService
    {
        Task<bool> AddLabour(LabourViewModel model);
        LabourViewModel GetLabour();
        ICollection<LabourShortViewModel> GetAllLabours();
        Task<bool> EditLabour(LabourViewModel model);
        void DeleteLabour();
    }
}
