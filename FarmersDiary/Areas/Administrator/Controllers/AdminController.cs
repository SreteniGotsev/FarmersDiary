using FarmersDiary.Core.Contracts;
using FarmersDiary.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Administrator.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAdminService service;
        public AdminController(IAdminService _service) { 
            service = _service;
        }
        public IActionResult Home()
        {
            var models = service.GetAll();
            return View(models);
        }
        public async Task<IActionResult> DeleteUser(string Id)
        {
           await service.DeleteUser(Id);
            return RedirectToAction("Home");
        }
    }
}
