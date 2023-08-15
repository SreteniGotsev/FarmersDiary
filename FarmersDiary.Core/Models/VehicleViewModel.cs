using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Models
{
    public class VehicleViewModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public string Make { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        public string RegistationPlate { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
        public Guid FarmerId { get; set; }
    }
}
