using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class LabourController : BaseController
    {
        private ILabourService service;

        public LabourController(ILabourService _service)
        {
            this.service = _service;
        }

        public IActionResult Labour(Guid Id)
        {
            var model = service.GetLabour(Id);
            return View(model);
        }
        public async Task<IActionResult> AddLabour(string motherId)
        {
            AnimalShortViewModel mother = service.GetMother(Guid.Parse(motherId));
            ViewBag.mother = mother;
            List<AnimalShortViewModel> fathers = service.GetFathers();
            return View(fathers);
        }
        [HttpPost]
        public async Task<IActionResult> AddLabour(LabourViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.AddLabour(model);
                return Redirect("../Animal/AllAnimals");
            }
            return View();
        }


        public IActionResult EditLabour(Guid Id)
        {
            var model = service.GetLabour(Id);
            var fathers = service.GetFathers();
            var mother = service.GetMother(model.MotherId);
            var validationModel = new LabourViewModel();
            ViewBag.fathers = fathers;
            ViewBag.validationModel = validationModel;
            ViewBag.mother = mother;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditLabour(LabourViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.EditLabour(model);
                return RedirectToAction("Labour", new { id = model.Id });
            }
            return View();
        }

        public async Task<IActionResult> DeleteLabour(Guid Id)
        {
            await service.DeleteLabour(Id);
            return Redirect("../Animal/AllAnimals");
        }
        public IActionResult AllLabours()
        {
            var models = service.GetAllLabours();
            if (models == null)
            {
                return RedirectToAction("AddLabour");
            }
            return View(models);
        }
    }
}
