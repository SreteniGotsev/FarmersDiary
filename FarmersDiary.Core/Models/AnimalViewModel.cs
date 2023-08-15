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
    public class AnimalViewModel
    {
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Breed { get; set; }

        public Sex Sex { get; set; }

        public AgeCategory AgeCategory { get; set; }

        [Required]
        public string DOB { get; set; }

        [ForeignKey("Farm")]
        public Guid FarmId { get; set; }
        public Farm Farm { get; set; }

        public ICollection<LabourShortViewModel> Labours { get; set; }

    }
}

