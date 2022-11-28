using System;
using System.Data;

namespace NordicDoorTestingrep.Data
{
    public interface ISqlConnector
    {
        IDbConnection GetDbConnection();
    }
}
