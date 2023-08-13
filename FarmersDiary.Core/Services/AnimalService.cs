using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Services
{
    public class AnimalService : IAnimalService
    {
        public Task<bool> AddAnimal(AnimalViewModel model)
        {
            throw new NotImplementedException();
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

        public AnimalViewModel GetAnimal(string number)
        {
            throw new NotImplementedException();
        }
    }
}
