using Joyle.BuildingBlocks.Domain;
using System;
using System.Threading.Tasks;

namespace Joyle.Games.Domain.Cardashians.Interfaces
{
    public interface ICardashianRepository : IRepository<Cardashian>
    {
        Task AddAsync(Cardashian cardashian);
        Task<Cardashian> FindAsync(Guid id);
        void Remove(Cardashian cardashian);
    }
}
