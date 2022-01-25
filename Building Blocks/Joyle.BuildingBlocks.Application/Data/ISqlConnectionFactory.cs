using System.Data;

namespace Joyle.BuildingBlocks.Application.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
