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

        public IActionResult Animal(Guid Id)
        {
            var model = service.GetAnimal(Id);
            return View(model);
        }
        public IActionResult AddAnimal(Guid Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAnimal(Guid Id, AnimalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var id = await service.AddAnimal(Id, model);
                return RedirectToAction("Animal", new { Id = id });
            }
            return View();
        }


        public IActionResult EditAnimal(Guid Id)
        {
            var model = service.GetAnimal(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAnimal(AnimalViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.EditAnimal(model);
                return RedirectToAction("Animal", new { id = model.Id });
            }
            return View();
        }

        public async Task<IActionResult> DeleteAnimal(Guid Id)
        {
            await service.DeleteAnimal(Id);
            return RedirectToAction("AddAnimal");
        }
        public IActionResult AllAnimals()
        {
            var models = service.GetAllAnimals();
            if (models == null)
            {
                return RedirectToAction("./AnimalController/AddAnimal");
            }
            return View(models);
        }

    }
}
