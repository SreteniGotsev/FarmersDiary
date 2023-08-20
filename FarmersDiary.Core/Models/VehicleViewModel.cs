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
    public class VehicleViewModel
    {

        public Guid Id { get; set; } 
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100,ErrorMessage= "The length of the Number should be less than 100 charecters")]
        public string Make { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100,ErrorMessage ="The length of the Number should be less than 100 charecters")]
        public string Model { get; set; }
        public string RegistationPlate { get; set; }
        [EnumDataType(typeof(VehicleCategory), ErrorMessage = "Vehicle Category type value doesn't exist within enum")]
        public VehicleCategory VehicleCategory { get; set; }
        [ValidateNever]
        public Guid FarmerId { get; set; }
    }
}
