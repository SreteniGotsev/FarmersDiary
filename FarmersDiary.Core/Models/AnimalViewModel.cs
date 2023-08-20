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
    public class AnimalViewModel
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage ="This field is required")]
        [MaxLength(50,ErrorMessage ="The length of the Number should be less than 50 charecters")]
        [MinLength(5, ErrorMessage = "The length of the Number should be no less than 5 charecters")]
        public string Number { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50, ErrorMessage = "The length of the Breed should be less than 50 charecters")]
        [MinLength(2, ErrorMessage = "The length of the Breed should be no less than 50 charecters")]
        public string Breed { get; set; }
        
        [EnumDataType(typeof(Sex), ErrorMessage = "Sex type value doesn't exist within enum")]
        public Sex Sex { get; set; }

        [EnumDataType(typeof(AgeCategory), ErrorMessage = "Age Category type value doesn't exist within enum")]
        public AgeCategory AgeCategory { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string DOB { get; set; }
        [ValidateNever]

        [ForeignKey("Farm")]
        public Guid FarmId { get; set; }
        [ValidateNever]
        public Farm Farm { get; set; }
        [ValidateNever]
        public ICollection<LabourShortViewModel> Labours { get; set; }

    }
}

