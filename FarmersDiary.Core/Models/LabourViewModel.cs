using FarmersDiary.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FarmersDiary.Core.Models
{
    public class LabourViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Guid FatherId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Date { get; set; }
       
        public Guid MotherId { get; set; }
        [ValidateNever]
        public ICollection<AnimalShortViewModel> Offsprings { get; set; } 
    }
}

