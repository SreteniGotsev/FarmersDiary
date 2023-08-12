using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Data.Identity;
using FarmersDiary.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public FarmerService(IApplicationDbRepository _repo, IHttpContextAccessor _accessor)
        {
            repo = _repo;
            accessor = _accessor;
        }
        public async Task<bool> AddFarmer(FarmerViewModel model)
        {
            bool result = false;
            var userId = GetUserId();
            var user = UserGet();

            if (model != null && user.FarmerId == null)
            {

                Farmer farmer = new Farmer()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    Address = model.Address,
                    Email = model.Email,
                    UserId = userId,
                    User = user,
                };

                await repo.AddAsync<Farmer>(farmer);

                user.FarmerId = farmer.Id;
                user.Farmer = farmer;
                await repo.SaveChangesAsync();
                result = true;
            }




            return result;
        }

        public async Task<bool> EditFarmer(FarmerViewModel model)
        {
            bool result = false;
            var farmer = FarmerGet();


            if (farmer != null)
            {
                farmer.Name = model.Name;
                farmer.Surname = model.Surname;
                farmer.Email = model.Email;
                farmer.Address = model.Address;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public FarmerViewModel GetFarmer()
        {
            var user = UserGet();
            var farmer = repo.All<Farmer>().Where(x => x.Id == user.FarmerId).FirstOrDefault();
            if (farmer != null)
            {

                FarmerViewModel model = new FarmerViewModel()
                {
                    Name = farmer.Name,
                    Surname = farmer.Surname,
                    Address = farmer.Address,
                    Email = farmer.Email,
                };
                return model;
            }
            return null;

        }
        public void DeleteFarmer()
        {
            var userId = GetUserId();
            var farmer = repo.All<Farmer>().Where(f => f.UserId == userId).FirstOrDefault();
            repo.Delete<Farmer>(farmer);
            repo.SaveChanges();
        }

        private User UserGet()
        {
            var userId = GetUserId();
            var user = repo.GetByIdAsync<User>(userId).Result;
            return user;

        }
        private Farmer FarmerGet()
        {
            var userId = GetUserId();
            var farmer = repo.All<Farmer>().Where(f => f.UserId == userId).FirstOrDefault();
            return farmer;

        }
        private string GetUserId()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }


    }
}
