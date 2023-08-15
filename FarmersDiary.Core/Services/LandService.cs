using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Data.Repositories;
using FarmersDiary.Infrastructure.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class LandService : ILandService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public LandService(IApplicationDbRepository _repo, IHttpContextAccessor _accessor)
        {
            repo = _repo;
            accessor = _accessor;
        }
        public async Task<bool> AddParcel(ParcelViewModel model)
        {
            bool isDone = false;
            var farmer = GetFarmer();

            if (model != null)
            {
                Land land = new Land()
                {
                    Area= model.Area,
                    Description= model.Description,
                    Farmer= farmer,
                    FarmerId= farmer.Id,
                    Location= model.Location,
                    Number= model.Number,
                };

                await repo.AddAsync<Land>(land);
                isDone = true;
            }

            await repo.SaveChangesAsync();
            return isDone;
        }

        public async Task DeleteParcel(Guid id)
        {
            await repo.DeleteAsync<Land>(id);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> EditParcel(ParcelViewModel model)
        {
            bool isDone = false;
            var land = repo.All<Land>().Where(p=>p.Id == model.Id).FirstOrDefault();

            if (land != null)
            {
                land.Area = model.Area;
                land.Description = model.Description;
                land.Location = model.Location;
                land.Number = model.Number; 
                
                
                await repo.SaveChangesAsync();
                isDone = true;
            }
            return isDone;
        }

        public ICollection<ParcelShortViewModel> AllParcels()
        {
            var farmer = GetFarmer();
            var land = repo.All<Land>().Where(l => l.FarmerId == farmer.Id).ToList();
            var pc = new List<ParcelShortViewModel>();
            foreach (var parcel in land)
            {
                ParcelShortViewModel model = new ParcelShortViewModel()
                {
                   Id= parcel.Id,
                   Number= parcel.Number,
                   Area= parcel.Area,
                };

                pc.Add(model);

            }
            return pc;
        }

        public ParcelViewModel GetParcel(Guid id)
        {
            var land = repo.All<Land>().Where(p=>p.Id== id).FirstOrDefault();

            if (land == null)
            {
                return null;
            }

            ParcelViewModel model = new ParcelViewModel()
            {
                Id = land.Id,
                Number= land.Number,
                Area= land.Area,
                Description= land.Description,
                Location = land.Location
            };
            
            return model;
        }
        private Farmer GetFarmer()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var farmer = repo.All<Farmer>().Where(f => f.UserId.Equals(userId)).FirstOrDefault();
            return farmer;
        }
    }
}
