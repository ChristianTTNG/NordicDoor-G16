using NordicDoorApplication.Core.Repository;

namespace NordicDoorApplication.Core.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

        IRoleRepository Role { get; }
    }
}
