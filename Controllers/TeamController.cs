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
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;  // Deklarerer en variabel "_context" av typen (klassen) "ApplicationDbContext", som ligger i "Data" mappen vår

        public TeamController(ApplicationDbContext context)  // Sender inn parameter "context"
        {
            _context = context;   // sier at variabel / field / attributt "_context"  =  parameteren vår "context" 
        }

        // GET: Team
        public async Task<IActionResult> Index() // Index er hovedsiden, eller default, av urlen
        {
              return _context.Team != null ?       // Her er en conditional operator, som gjører koden under    (  Condition ?   run if true  :  run if false  ) 
                          View(await _context.Team.ToListAsync()) :      // gjør denne linja "if true ^".  Await gjør at den venter til "_context.Team.ToListAsync()" er ferdig med å hente alle instances i tabellen/entiteten vår "Team" før den sender tilbake view "return View()"
                          Problem("Entity set 'ApplicationDbContext.Team' is null.");   // Returnerer en respons
        }

        // GET: Team/Details/5
        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null || _context.Team == null)  // hvis parameter "id" eller "_context.Team" er NULL --> kjør kode under
            {
                return NotFound();
            }

            var team = await _context.Team      // venter på linja under er ferdig (går igjennom liste med "TeamID" til den finner en som er lik "id" parameteret)
                .FirstOrDefaultAsync(m => m.TeamID == id);
            if (team == null)       
            {
                return NotFound();
            }

            return View(team);      // returnerer View    (Team/Details/5)
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
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

        // GET: Team/Edit/5
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
            return View(team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamName")] Team team)
        {
            if (id != team.TeamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
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

        // GET: Team/Delete/5
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

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Team == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Team'  is null.");
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
          return (_context.Team?.Any(e => e.TeamID == id)).GetValueOrDefault();
        }
    }
}
