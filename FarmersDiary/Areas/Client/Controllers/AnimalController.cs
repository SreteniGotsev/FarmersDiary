using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class AnimalController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddAnimal()
        {
            return View();
        }
    }
}
