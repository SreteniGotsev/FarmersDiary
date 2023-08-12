using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class LandController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
