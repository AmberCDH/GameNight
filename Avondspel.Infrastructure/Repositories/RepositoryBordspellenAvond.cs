using Avondspel.Domain;
using Avondspel.Infrastructure.Data;
using Avondspel.Services.IRepositories;
using Microsoft.EntityFrameworkCore;
using static HotChocolate.ErrorCodes;

namespace Avondspel.Infrastructure.Repositories
{
    public class RepositoryBordspellenAvond : IRepositoryBordspellenAvond
    {
        private AvondspelDbContext _dbContext;
        public RepositoryBordspellenAvond(AvondspelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool DeleteBordspellenAvond(int id)
        {
            try
            {
                BordspellenAvond? bordspellenAvond = _dbContext.BordspellenAvond.Find(id);
                if (bordspellenAvond != null)
                {
                    _dbContext.BordspellenAvond.Remove(bordspellenAvond);
                    return true;
                }
                return false;
            }
            catch
            {
                throw new NullReferenceException();
            }
        }

        public BordspellenAvond? GetBordspellenAvondById(int? id)
        {
            var bordspellen = _dbContext.BordspellenAvond.Where(bs => bs.Id.Equals(id)).Include(bs => bs.EtenLijst).Include(bs => bs.Gebruikers).FirstOrDefault();
            return bordspellen;
        }

        public IEnumerable<BordspellenAvond> GetBordspellenAvonden(Gebruiker gebruiker)
        {
            if (gebruiker.OuderDanAchtien == false)
            {
                return _dbContext.BordspellenAvond.ToList().Where(a => a.AchtienPlus.Equals(gebruiker.OuderDanAchtien));
            }
            return _dbContext.BordspellenAvond.ToList();
        }

        public BordspellenAvond InsertBordspellenAvond(BordspellenAvond bordspellenAvond)
        {
            _dbContext.BordspellenAvond.Add(bordspellenAvond);
            _dbContext.SaveChanges();
            return bordspellenAvond;

        }

        public BordspellenAvond UpdateBordspellenAvond(BordspellenAvond bordspellenAvond)
        {
            _dbContext.Entry(bordspellenAvond).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return bordspellenAvond;
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

        public IEnumerable<BordspellenAvond>? GetBordspellenAvondByUser(string? id)
        {
            return _dbContext.BordspellenAvond.ToList().Where(b => b.GebruikerId == id);
        }

        public IEnumerable<BordspellenAvond>? GetBordspellenAvondMetGebruiker(int gebruikerId)
        {
            return _dbContext.BordspellenAvond.Where(g => g.Gebruikers.Any(g2 => g2.Id == gebruikerId));
        }

        public BordspellenAvond InsertGebruikerInAvond(Gebruiker gebruiker, int avondId)
        {
            BordspellenAvond bordspellenAvond = _dbContext.BordspellenAvond.Find(avondId);
            IEnumerable<BordspellenAvond>? bordspelAvondMetGebruiker = GetBordspellenAvondMetGebruiker(gebruiker.Id);
            if (bordspellenAvond != null)
            {
                if (bordspelAvondMetGebruiker.Any())
                {
                    if(bordspelAvondMetGebruiker.Where(datum => datum.Planning.Day == bordspellenAvond.Planning.Day && datum.Planning.Month == bordspellenAvond.Planning.Month && datum.Planning.Year == bordspellenAvond.Planning.Year).Any())
                    {
                        return null;
                    } else
                    {
                        if (!bordspellenAvond.Gebruikers.Contains(gebruiker))
                        {

                            bordspellenAvond.Gebruikers?.Add(gebruiker);
                            _dbContext.SaveChanges();
                            return bordspellenAvond;
                        }
                        return null;
                    }
                } else
                {
                    bordspellenAvond.Gebruikers?.Add(gebruiker);
                    _dbContext.SaveChanges();
                    return bordspellenAvond;
                }
            }
            return null;
        }

        public bool InsertEtenInAvond(Eten eten, int avondId)
        {
            BordspellenAvond bordspellenAvond = _dbContext.BordspellenAvond.Find(avondId);
            if (bordspellenAvond != null)
            {
                bordspellenAvond.EtenLijst?.Add(eten);
                return true;
            }
            return false;
        }
    }
}
