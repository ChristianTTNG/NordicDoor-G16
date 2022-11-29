using NordicDoorApplication.Areas.Identity.Data;
using NordicDoorApplication.Models;

namespace NordicDoorApplication.Core.Interface
{
    public class TeamRepository : ITeamRepository
    {
        private ApplicationDbContext _TeamCtx;
        public TeamRepository(ApplicationDbContext ctx)
        {
            _TeamCtx = ctx;
        }
        public void AddTeam(Team team)
        {
            _TeamCtx.Teams.Add(team);
        }

        public List<Team> GetAllTeams()
        {
            return _TeamCtx.Teams.ToList();
        }

        public Team GetTeam(int id)
        {
            return _TeamCtx.Teams.FirstOrDefault(t => t.TeamId == id);
        }

        public void RemoveTeam(int id)
        {
            _TeamCtx.Teams.Remove(GetTeam(id));
        }
        public void UpdateTeam(Team team)
        {
            _TeamCtx.Teams.Update(team);
        }



        public async Task<bool> SaveChangesAsync()
        {
            if(await _TeamCtx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        
    }
}
