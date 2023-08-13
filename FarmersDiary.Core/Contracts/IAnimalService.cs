using FarmersDiary.Core.Models;
using FarmersDiary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersDiary.Core.Contracts
{
    public interface IAnimalService
    {
        Task<bool> AddAnimal(AnimalViewModel model);
        AnimalViewModel GetAnimal(string number);
        ICollection<AnimalShortViewModel> GetAllAnimals();
        Task<bool> EditAnimal(AnimalViewModel model);
        void DeleteAnimal(string number);
    }
}
