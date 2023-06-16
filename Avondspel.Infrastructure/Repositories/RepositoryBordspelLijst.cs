using Avondspel.Domain;
using Avondspel.Infrastructure.Data;
using Avondspel.Services.IRepositories;

namespace Avondspel.Infrastructure.Repositories
{
    public class RepositoryBordspelLijst : IRepositoryBordspelLijst
    {
        private AvondspelDbContext _dbContext;
        public RepositoryBordspelLijst(AvondspelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteUitLijst(int bordspelId, int spelavondId)
        {
            try
            {
                BordspellenLijst? lijst = _dbContext.BordspellenLijst.Where(x => x.BordspelId.Equals(bordspelId) && x.SpelAvondId.Equals(spelavondId)).FirstOrDefault();
                if (lijst != null)
                {
                    _dbContext.Remove(lijst);
                    save();
                }
            }
            catch
            {
                throw new NullReferenceException();
            }
        }

        public IEnumerable<BordspellenLijst>? GetBordspellenLijstByAvond(int? AvondId)
        {
            return _dbContext.BordspellenLijst.ToList().Where(a => a.SpelAvondId == AvondId);
        }

        public void InsertInLijst(BordspellenLijst BLijst)
        {
            _dbContext.BordspellenLijst.Add(BLijst);
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
