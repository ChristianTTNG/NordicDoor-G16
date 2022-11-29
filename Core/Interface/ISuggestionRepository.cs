using NordicDoorApplication.Models;

namespace NordicDoorApplication.Core.Interface
{
    public interface ISuggestionRepository
    {
        Suggestion GetSuggestion(int id);
        List<Suggestion> GetAllSuggestions();
        void AddSuggestion(Suggestion suggestion);
        void UpdateSuggestion(Suggestion suggestion);
        void RemoveSuggestion(int id);
        bool CheckSuggestion(int id);


        Task<bool> SaveChangesAsync();
    }
}
