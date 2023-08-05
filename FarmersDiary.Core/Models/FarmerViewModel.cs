using FarmersDiary.Infrastructure.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Models
{
    public class FarmerViewModel
    {
        
        [Required]
        [MaxLength(30,ErrorMessage = "The name must be between 1 and 30 charecters")]
        [MinLength(1, ErrorMessage = "The name must be between 1 and 30 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The surname must be between 1 and 30 characters")]
        [MinLength(1, ErrorMessage = "The surname must be between 1 and 30 characters")]
        public string Surname { get; set; }

        [Required]
        [MinLength(100,ErrorMessage = "The Email must be no less than 100 charecters")]
        [MaxLength(100,ErrorMessage = "The Email must be no more than 100 charecters")]
        [EmailAddress()]
        public string Email { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage = "The address must be no more than 100 charecters")]
        [MinLength(10,ErrorMessage = "The address must be no less than 100 charecters")]
        public string Address { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
