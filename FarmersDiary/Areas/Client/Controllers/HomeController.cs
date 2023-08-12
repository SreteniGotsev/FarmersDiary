using FarmersDiary.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IFarmService service;
        public HomeController(IFarmService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            var models = service.GetAllFarms();
            if(models == null)
            {
                return RedirectToAction("./FarmController/AddFarm");
            }
            return View(models);
        }
    }
}
