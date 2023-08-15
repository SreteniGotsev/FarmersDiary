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
    public class ParcelViewModel
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Location { get; set; }
        [Required]
        [MaxLength(100)]

        public string Number { get; set; }
        [Range(0.00, 10000.00)]
        public double Area { get; set; }

        public string Description { get; set; }

        public Guid FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}
