using System.Threading.Tasks;

namespace Joyle.BuildingBlocks.Domain
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
