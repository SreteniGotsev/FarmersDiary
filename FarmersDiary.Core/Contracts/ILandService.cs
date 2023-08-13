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
        ICollection<ParcelShortViewModel> GetAllParcels();
        Task<bool> EditParcel(ParcelViewModel model);
        void DeleteParcel(Guid id);
    }
}
