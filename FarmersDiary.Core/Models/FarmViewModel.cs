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
    public class FarmViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        [MinLength(2)]
        public string Description { get; set; }
        public string AnimalCategory { get; set; }
        public string ProductiveCategory { get; set; }
        public int NumberOfAnimals { get; set; }
        public Guid FarmerId { get; set; }
        [Required]
        public Farmer Farmer { get; set; }

        public ICollection<AnimalShortViewModel> Animals { get; set; }
    }
}
