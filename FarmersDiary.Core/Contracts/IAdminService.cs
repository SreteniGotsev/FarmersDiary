using FarmersDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Contracts
{
    public interface IAdminService
    {
        List<UserViewModel> GetAll();
        Task DeleteUser(string Id);

    }
}
