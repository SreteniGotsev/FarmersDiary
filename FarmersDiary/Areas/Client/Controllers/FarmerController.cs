using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class FarmerController : BaseController
    {
        private readonly IFarmerService service;
        public FarmerController(IFarmerService _service)
        {
            service = _service;
        }
        public IActionResult MyProfile()
        {
            var model = service.GetFarmer();
            if (model == null)
            {
                return RedirectToAction("AddProfile");
            }
            return View(model);
        }
        public IActionResult EditProfile()
        {
            var model = service.GetFarmer();
            if (model == null)
            {
                return RedirectToAction("EditProfile");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProfile(FarmerViewModel model)
        {
            if (ModelState.IsValid)
            {
                service.EditFarmer(model);
                return RedirectToAction("MyProfile");
            }
            return View();
        }
        public IActionResult AddProfile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProfile(FarmerViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.AddFarmer(model);
                return RedirectToAction("MyProfile");
            }
            return View();
        }
        public IActionResult DeleteProfile()
        {
            service.DeleteFarmer();
            return RedirectToAction("AddProfile");
        }
    }
}
