using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Enums;
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
    public class FarmViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50, ErrorMessage = "The length of the Number should be less than 200 charecters")]
        [MinLength(2, ErrorMessage = "The length of the Number should be no less than 2 charecters")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "The length of the Number should be less than 200 charecters")]
        [MinLength(2, ErrorMessage = "The length of the Number should be  no less than 2 charecters")]
        public string Description { get; set; }
        [EnumDataType(typeof(AnimalCategory), ErrorMessage = "Animal Category type value doesn't exist within enum")]
        public string AnimalCategory { get; set; }
        [EnumDataType(typeof(ProductiveCategory), ErrorMessage = "Productive Category type value doesn't exist within enum")]
        public string ProductiveCategory { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int NumberOfAnimals { get; set; }
        [ValidateNever]
        public Guid FarmerId { get; set; }
        [ValidateNever]
        [Required]
        public Farmer Farmer { get; set; }
        [ValidateNever]
        public ICollection<AnimalShortViewModel> Animals { get; set; }
    }
}
