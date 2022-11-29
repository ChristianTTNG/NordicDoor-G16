using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NordicDoorApplication.Areas.Identity.Data;
using NordicDoorApplication.Core.Interface;
using NordicDoorApplication.Models;

namespace NordicDoorApplication.Controllers
{
    public class SuggestionController : Controller
    {
        private readonly ISuggestionRepository _sugRepo;
        private readonly ITeamRepository _teamRepo;


        public SuggestionController(ISuggestionRepository sugRepo, ITeamRepository teamRepo)
        {
            _sugRepo = sugRepo;
            _teamRepo = teamRepo;
        }

        // GET: Suggestion
        public async Task<IActionResult> Index()
        {
            var result = _sugRepo.GetAllSuggestions();

            return View(result);
        }

        // GET: Suggestion/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _sugRepo.GetSuggestion(id) == null)
            {
                return NotFound();
            }
            return View(_sugRepo.GetSuggestion(id));
        }

        // GET: Suggestion/Create
        public IActionResult Create()
        {
            ViewData["Teams"] = _teamRepo.GetAllTeams();
            return View();
        }

        // POST: Suggestion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuggestionId,SugName,TeamID,SugCreatorID,ResponsibleEmployeeID,SugDescription,SugCategory,JDISug,progress,SugStatus,RegisteredDate,CompletedOrDueDate")] Suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                _sugRepo.AddSuggestion(suggestion);
                await _sugRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Teams"] = _teamRepo.GetAllTeams();

            return View(suggestion);
        }

        // GET: Suggestion/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _sugRepo.GetSuggestion(id) == null)
            {
                return NotFound();
            }

            ViewData["Teams"] = _teamRepo.GetAllTeams();

            return View(_sugRepo.GetSuggestion(id));
        }

        // POST: Suggestion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuggestionId,SugName,TeamID,SugCreatorID,ResponsibleEmployeeID,SugDescription,SugCategory,JDISug,progress,SugStatus,RegisteredDate,CompletedOrDueDate")] Suggestion suggestion)
        {
            if (id != suggestion.SuggestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _sugRepo.UpdateSuggestion(suggestion);
                    await _sugRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuggestionExists(id))
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
            ViewData["Teams"] = _teamRepo.GetAllTeams();
            return View(suggestion);
        }

        // GET: Suggestion/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var sug = _sugRepo.GetSuggestion(id);
            if (id == null || sug == null)
            {
                return NotFound();
            }

            return View(sug);
        }

        // POST: Suggestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sug = _sugRepo.GetSuggestion(id);
            if (sug == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Suggestion' is null.");
            }
            
            _sugRepo.RemoveSuggestion(id);
            
            await _sugRepo.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SuggestionExists(int id)
        {
          return _sugRepo.CheckSuggestion(id);
        }
    }
}
