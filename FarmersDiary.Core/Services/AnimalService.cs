using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Data.Repositories;
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
        public async Task<bool> AddAnimal(Guid id, AnimalViewModel model)
        {
            bool isSuccess = false;
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
                isSuccess = true;
            }

            return isSuccess;
        }



        public void DeleteAnimal(string number)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAnimal(AnimalViewModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<AnimalShortViewModel> GetAllAnimals()
        {
            throw new NotImplementedException();
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
                    Mother= item.Mother
                };
                lb.Add(labour);

            }
            model.Labours= lb;

            return model;
        }
    }
}
