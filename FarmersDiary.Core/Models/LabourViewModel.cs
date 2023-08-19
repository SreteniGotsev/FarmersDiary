using FarmersDiary.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Models
{
    public class LabourViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public Guid FatherId { get; set; }
        [Required]
        public string Date { get; set; }

       
        public Guid MotherId { get; set; }

        public ICollection<AnimalShortViewModel> Offsprings { get; set; } 
    }
}

