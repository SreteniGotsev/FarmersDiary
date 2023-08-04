using FarmersDiary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Infrastructure.Data
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public string Make { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        public string RegistationPlate { get; set;}
        public VehicleCategory VehicleCategory { get; set; }

        [ForeignKey("Farmer")]
        public string FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}
