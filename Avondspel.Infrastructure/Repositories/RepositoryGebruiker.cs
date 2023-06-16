using Avondspel.Domain;
using Avondspel.Infrastructure.Data;
using Avondspel.Services.IRepositories;

namespace Avondspel.Infrastructure.Repositories
{
    public class RepositoryGebruiker : IRepositoryGebruiker
    {
        private AvondspelDbContext _dbContext;

        public RepositoryGebruiker(AvondspelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Gebruiker GetGebruikerByEmail(string email)
        {
            try
            {
                var gebruiker = _dbContext.Gebruiker.Where(g => g.Email.Equals(email)).Single();
                return gebruiker;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }

        }

        public void InsertGebruiker(Gebruiker gebruiker)
        {
            _dbContext.Gebruiker.Add(gebruiker);
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
