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
    public class LabourShortViewModel
    {
        public Guid Id { get; set; }
        public string Date { get; set; }

        [ForeignKey("ModerId")]
        public Animal Mother { get; set; }
        public Guid MotherId { get; set; }


    }
}
