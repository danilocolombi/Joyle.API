using Joyle.BuildingBlocks.Domain;
using Joyle.Games.Domain.Cardashians;
using Joyle.Games.Domain.Cardashians.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Joyle.Games.Infra.Data.Cardashians
{
    public class CardashianRepository : ICardashianRepository
    {
        private readonly GamesContext _context;

        public CardashianRepository(GamesContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task AddAsync(Cardashian cardashian)
        {
            await _context.Cardashians.AddAsync(cardashian);
        }

        public async Task<Cardashian> FindAsync(Guid id)
        {
            return await _context.Cardashians.Include(c => c.Cards)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(Cardashian cardashian)
        {
            _context.Cardashians.Remove(cardashian);
        }
    }
}
