using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NordicDoorTestingrep.Data;
using NordicDoorTestingrep.Models;
using System.Diagnostics;



namespace NordicDoorTestingrep.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NordicDoorTestingrepContext _context;

        
        public HomeController(ILogger<HomeController> logger, NordicDoorTestingrepContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var nordicDoorContext = _context.Suggestion.Include(s => s.ResponsibleEmployee).Include(s => s.SugCreator).Include(s => s.Team);
            return View(await nordicDoorContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 