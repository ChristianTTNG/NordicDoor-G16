using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NordicDoorTestingrep.Data;
using NordicDoorTestingrep.Models;

namespace NordicDoorTestingrep.Controllers
{
    public class TeamsController : Controller
    {
        private readonly NordicDoorTestingrepContext _context;

        public TeamsController(NordicDoorTestingrepContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
              return View(await _context.Team.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.TeamID == id);
            if (team == null)
            {
                return NotFound();
            }

            var Results = from e in _context.Employee
                          select new
                          {
                              e.EmployeeId,
                              e.EmpName,
                              Checked = ((from tm in _context.TeamMembership
                                          where (tm.TeamID == id) & (tm.EmployeeID == e.EmployeeId)
                                          select tm).Count() > 0)
                          };

            var MyViewModel = new TeamViewModel();

            MyViewModel.TeamID = id.Value;
            MyViewModel.TeamName = team.TeamName;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.EmployeeId, Name = item.EmpName, Checked = item.Checked });
            }
            MyViewModel.Employees = MyCheckBoxList;

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
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            var Results = from e in _context.Employee
                          select new
                          {
                              e.EmployeeId,
                              e.EmpName,
                              Checked = ((from tm in _context.TeamMembership
                                          where (tm.TeamID == id) & (tm.EmployeeID == e.EmployeeId)
                                          select tm).Count() > 0)
                          };

            var MyViewModel = new TeamViewModel();

            MyViewModel.TeamID = id.Value;
            MyViewModel.TeamName = team.TeamName;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.EmployeeId, Name = item.EmpName, Checked = item.Checked });
            }
            MyViewModel.Employees = MyCheckBoxList;

            return View(MyViewModel);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamViewModel team)
        {
            if (id != team.TeamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var MyTeam = _context.Team.Find(team.TeamID);

                    MyTeam.TeamName = team.TeamName;

                    foreach (var item in _context.TeamMembership)
                    {
                        if (item.TeamID == team.TeamID)
                        {
                            _context.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    foreach (var item in team.Employees)
                    {
                        if (item.Checked)
                        {
                            _context.TeamMembership.Add(new TeamMembership() { TeamID = team.TeamID, EmployeeID= item.Id });
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.TeamID == id);
            if (team == null)
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
            if (_context.Team == null)
            {
                return Problem("Entity set 'NordicDoorTestingrepContext.Team'  is null.");
            }
            var team = await _context.Team.FindAsync(id);
            if (team != null)
            {
                _context.Team.Remove(team);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
          return _context.Team.Any(e => e.TeamID == id);
        }
    }
}
