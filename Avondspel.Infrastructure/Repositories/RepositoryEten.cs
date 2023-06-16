using Avondspel.Domain;
using Avondspel.Infrastructure.Data;
using Avondspel.Services.IRepositories;

namespace Avondspel.Infrastructure.Repositories
{
    public class RepositoryEten : IRepositoryEten
    {
        private AvondspelDbContext _dbContext;

        public RepositoryEten(AvondspelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Eten> GetEten()
        {
            return _dbContext.Eten.ToList();
        }

        public Eten? GetEtenById(int? id)
        {
            return _dbContext.Eten.Find(id);
        }
    }
}
