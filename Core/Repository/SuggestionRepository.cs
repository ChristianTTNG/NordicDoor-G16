using NordicDoorApplication.Areas.Identity.Data;
using NordicDoorApplication.Models;
using NuGet.Protocol.Core.Types;

namespace NordicDoorApplication.Core.Interface
{
    public class SuggestionRepository : ISuggestionRepository
    {
        private ApplicationDbContext _SugCtx;

        public SuggestionRepository(ApplicationDbContext ctx)
        {
            _SugCtx = ctx;
        }

        public void AddSuggestion(Suggestion suggestion)
        {
            _SugCtx.Suggestions.Add(suggestion);
        }

        public List<Suggestion> GetAllSuggestions()
        {
            return _SugCtx.Suggestions.ToList();
        }

        public Suggestion GetSuggestion(int id)
        {
            return _SugCtx.Suggestions.FirstOrDefault(s => s.SuggestionId == id);
        }

        public void RemoveSuggestion(int id)
        {
            _SugCtx.Suggestions.Remove(GetSuggestion(id));
        }

        public void UpdateSuggestion(Suggestion suggestion)
        {
            _SugCtx.Suggestions.Update(suggestion);
        }

        public bool CheckSuggestion(int id)
        {
            if (_SugCtx.Suggestions.Any(e => e.SuggestionId == id))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SaveChangesAsync()
        {
            if(await _SugCtx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        
    }
}
