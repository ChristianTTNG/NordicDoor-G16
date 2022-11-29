using NordicDoorApplication.Models;

namespace NordicDoorApplication.Core.Interface
{
    public interface ITeamRepository
    {
        Team GetTeam(int id);
        List<Team> GetAllTeams();
        void AddTeam(Team team);
        void UpdateTeam(Team team);
        void RemoveTeam(int id);

        Task<bool> SaveChangesAsync();
    }
}
