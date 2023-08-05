using FarmersDiary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Infrastructure.Data
{
    public class Farm
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public AnimalCategory AnimalCategory { get; set; }
        public ProductiveCategory ProductiveCategory { get; set; }
        public int NumberOfAnimals { get; set; }

        [ForeignKey("Farm")]
        public Guid FarmerId { get; set; }
        [Required]
        public Farmer Farmer { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();

    }
}
