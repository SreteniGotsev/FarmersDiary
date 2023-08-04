using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Infrastructure.Data
{
    public class Land
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Location { get; set; }
        [Required]
        [MaxLength(100)]
        public string Number { get; set; }
        [Range(0.00, 10000.00)]
        public double Area { get; set; }

        [ForeignKey("Farmer")]
        public string FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}
