using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NordicDoorApplication.Core;

namespace NordicDoorApplication.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = $"{Consts.Roles.Manager}")]
        public IActionResult Manager()
        {
            return View();
        }

        [Authorize(Roles = $"{Consts.Roles.Administrator}")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
