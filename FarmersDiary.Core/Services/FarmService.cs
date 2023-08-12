using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Data.Repositories;
using FarmersDiary.Infrastructure.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FarmersDiary.Core.Services
{
    public class FarmService : IFarmService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public FarmService(IApplicationDbRepository _repo, IHttpContextAccessor _accessor)
        {
            repo = _repo;
            accessor = _accessor;
        }
        public async Task<bool> AddFarm(FarmViewModel model)
        {
            bool isDone = false;
            var farmer = GetFarmer();

            if (model != null)
            {
                Farm farm = new Farm()
                {
                    Name = model.Name,
                    Description = model.Description,
                    AnimalCategory = Enum.Parse<AnimalCategory>(model.AnimalCategory),
                    ProductiveCategory = Enum.Parse<ProductiveCategory>(model.ProductiveCategory),
                    NumberOfAnimals = model.NumberOfAnimals,
                    Farmer = farmer,
                    FarmerId = farmer.Id,
                };
                await repo.AddAsync<Farm>(farm);
                isDone = true;
            }

            await repo.SaveChangesAsync();
            return isDone;

        }

        public async void DeleteFarm(AnimalCategory category)
        {
            var farm = FarmGet(category);
            repo.Delete(farm);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> EditFarm(FarmViewModel model)
        {

            bool isDone = false;
            var farm = FarmGet(Enum.Parse<AnimalCategory>(model.AnimalCategory));

            if (farm != null)
            {
                farm.Name = model.Name;
                farm.Description = model.Description;
                farm.AnimalCategory = Enum.Parse<AnimalCategory>(model.AnimalCategory);
                farm.ProductiveCategory = Enum.Parse<ProductiveCategory>(model.ProductiveCategory);
                farm.Description = model.Description;

                await repo.SaveChangesAsync();
                isDone = true;
            }

            return isDone;
        }

        public ICollection<FarmShortViewModel> GetAllFarms()
        {
            var farmer = GetFarmer();
            var farms = repo.All<Farm>().Where(f => f.FarmerId == farmer.Id).ToList();
            var fr = new List<FarmShortViewModel>();
            foreach (var farm in farms)
            {
                FarmShortViewModel model = new FarmShortViewModel()
                {
                    Name = farm.Name,
                    AnimalCategory = farm.AnimalCategory,
                    NumberOfAnimals = farm.NumberOfAnimals,
                };

                fr.Add(model);

            }
            return fr;
        }

        public FarmViewModel GetFarm(AnimalCategory category)
        {
            var farm = FarmGetWithAnimals(category);

            if (farm == null)
            {
                return null;
            }

            FarmViewModel model = new FarmViewModel()
            {

                Name = farm.Name,
                Description = farm.Description,
                AnimalCategory = farm.AnimalCategory.ToString(),
                ProductiveCategory = farm.ProductiveCategory.ToString(),
                NumberOfAnimals = farm.NumberOfAnimals,
            };
            foreach (var an in farm.Animals)
            {
                AnimalShortViewModel animal = new AnimalShortViewModel()
                {
                    Number = an.Number,
                    AgeCategory = an.AgeCategory,
                    Sex = an.Sex,
                    Breed = an.Breed,
                };

                model.Animals.Add(animal);
            }
            return model;
        }

        private Farm FarmGetWithAnimals(AnimalCategory category)
        {
            var farmer = GetFarmer();
            var farm = repo.All<Farm>().Where(f => (f.FarmerId == farmer.Id) && (f.AnimalCategory == category))
                .Include("Animals")
                .FirstOrDefault();
            return farm;
        }
        private Farmer GetFarmer()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var farmer = repo.All<Farmer>().Where(f => f.UserId.Equals(userId)).FirstOrDefault();
            return farmer;
        }
        private Farm FarmGet(AnimalCategory category)
        {
            var farmer = GetFarmer();
            var farm = repo.All<Farm>().Where(f => (f.FarmerId == farmer.Id) && (f.AnimalCategory == category)).FirstOrDefault();
            return farm;
        }
    }
}
