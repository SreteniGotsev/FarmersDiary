using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class LandController : BaseController
    {
        private ILandService service;

        public LandController(ILandService _service)
        {
            this.service = _service;
        }

        public IActionResult Parcel(Guid Id)
        {
            var model = service.GetParcel(Id);
            return View(model);
        }
        public IActionResult AddParcel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddParcel(ParcelViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.AddParcel(model);
                return RedirectToAction("AllParcels");
            }
            return View();
        }


        public IActionResult EditParcel(Guid Id)
        {
            var model = service.GetParcel(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditParcel(ParcelViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.EditParcel(model);
                return RedirectToAction("Parcel", new { id = model.Id });
            }
            return View();
        }

        public async Task<IActionResult> DeleteParcel(Guid Id)
        {
            await service.DeleteParcel(Id);
            return RedirectToAction("AddParcel");
        }
        public IActionResult AllParcels()
        {
            var models = service.AllParcels();
            if (models == null)
            {
                return RedirectToAction("./ParcellController/AddParcel");
            }
            return View(models);
        }
    }
}
