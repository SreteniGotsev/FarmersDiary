using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IFarmService service;
        private readonly ILandService lanservice;
        private readonly IVehicleService vehicleService;
        public HomeController(IFarmService _service, ILandService _lanservice,IVehicleService _vehicleService)
        {
            service = _service;
            lanservice = _lanservice;
            vehicleService= _vehicleService;
        }
        public IActionResult Index()
        {
            var farmModels = service.GetAllFarms();
            var landModels = lanservice.AllParcels();
            var vehicleModels = vehicleService.AllVehicles();
            var homeObject = new HomeViewModel { farms=farmModels,parcels = landModels, vehicles = vehicleModels };

            return View( homeObject);
        }
    }
}
