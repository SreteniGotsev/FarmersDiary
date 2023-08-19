using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Data.Identity;
using FarmersDiary.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IApplicationDbRepository repo;
        public AdminService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public List<UserViewModel> GetAll()
        {
            var models = repo.All<User>().ToList();
            var users = new List<UserViewModel>();
            foreach (var model in models)
            {
                UserViewModel user = new UserViewModel()
                {
                    Id = model.Id,
                    UserName= model.UserName,
                    UserEmail= model.Email,
                    Password = model.PasswordHash
                };
                users.Add(user);
            }
            return users;
        }

        public async Task DeleteUser(string Id)
        {
            await repo.DeleteAsync<User>(Id);
            await repo.SaveChangesAsync();
        }

    }
}
