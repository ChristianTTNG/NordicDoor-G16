using Microsoft.AspNetCore.Identity;

namespace NordicDoorApplication.Core.Interface
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
