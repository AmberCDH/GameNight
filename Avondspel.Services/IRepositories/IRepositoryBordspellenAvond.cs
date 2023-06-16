using Avondspel.Domain;

namespace Avondspel.Services.IRepositories
{
    public interface IRepositoryBordspellenAvond
    {
        IEnumerable<BordspellenAvond> GetBordspellenAvonden(Gebruiker gebruiker);
        IEnumerable<BordspellenAvond>? GetBordspellenAvondByUser(string? id);
        BordspellenAvond? GetBordspellenAvondById(int? id);
        public IEnumerable<BordspellenAvond>? GetBordspellenAvondMetGebruiker(int gebruikerId);
        BordspellenAvond InsertGebruikerInAvond(Gebruiker gebruiker, int avondId);
        bool InsertEtenInAvond(Eten eten, int avondId);
        BordspellenAvond InsertBordspellenAvond(BordspellenAvond bordspellenAvond);
        bool DeleteBordspellenAvond(int id);
        BordspellenAvond UpdateBordspellenAvond(BordspellenAvond bordspellenAvond);
        void save();
        void Dispose();
    }
}
