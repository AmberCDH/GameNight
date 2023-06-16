using Avondspel.Domain;

namespace Avondspel.Services.IRepositories
{
    public interface IRepositoryBordspellen
    {
        IEnumerable<Bordspel> GetBordspellen();
        Bordspel? GetBordspelById(int? id);
        void InsertBordspel(Bordspel bordspel);
        void DeleteBordspel(int id);
        void UpdateBordspel(Bordspel bordspel);
        void save();
        void Dispose();
    }
}
