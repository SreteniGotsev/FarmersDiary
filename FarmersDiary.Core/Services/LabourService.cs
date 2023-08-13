using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class LabourService : ILabourService
    {
        public Task<bool> AddLabour(LabourViewModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteLabour()
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditLabour(LabourViewModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<LabourShortViewModel> GetAllLabours()
        {
            throw new NotImplementedException();
        }

        public LabourViewModel GetLabour()
        {
            throw new NotImplementedException();
        }
    }
}
