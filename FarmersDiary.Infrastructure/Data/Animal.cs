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
    public class Animal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        public string Breed { get; set; }

        public Sex Sex { get; set; }

        public AgeCategory AgeCategory { get; set; }

        [Required]
        public string DOB { get; set; }

        [ForeignKey("Farm")]
        public Guid FarmId { get; set; }
        public Farm Farm { get; set; }

        ICollection<Labour> Labours { get; set; } = new List<Labour>();


    }
}
