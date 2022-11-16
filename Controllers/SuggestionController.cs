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
    public class SuggestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuggestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suggestion
        public async Task<IActionResult> Index()
        {
            return _context.Suggestion != null ? 
                        View(await _context.Suggestion.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Suggestion'  is null.");
        }

        // GET: Suggestion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Suggestion == null)
            {
                return NotFound();
            }

            var suggestion = await _context.Suggestion
                .FirstOrDefaultAsync(m => m.SuggestionId == id);
            if (suggestion == null)
            {
                return NotFound();
            }

            return View(suggestion);
        }

        // GET: Suggestion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suggestion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuggestionID,SugName,Description,RegisteredDate,CompletedDate,SugCategory,EmployeeID,ResponsibleEmp,TeamID,DueDate,SugStatus,IsJDI")] Suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suggestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suggestion);
        }

        // GET: Suggestion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Suggestion == null)
            {
                return NotFound();
            }

            var suggestion = await _context.Suggestion.FindAsync(id);
            if (suggestion == null)
            {
                return NotFound();
            }
            return View(suggestion);
        }

        // POST: Suggestion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuggestionID,SugName,Description,RegisteredDate,CompletedDate,SugCategory,EmployeeID,ResponsibleEmp,TeamID,DueDate,SugStatus,IsJDI")] Suggestion suggestion)
        {
            if (id != suggestion.SuggestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suggestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuggestionExists(suggestion.SuggestionId))
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
            return View(suggestion);
        }

        // GET: Suggestion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Suggestion == null)
            {
                return NotFound();
            }

            var suggestion = await _context.Suggestion
                .FirstOrDefaultAsync(m => m.SuggestionId == id);
            if (suggestion == null)
            {
                return NotFound();
            }

            return View(suggestion);
        }

        // POST: Suggestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Suggestion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Suggestion'  is null.");
            }
            var suggestion = await _context.Suggestion.FindAsync(id);
            if (suggestion != null)
            {
                _context.Suggestion.Remove(suggestion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuggestionExists(int id)
        {
          return (_context.Suggestion?.Any(e => e.SuggestionId== id)).GetValueOrDefault();
        }
    };  
}
