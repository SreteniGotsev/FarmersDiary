using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Infrastructure.Data
{
    public class Farmer:IdentityUser
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public ICollection<Farm> Farms { get; set; } = new List<Farm>();
        public ICollection<Land> Lands { get; set; } = new List<Land>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>(); 
    }
}
