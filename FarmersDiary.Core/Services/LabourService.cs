using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class LabourService : ILabourService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public LabourService(IApplicationDbRepository _repo, IHttpContextAccessor _accessor)
        {
            repo = _repo;
            accessor = _accessor;
        }
        public async Task<bool> AddLabour(LabourViewModel model)
        {
            bool isDone = false;
            var farmer = GetFarmer();

            if (model != null)
            {
                Labour labour = new Labour()
                {
                    MotherId = model.MotherId,
                    Date = model.Date,
                    FatherId = model.FatherId,
                };

                await repo.AddAsync<Labour>(labour);
                isDone = true;
                repo.All<Animal>().Where(m=>m.Id == model.MotherId).FirstOrDefault().Labours.Add(labour);
            }

            await repo.SaveChangesAsync();
            return isDone;
        }

        public async Task DeleteLabour(Guid Id)
        {
            await repo.DeleteAsync<Labour>(Id);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> EditLabour(LabourViewModel model)
        {
            bool isDone = false;
            var labour = repo.All<Labour>().Where(p => p.Id == model.Id).FirstOrDefault();

            if (labour != null)
            {
                model.Date = labour.Date;
                model.FatherId = labour.FatherId;
                model.MotherId = labour.MotherId;


                await repo.SaveChangesAsync();
                isDone = true;
            }
            return isDone;
        }

        public ICollection<LabourShortViewModel> GetAllLabours()
        {
            var labours = repo.All<Labour>().ToList();
            var lb = new List<LabourShortViewModel>();
            foreach (var labour in labours)
            {
                LabourShortViewModel model = new LabourShortViewModel()
                {
                    Id = labour.Id,
                    Date = labour.Date,
                    MotherId = labour.MotherId,
                };

                lb.Add(model);

            }
            return lb;
        }

        public List<AnimalShortViewModel> GetFathers()
        {
            var dads = repo.All<Animal>().Where(f=>f.Sex==Infrastructure.Enums.Sex.Male).ToList();
            List<AnimalShortViewModel>fathers = new List<AnimalShortViewModel>();
            foreach (var item in dads)
            {
                AnimalShortViewModel father = new AnimalShortViewModel()
                {
                    Id = item.Id,
                    Sex = item.Sex,
                    AgeCategory = item.AgeCategory,
                    Breed = item.Breed,
                    Number = item.Number,
                };
                fathers.Add(father);
            }
            return fathers;
        }

        public LabourViewModel GetLabour(Guid Id)
        {
            var labour = repo.All<Labour>().Where(a => a.Id == Id).Include("Offsprings").FirstOrDefault();

            if (labour == null)
            {
                return null;
            }

            LabourViewModel model = new LabourViewModel()
            {
                Id = Id,
                Date = labour.Date,
                MotherId = labour.MotherId,
                FatherId = labour.FatherId,
            };

            var an = new List<AnimalShortViewModel>();

            foreach (var item in labour.Offsprings)
            {
                AnimalShortViewModel animal = new AnimalShortViewModel()
                {
                    Id = item.Id,
                    AgeCategory = item.AgeCategory,
                    Breed = item.Breed,
                    Number = item.Number,
                    Sex = item.Sex,
                };

                an.Add(animal);

            }

            model.Offsprings = an;

            return model;
        }

        public AnimalShortViewModel GetMother(Guid guid)
        {
            var mother = repo.All<Animal>().Where(m => m.Id == guid).FirstOrDefault();
            if(mother == null)
            {
                return null;
            }

            AnimalShortViewModel m = new AnimalShortViewModel()
            {
                Id = mother.Id,
                AgeCategory = mother.AgeCategory,
                Breed = mother.Breed,
                Number = mother.Number,
                Sex = mother.Sex,
            };

            return m;
        }

        private Farmer GetFarmer()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var farmer = repo.All<Farmer>().Where(f => f.UserId.Equals(userId)).FirstOrDefault();
            return farmer;
        }
    }
}

