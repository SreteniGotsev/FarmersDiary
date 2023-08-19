﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersDiary.Areas.Client.Controllers
{
    [Authorize(Roles = "User")]
    [Area("Client")]
    public class BaseController : Controller
    {

    }
}
