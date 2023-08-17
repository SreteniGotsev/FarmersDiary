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
        public IActionResult AddLabour()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddLabour(LabourViewModel model)
        {
            await service.AddLabour(model);
            return RedirectToAction("AllLabours");
        }


        public IActionResult EditLabour(Guid Id)
        {
            var model = service.GetLabour(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditVehicle(LabourViewModel model)
        {
            await service.EditLabour(model);
            return RedirectToAction("Labour", new { id = model.Id });
        }

        public async Task<IActionResult> DeleteVehicle(Guid Id)
        {
            await service.DeleteLabour(Id);
            return RedirectToAction("AddLabour");
        }
        public IActionResult AllVehicles()
        {
            var models = service.AllLabours();
            if (models == null)
            {
                return RedirectToAction("AddLabour");
            }
            return View(models);
        }
    }
}
