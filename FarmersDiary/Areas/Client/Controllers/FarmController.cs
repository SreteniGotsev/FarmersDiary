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
            await service.AddFarm(model);
            return Redirect("/Client/");
        }

        public IActionResult Index(AnimalCategory category)
        {
            var model = service.GetFarm(category);
            return View(model);
        }

        public IActionResult EditFarm(AnimalCategory category)
        {
            var model = service.GetFarm(category);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditFarm(FarmViewModel model)
        {
            service.EditFarm(model);
            return RedirectToAction("GetFarm");
        }

        public IActionResult DeleteFarm(AnimalCategory category)
        {
            service.DeleteFarm(category);
            return RedirectToAction("AddFarm");
        }


    }
}
