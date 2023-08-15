using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IFarmService service;
        private readonly ILandService lanservice;
        public HomeController(IFarmService _service, ILandService _lanservice)
        {
            service = _service;
            lanservice = _lanservice;
        }
        public IActionResult Index()
        {
            var farmModels = service.GetAllFarms();
            var landModels = lanservice.AllParcels();
            var homeObject = new HomeViewModel { farms=farmModels,parcels = landModels };

            return View( homeObject);
        }
    }
}
