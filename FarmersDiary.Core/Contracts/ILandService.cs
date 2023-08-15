using FarmersDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Contracts
{
    public interface ILandService
    {
        Task<bool> AddParcel(ParcelViewModel model);
        ParcelViewModel GetParcel(Guid id);
        ICollection<ParcelShortViewModel> AllParcels();
        Task<bool> EditParcel(ParcelViewModel model);
        Task DeleteParcel(Guid id);
    }
}
