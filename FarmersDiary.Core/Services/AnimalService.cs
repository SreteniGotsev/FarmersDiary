using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Data.Repositories;
using FarmersDiary.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IApplicationDbRepository repo;
        public AnimalService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<Guid> AddAnimal(Guid id, AnimalViewModel model)
        {
            var Animalid = Guid.Empty;
            var farm = repo.All<Farm>().Where(f=>f.Id == id).FirstOrDefault();
            if (model != null)
            {
                Animal animal = new Animal()
                {
                    Number = model.Number,
                    Breed = model.Breed,
                    AgeCategory = model.AgeCategory,
                    DOB = model.DOB,
                    Sex = model.Sex,
                    FarmId = farm.Id,
                    Farm = farm
                };

                farm.Animals.Add(animal);
                await repo.AddAsync<Animal>(animal);
                await repo.SaveChangesAsync();
                Animalid = animal.Id;
            }

            return Animalid;
        }

        public async Task DeleteAnimal(Guid Id)
        {
            await repo.DeleteAsync<Animal>(Id);
            await repo.SaveChangesAsync();
        }

        public async Task EditAnimal(AnimalViewModel model)
        {
            var animal = repo.All<Animal>().Where(a=>a.Id==model.Id).FirstOrDefault();

            if (animal != null)
            {
                animal.Number = model.Number;
                animal.Breed = model.Breed;
                animal.AgeCategory = model.AgeCategory;
                animal.DOB = model.DOB;
                animal.Sex = model.Sex;
               
                await repo.SaveChangesAsync();
            }

        }

        public ICollection<AnimalShortViewModel> GetAllAnimals()
        {

            var animals = repo.All<Animal>().ToList();
            var an = new List<AnimalShortViewModel>();
            foreach (var animal in animals)
            {
                AnimalShortViewModel model = new AnimalShortViewModel()
                {
                    Id = animal.Id,
                    AgeCategory= animal.AgeCategory,
                    Number= animal.Number,
                    Breed= animal.Breed,
                    Sex= animal.Sex
                };

                an.Add(model);

            }
            return an;
        }

        public AnimalViewModel GetAnimal(Guid Id)
        {
            var animal = repo.All<Animal>().Where(a=>a.Id == Id).Include("Labours").FirstOrDefault();

            if (animal == null)
            {
                return null;
            }

            AnimalViewModel model = new AnimalViewModel() {
                Id = Id,
                AgeCategory = animal.AgeCategory,
                DOB = animal.DOB,
                Sex = animal.Sex,
                Breed= animal.Breed,
                Number= animal.Number,
                FarmId= animal.FarmId
            };
            var lb = new List<LabourShortViewModel>();
            foreach (var item in animal.Labours)
            {
                LabourShortViewModel labour = new LabourShortViewModel()
                {
                    Id= item.Id,
                    Date= item.Date,
                    MotherId= item.MotherId,
                };
                lb.Add(labour);

            }
            model.Labours= lb;

            return model;
        }
    }
}
