using FarmersDiary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Models
{
    public class AnimalShortViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        public string Breed { get; set; }

        public Sex Sex { get; set; }

        public AgeCategory AgeCategory { get; set; }
    }
}
