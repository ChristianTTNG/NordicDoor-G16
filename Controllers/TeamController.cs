using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NordicDoorApplication.Areas.Identity.Data;
using NordicDoorApplication.Core.Interface;
using NordicDoorApplication.Core.Repository;
using NordicDoorApplication.Models;
using NordicDoorApplication.ViewModels;

namespace NordicDoorApplication.Controllers
{
    public class TeamController : Controller
    {
        private readonly ISuggestionRepository _sugRepo;
        private readonly ITeamRepository _teamRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public TeamController(ITeamRepository teamRepo, IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, ISuggestionRepository sugRepo)
        {
            _teamRepo = teamRepo;
            _sugRepo = sugRepo;
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _context = context;

        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(_teamRepo.GetAllTeams());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _teamRepo.GetTeam(id) == null)
            {
                return NotFound();
            }


            var Results = from e in _unitOfWork.User.GetUsers()
                          select new
                          {
                              e.EmployeeNumber,
                              e.EmpName,
                              Checked = ((from tm in _context.TeamsMembership
                                          where (tm.TeamID == id) & (tm.EmployeeNumber == e.EmployeeNumber)
                                          select tm).Count() > 0)
                          };

            var MyViewModel = new TeamViewModel();

            MyViewModel.TeamId = id;
            MyViewModel.TeamName = _teamRepo.GetTeam(id).TeamName;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.EmployeeNumber, Name = item.EmpName, Checked = item.Checked });
            }
            MyViewModel.TeamMedlemmer = MyCheckBoxList;

            return View(MyViewModel);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamID,TeamName")] Team team)
        {
            if (ModelState.IsValid)
            {
                _teamRepo.AddTeam(team);
                await _teamRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _teamRepo.GetTeam(id) == null)
            {
                return NotFound();
            }


            var Results = from e in _unitOfWork.User.GetUsers()
                          select new
                          {
                              e.EmployeeNumber,
                              e.EmpName,
                              Checked = ((from tm in _context.TeamsMembership
                                          where (tm.TeamID == id) & (tm.EmployeeNumber == e.EmployeeNumber)
                                          select tm).Count() > 0)
                          };

            var MyViewModel = new TeamViewModel();

            MyViewModel.TeamId = id;
            MyViewModel.TeamName = _teamRepo.GetTeam(id).TeamName;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.EmployeeNumber, Name = item.EmpName, Checked = item.Checked });
            }
            MyViewModel.TeamMedlemmer = MyCheckBoxList;


            return View(MyViewModel);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamViewModel team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var MyTeam = _teamRepo.GetTeam(id);

                    MyTeam.TeamName = team.TeamName;

                    foreach (var item in _context.TeamsMembership)
                    {
                        if (item.TeamID == team.TeamId)
                        {
                            _context.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    foreach (var item in team.TeamMedlemmer)
                    {
                        if (item.Checked)
                        {
                            _context.TeamsMembership.Add(new TeamMembership() { TeamID = team.TeamId, EmployeeNumber = item.Id });
                        }
                    }

                    await _teamRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var team = _teamRepo.GetTeam(id);
            if (id == null || team == null) 
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_teamRepo.GetTeam(id) == null)
            {
                return Problem("Entity set 'NordicDoorTestingrepContext.Team'  is null.");
            }

            {
                _teamRepo.RemoveTeam(id);
            }

            await _teamRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
