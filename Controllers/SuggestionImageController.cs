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
    public class SuggestionImageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuggestionImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuggestionImage
        public async Task<IActionResult> Index()
        {
              return _context.SuggestionImage != null ? 
                          View(await _context.SuggestionImage.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SuggestionImage'  is null.");
        }

        // GET: SuggestionImage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SuggestionImage == null)
            {
                return NotFound();
            }

            var suggestionImage = await _context.SuggestionImage
                .FirstOrDefaultAsync(m => m.SuggestionImageID == id);
            if (suggestionImage == null)
            {
                return NotFound();
            }

            return View(suggestionImage);
        }

        // GET: SuggestionImage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuggestionImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuggestionImageID,ImageURL,SugState,SuggestionID")] SuggestionImage suggestionImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suggestionImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suggestionImage);
        }

        // GET: SuggestionImage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SuggestionImage == null)
            {
                return NotFound();
            }

            var suggestionImage = await _context.SuggestionImage.FindAsync(id);
            if (suggestionImage == null)
            {
                return NotFound();
            }
            return View(suggestionImage);
        }

        // POST: SuggestionImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuggestionImageID,ImageURL,SugState,SuggestionID")] SuggestionImage suggestionImage)
        {
            if (id != suggestionImage.SuggestionImageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suggestionImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuggestionImageExists(suggestionImage.SuggestionImageID))
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
            return View(suggestionImage);
        }

        // GET: SuggestionImage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SuggestionImage == null)
            {
                return NotFound();
            }

            var suggestionImage = await _context.SuggestionImage
                .FirstOrDefaultAsync(m => m.SuggestionImageID == id);
            if (suggestionImage == null)
            {
                return NotFound();
            }

            return View(suggestionImage);
        }

        // POST: SuggestionImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SuggestionImage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SuggestionImage'  is null.");
            }
            var suggestionImage = await _context.SuggestionImage.FindAsync(id);
            if (suggestionImage != null)
            {
                _context.SuggestionImage.Remove(suggestionImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuggestionImageExists(int id)
        {
          return (_context.SuggestionImage?.Any(e => e.SuggestionImageID == id)).GetValueOrDefault();
        }
    }
}
