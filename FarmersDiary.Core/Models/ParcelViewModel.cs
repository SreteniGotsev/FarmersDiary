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
    public class ParcelViewModel
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "This field is required")]
        public string Location { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "The length of the Number should be less than 100 charecters")]

        public string Number { get; set; }
        [Range(0.00, 10000.00,ErrorMessage ="The area should be a number between 0.00 and 10 000.00")]
        public double Area { get; set; }

        public string Description { get; set; }

        [ValidateNever]
        public Guid FarmerId { get; set; }
        [ValidateNever]
        public Farmer Farmer { get; set; }
    }
}
