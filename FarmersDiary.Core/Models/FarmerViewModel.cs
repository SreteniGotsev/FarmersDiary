using FarmersDiary.Infrastructure.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FarmersDiary.Core.Models
{
    public class FarmerViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "The name must be between 1 and 30 charecters")]
        [MinLength(1, ErrorMessage = "The name must be between 1 and 30 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The surname must be between 1 and 30 characters")]
        [MinLength(1, ErrorMessage = "The surname must be between 1 and 30 characters")]
        public string Surname { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The Email must be no less than 10 charecters")]
        [MaxLength(100, ErrorMessage = "The Email must be no more than 100 charecters")]
        [EmailAddress(ErrorMessage = "This has to be a valid email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The address must be no more than 100 charecters")]
        [MinLength(10, ErrorMessage = "The address must be no less than 10 charecters")]
        public string Address { get; set; }

        [ForeignKey("User")]
        [ValidateNever]
        public string UserId { get; set; }
        [ValidateNever]
        public User User { get; set; }
    }
}
