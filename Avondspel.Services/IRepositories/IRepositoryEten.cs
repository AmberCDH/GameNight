using Avondspel.Domain;

namespace Avondspel.Services.IRepositories
{
    public interface IRepositoryEten
    {
        IEnumerable<Eten> GetEten();
        Eten? GetEtenById(int? id);
    }
}
