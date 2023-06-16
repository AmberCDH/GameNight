using Avondspel.Domain;

namespace Avondspel.Services.IRepositories
{
    public interface IRepositoryGebruiker
    {
        Gebruiker GetGebruikerByEmail(string Email);
        void InsertGebruiker(Gebruiker gebruiker);
        void save();
        void Dispose();
    }
}
