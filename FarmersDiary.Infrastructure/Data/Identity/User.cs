using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Infrastructure.Data.Identity
{
    public class User:IdentityUser
    {
        public Guid? FarmerId { get; set; }
        public Farmer? Farmer { get; set; }
    }
}
