using NordicDoors.Models;
using System.Data;

namespace NordicDoors.Data
{
    public interface ISqlConnector
    {
        IDbConnection GetDbConnection();
    }
}
