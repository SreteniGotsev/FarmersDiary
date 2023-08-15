using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public VehicleService(IApplicationDbRepository _repo, IHttpContextAccessor _accessor)
        {
            repo = _repo;
            accessor = _accessor;
        }
        public async Task<bool> AddVehicle(VehicleViewModel model)
        {
            bool isDone = false;
            var farmer = GetFarmer();

            if (model != null)
            {
                Vehicle vehicle = new Vehicle()
                {
                    Make = model.Make,
                    Model = model.Model,
                    FarmerId= farmer.Id,
                    Farmer = farmer,
                    RegistationPlate= model.RegistationPlate,
                    VehicleCategory= model.VehicleCategory,
                };

                await repo.AddAsync<Vehicle>(vehicle);
                isDone = true;
            }

            await repo.SaveChangesAsync();
            return isDone;
        }

        public async Task DeleteVehicle(Guid Id)
        {
            await repo.DeleteAsync<Vehicle>(Id);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> EditVehicle(VehicleViewModel model)
        {
            bool isDone = false;
            var vehicle = repo.All<Vehicle>().Where(p => p.Id == model.Id).FirstOrDefault();

            if (vehicle != null)
            {
                vehicle.VehicleCategory = model.VehicleCategory;
                vehicle.RegistationPlate = model.RegistationPlate;
                vehicle.Make = model.Make;
                vehicle.Model = model.Model;

                await repo.SaveChangesAsync();
                isDone = true;
            }
            return isDone;
        }

        public ICollection<VehicleShortViewModel> AllVehicles()
        {
            var farmer = GetFarmer();
            var vehicles = repo.All<Vehicle>().Where(l => l.FarmerId == farmer.Id).ToList();
            var vl = new List<VehicleShortViewModel>();
            foreach (var vehicle in vehicles)
            {
                VehicleShortViewModel model = new VehicleShortViewModel()
                {
                   Id= vehicle.Id,
                   Make = vehicle.Make,
                   Model = vehicle.Model
                };

                vl.Add(model);

            }
            return vl;
        }

        public VehicleViewModel GetVehicle(Guid Id)
        {
            var vehicle = repo.All<Vehicle>().Where(p => p.Id == Id).FirstOrDefault();

            if (vehicle == null)
            {
                return null;
            }

            VehicleViewModel model = new VehicleViewModel()
            {
                Id= Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                RegistationPlate= vehicle.RegistationPlate,
                VehicleCategory= vehicle.VehicleCategory,
                FarmerId = vehicle.FarmerId
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
