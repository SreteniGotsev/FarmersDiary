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
        Task<Guid> AddAnimal(Guid Id,AnimalViewModel model );
        AnimalViewModel GetAnimal(Guid number);
        ICollection<AnimalShortViewModel> GetAllAnimals();
        Task EditAnimal(AnimalViewModel model);
        Task DeleteAnimal(Guid Id);
    }
}
