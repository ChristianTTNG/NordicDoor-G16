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
    public class EmployeesController : Controller
    {
        private readonly NordicDoorTestingrepContext _context;

        public EmployeesController(NordicDoorTestingrepContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
              return View(await _context.Employee.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            var Results = from t in _context.Team
                          select new
                          {
                              t.TeamID,
                              t.TeamName,
                              Checked = ((from tm in _context.TeamMembership
                                          where (tm.EmployeeID == id) & (tm.TeamID == t.TeamID)
                                          select tm).Count() > 0)
                          };

            var MyViewModel = new EmployeeViewModel();

            MyViewModel.EmployeeId = id.Value;
            MyViewModel.EmpName = employee.EmpName;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.TeamID, Name = item.TeamName, Checked = item.Checked });
            }
            MyViewModel.Teams = MyCheckBoxList;

            return View(MyViewModel);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmpName,IsAdmin")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var Results = from t in _context.Team
                          select new
                          {
                              t.TeamID,
                              t.TeamName,
                              Checked = ((from tm in _context.TeamMembership
                                          where (tm.EmployeeID == id) & (tm.TeamID == t.TeamID)
                                          select tm).Count() > 0)
                          };

            var MyViewModel = new EmployeeViewModel();

            MyViewModel.EmployeeId = id.Value;
            MyViewModel.EmpName = employee.EmpName;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.TeamID, Name = item.TeamName, Checked = item.Checked });
            }
            MyViewModel.Teams= MyCheckBoxList;

            return View(MyViewModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var MyEmployee = _context.Employee.Find(employee.EmployeeId);

                    MyEmployee.EmpName = employee.EmpName;
                    MyEmployee.IsAdmin = employee.IsAdmin;

                    foreach (var item in _context.TeamMembership)
                    {
                        if (item.EmployeeID == employee.EmployeeId)
                        {
                            _context.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    foreach (var item in employee.Teams)
                    {
                        if (item.Checked)
                        {
                            _context.TeamMembership.Add(new TeamMembership() { EmployeeID = employee.EmployeeId, TeamID = item.Id});
                        }
                    }
                      
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'NordicDoorTestingrepContext.Employee'  is null.");
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
