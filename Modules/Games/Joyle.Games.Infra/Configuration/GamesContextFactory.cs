using Joyle.Games.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Joyle.Games.Infra.Configuration
{
    class GamesContextFactory : IDesignTimeDbContextFactory<GamesContext>
    {
        public GamesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GamesContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JoyleTeste;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new GamesContext(optionsBuilder.Options);
        }
    }
}
