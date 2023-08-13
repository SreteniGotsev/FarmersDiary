﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Infrastructure.Data
{
    public class Labour
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Father { get; set; }
        [Required]
        public string Date { get; set; }

        [ForeignKey("ModerId")]
        public Animal Mother { get; set; }
        public Guid MotherId { get; set; }
        
        public ICollection<Animal> Offsprings { get; set; } = new List<Animal>();
    }
}
