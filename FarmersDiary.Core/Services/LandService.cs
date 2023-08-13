using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class LandService : ILandService
    {
        public Task<bool> AddParcel(ParcelViewModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteParcel(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditParcel(ParcelViewModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<ParcelShortViewModel> GetAllParcels()
        {
            throw new NotImplementedException();
        }

        public ParcelViewModel GetParcel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
