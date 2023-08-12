using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
