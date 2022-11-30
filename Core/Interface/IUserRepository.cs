using Microsoft.AspNetCore.Identity;
using NordicDoorApplication.Areas.Identity.Data;

namespace NordicDoorApplication.Core.Interface
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
