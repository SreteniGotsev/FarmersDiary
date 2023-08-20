using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using FarmersDiary.Core.Services;
using FarmersDiary.Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class FarmController : BaseController
    {

        private readonly IFarmService service;
        public FarmController(IFarmService _service)
        {
            service = _service;
        }
        public IActionResult AddFarm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFarm(FarmViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.AddFarm(model);
                return Redirect("/Client/");
            }
            return View();
        }

        public IActionResult Farm(Guid Id)
        {
            var model = service.GetFarm(Id);
            return View(model);
        }

        public IActionResult EditFarm(Guid Id)
        {
            var model = service.GetFarm(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditFarm(FarmViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.EditFarm(model);
                return RedirectToAction("Farm", new { id = model.Id });
            }
            return View();
        }

        public async Task<IActionResult> DeleteFarm(Guid Id)
        {
            await service.DeleteFarm(Id);
            return RedirectToAction("AddFarm");
        }
        public IActionResult AllFarms()
        {
            var models = service.GetAllFarms();
            if (models == null)
            {
                return RedirectToAction("./FarmController/AddFarm");
            }
            return View(models);
        }


    }
}
