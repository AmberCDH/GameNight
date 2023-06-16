using Avondspel.Domain;

namespace Avondspel.Services.IRepositories
{
    public interface IRepositoryBordspelLijst
    {
        IEnumerable<BordspellenLijst>? GetBordspellenLijstByAvond(int? AvondId);
        void InsertInLijst(BordspellenLijst BLijst);
        void DeleteUitLijst(int bordspelId, int spelavondId);
        void save();
        void Dispose();

    }
}
