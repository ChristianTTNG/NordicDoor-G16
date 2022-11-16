using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NordicDoors.Data;
using NordicDoors.Models;

namespace NordicDoors.Controllers
{
    public class TeamMembershipController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamMembershipController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeamMembership
        public async Task<IActionResult> Index()
        {
              return _context.TeamMembership != null ? 
                          View(await _context.TeamMembership.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TeamMembership'  is null.");
        }

        // GET: TeamMembership/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeamMembership == null)
            {
                return NotFound();
            }

            var teamMembership = await _context.TeamMembership
                .FirstOrDefaultAsync(m => m.TeamMembershipId == id);
            if (teamMembership == null)
            {
                return NotFound();
            }

            return View(teamMembership);
        }

        // GET: TeamMembership/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamMembership/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamMembershipID,TeamID,EmployeeID")] TeamMembership teamMembership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamMembership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamMembership);
        }

        // GET: TeamMembership/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeamMembership == null)
            {
                return NotFound();
            }

            var teamMembership = await _context.TeamMembership.FindAsync(id);
            if (teamMembership == null)
            {
                return NotFound();
            }
            return View(teamMembership);
        }

        // POST: TeamMembership/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamMembershipID,TeamID,EmployeeID")] TeamMembership teamMembership)
        {
            if (id != teamMembership.TeamMembershipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamMembership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamMembershipExists(teamMembership.TeamMembershipId))
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
            return View(teamMembership);
        }

        // GET: TeamMembership/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeamMembership == null)
            {
                return NotFound();
            }

            var teamMembership = await _context.TeamMembership
                .FirstOrDefaultAsync(m => m.TeamMembershipId == id);
            if (teamMembership == null)
            {
                return NotFound();
            }

            return View(teamMembership);
        }

        // POST: TeamMembership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeamMembership == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TeamMembership'  is null.");
            }
            var teamMembership = await _context.TeamMembership.FindAsync(id);
            if (teamMembership != null)
            {
                _context.TeamMembership.Remove(teamMembership);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamMembershipExists(int id)
        {
          return (_context.TeamMembership?.Any(e => e.TeamMembershipId == id)).GetValueOrDefault();
        }
    }
}
