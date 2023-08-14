using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Models
{
    public class FarmShortViewModel
    {
        public Guid Id { get; set; }   
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string? Name { get; set; }
        [MaxLength(200)]
        [MinLength(2)]
        public AnimalCategory AnimalCategory { get; set; }
        public int NumberOfAnimals { get; set; }
        
    }
}
