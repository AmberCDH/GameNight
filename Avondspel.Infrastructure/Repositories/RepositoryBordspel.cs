using Avondspel.Domain;
using Avondspel.Infrastructure.Data;
using Avondspel.Services.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Avondspel.Infrastructure.Repository
{
    public class RepositoryBordspel : IRepositoryBordspellen, IDisposable
    {
        private AvondspelDbContext _dbContext;

        public RepositoryBordspel(AvondspelDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void DeleteBordspel(int id)
        {
            try
            {
                Bordspel? bordspel = _dbContext.Bordspellen.Find(id);
                if (bordspel != null)
                {
                    _dbContext.Bordspellen.Remove(bordspel);
                }

            }
            catch
            {
                throw new NullReferenceException();
            }

        }

        public Bordspel? GetBordspelById(int? id)
        {
            return _dbContext.Bordspellen.Find(id);
        }

        public IEnumerable<Bordspel> GetBordspellen()
        {
            return _dbContext.Bordspellen.ToList();
        }

        public void InsertBordspel(Bordspel bordspel)
        {
            _dbContext.Bordspellen.Add(bordspel);
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBordspel(Bordspel bordspel)
        {
            _dbContext.Entry(bordspel).State = EntityState.Modified;
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
