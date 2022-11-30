using Microsoft.AspNetCore.Identity;
using NordicDoorApplication.Areas.Identity.Data;
using NordicDoorApplication.Core.Interface;

namespace NordicDoorApplication.Core.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
