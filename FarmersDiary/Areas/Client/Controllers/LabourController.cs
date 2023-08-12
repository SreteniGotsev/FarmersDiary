using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    public class LabourController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
