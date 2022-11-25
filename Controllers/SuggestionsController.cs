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
    public class SuggestionsController : Controller
    {
        private readonly NordicDoorTestingrepContext _context;

        public SuggestionsController(NordicDoorTestingrepContext context)
        {
            _context = context;
        }

        // GET: Suggestions
        public async Task<IActionResult> Index(DateTime? Time, Employee? RespEmp, Team? Team)
        {
            var nordicDoorContext = _context.Suggestion.Include(s => s.ResponsibleEmployee).Include(s => s.SugCreator).Include(s => s.Team);

            /*if (Time.HasValue)
                nordicDoorContext = nordicDoorContext.Where(x => x.RegisteredDate > Time);
            if (RespEmp != null)
                nordicDoorContext = nordicDoorContext.Where(x => x.ResponsibleEmployeeID == RespEmp.EmployeeId);
            if (Team != null)
                nordicDoorContext = nordicDoorContext.Where(x => x.TeamID == Team.TeamID);*/




            return View(await nordicDoorContext.ToListAsync());
        }

        // GET: Suggestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Suggestion == null)
            {
                return NotFound();
            }

            var suggestion = await _context.Suggestion
                .Include(s => s.ResponsibleEmployee)
                .Include(s => s.SugCreator)
                .Include(s => s.Team)
                .FirstOrDefaultAsync(m => m.SuggestionId == id);
            if (suggestion == null)
            {
                return NotFound();
            }
            /*var attachments = (from s in _context.Suggestion
                               where (s.SuggestionId == id)
                               select s.Attachments);

            


            var NewSuggestionView = new CreateSuggestionViewModel();


            NewSuggestionView.SuggestionId = id.Value;
            NewSuggestionView.SugName = suggestion.SugName;
            NewSuggestionView.TeamID = suggestion.TeamID;
            NewSuggestionView.SugCreatorID = suggestion.SugCreatorID;
            NewSuggestionView.ResponsibleEmployeeID = suggestion.ResponsibleEmployeeID;
            NewSuggestionView.SugDescription = suggestion.SugDescription;
            NewSuggestionView.SugCategory = suggestion.SugCategory;
            NewSuggestionView.JDISug = suggestion.JDISug;
            NewSuggestionView.progress = suggestion.progress;
            NewSuggestionView.SugStatus = suggestion.SugStatus;

            /*if (suggestion.Attachments.Length > 0 || suggestion.Attachments != null)
            {
                NewSuggestionView.Attachments = Convert.ToBase64String(suggestion.Attachments);
            };
            */

            //return View(NewSuggestionView);
            return View(suggestion);
        }

        // GET: Suggestions/Create
        public IActionResult Create()
        {
            ViewData["ResponsibleEmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            ViewData["SugCreatorID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "TeamID");
            return View();
        }

        // POST: Suggestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuggestionId,SugName,SugDescription,SugCategory,JDISug,progress,SugStatus,RegisteredDate,CompletedOrDueDate,SugCreatorID,ResponsibleEmployeeID,TeamID")] Suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                

                /*var uploadedAttachment = Array.Empty<byte>();
                 

                if (suggestion.Attachments != null && suggestion.Attachments.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        suggestion.Attachments.CopyTo(memoryStream);
                        uploadedAttachment = memoryStream.ToArray();
                    }
                }*/

                _context.Add(suggestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["ResponsibleEmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", suggestion.ResponsibleEmployeeID);
            ViewData["SugCreatorID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", suggestion.SugCreatorID);
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "TeamID", suggestion.TeamID);

            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            return View(suggestion);
        }

        // GET: Suggestions/Edit/5
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
            ViewData["ResponsibleEmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", suggestion.ResponsibleEmployeeID);
            ViewData["SugCreatorID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", suggestion.SugCreatorID);
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "TeamID", suggestion.TeamID);
            return View(suggestion);
        }

        // POST: Suggestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuggestionId,SugName,SugDescription,SugCategory,JDISug,progress,SugStatus,RegisteredDate,CompletedOrDueDate,SugCreatorID,ResponsibleEmployeeID,TeamID")] Suggestion suggestion)
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
            ViewData["ResponsibleEmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", suggestion.ResponsibleEmployeeID);
            ViewData["SugCreatorID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", suggestion.SugCreatorID);
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "TeamID", suggestion.TeamID);
            return View(suggestion);
        }

        // GET: Suggestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Suggestion == null)
            {
                return NotFound();
            }

            var suggestion = await _context.Suggestion
                .Include(s => s.ResponsibleEmployee)
                .Include(s => s.SugCreator)
                .Include(s => s.Team)
                .FirstOrDefaultAsync(m => m.SuggestionId == id);
            if (suggestion == null)
            {
                return NotFound();
            }

            return View(suggestion);
        }

        // POST: Suggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Suggestion == null)
            {
                return Problem("Entity set 'NordicDoorTestingrepContext.Suggestion'  is null.");
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
          return _context.Suggestion.Any(e => e.SuggestionId == id);
        }
    }
}
