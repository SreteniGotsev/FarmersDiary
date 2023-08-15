using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Models
{
    public class HomeViewModel
    {
        public ICollection<FarmShortViewModel> farms { get; set; }
        public ICollection<ParcelShortViewModel> parcels { get; set; }
        public ICollection<VehicleShortViewModel> vehicles { get; set; }
    }
}
