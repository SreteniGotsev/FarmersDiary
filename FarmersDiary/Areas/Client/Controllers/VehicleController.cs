using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class VehicleController : BaseController
    {
        private IVehicleService service;

        public VehicleController(IVehicleService _service)
        {
            this.service = _service;
        }

        public IActionResult Vehicle(Guid Id)
        {
            var model = service.GetVehicle(Id);
            return View(model);
        }
        public IActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVehicle(VehicleViewModel model)
        {
            await service.AddVehicle(model);
            return RedirectToAction("AllVehicles");
        }


        public IActionResult EditVehicle(Guid Id)
        {
            var model = service.GetVehicle(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditVehicle(VehicleViewModel model)
        {
            await service.EditVehicle(model);
            return RedirectToAction("Vehicle", new { id = model.Id });
        }

        public async Task<IActionResult> DeleteVehicle(Guid Id)
        {
            await service.DeleteVehicle(Id);
            return RedirectToAction("AddVehicle");
        }
        public IActionResult AllVehicles()
        {
            var models = service.AllVehicles();
            if (models == null)
            {
                return RedirectToAction("./VehicleController/AddVehicle");
            }
            return View(models);
        }
    }
}
