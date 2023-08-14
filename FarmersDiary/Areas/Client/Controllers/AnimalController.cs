using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class AnimalController : BaseController
    {
        private IAnimalService service;
        
        public AnimalController(IAnimalService _service)
        {
            this.service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddAnimal(Guid Id)
        {
            return View(Id);
        }
        [HttpPost]
        public async Task<IActionResult> AddAnimal(Guid Id, AnimalViewModel model)
        {
            await service.AddAnimal(Id,model);
            return RedirectToAction("/");
        }
    }
}
