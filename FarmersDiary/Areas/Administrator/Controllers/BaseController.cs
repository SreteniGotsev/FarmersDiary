using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Administrator.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Administrator")]
    public class BaseController : Controller
    {

    }
}
