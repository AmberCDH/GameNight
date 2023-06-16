using Avondspel.Domain;

namespace Avondspel.Services
{
    public interface IBordspellenAvondDomainService
    {
        //InsertGebruikerInAvond repo
        public BordspellenAvond? inschrijvenGebruikerInAvond(BordspellenAvond bordspellenAvond, Gebruiker gebruiker, string identityUserId);

        //GetGebruikerByEmail repo
        public Gebruiker? getGebruikerByEmail(string identityGebruiker);

        //GetBordspellenAvondByUser repo
        public IEnumerable<BordspellenAvond>? getBordspellenAvondMetUser(string gebruikerId);

        //GetBordspellenAvondById
        public BordspellenAvond getBordspellenAvondMetId(int gebruikerId);

        //GetBordspellenAvonden
        IEnumerable<BordspellenAvond>? GetBordspellenAvonden(Gebruiker? gebruiker);

        //GetBordspellenAvondMetGebruiker
        IEnumerable<BordspellenAvond>? GetBordspellenAvondMetGebruikerId(int gebruikerId);

        //GetBordspellenLijstByAvond
        IEnumerable<BordspellenLijst>? GetBordspellenLijstByAvond(int? AvondId);

        //GetBordspellen
        IEnumerable<Bordspel> GetBordspellen();

        //GetEten
        IEnumerable<Eten> GetEten();

        //InsertBordspellenAvond
        BordspellenAvond? InsertBordspellenAvond(BordspellenAvond bordspellenAvond, Gebruiker gebruiker);

        //GetEtenById
        Eten? GetEtenById(int? id);

        //GetBordspelById
        Bordspel? GetBordspelById(int? id);

        //UpdateBordspellenAvond
        BordspellenAvond UpdateBordspellenAvond(BordspellenAvond bordspellenAvond);

        //DeleteBordspellenAvond
        bool DeleteBordspellenAvond(int id);

        //DeleteUitLijst
        bool DeleteUitLijst(int bordspelId, int spelavondId);

        //InsertEtenInAvond
        bool InsertEtenInAvond(Eten eten, int avondId);
    }
}
