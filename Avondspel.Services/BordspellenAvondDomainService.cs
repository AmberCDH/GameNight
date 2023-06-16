using Avondspel.Domain;
using Avondspel.Services.IRepositories;
using Microsoft.AspNetCore.Identity;
using System;

namespace Avondspel.Services
{
    public class BordspellenAvondDomainService : IBordspellenAvondDomainService
    {
        private readonly IRepositoryBordspellenAvond _repositoryBordspellenAvond;
        private readonly IRepositoryBordspelLijst _repositoryBordspelLijst;
        private readonly IRepositoryBordspellen _repositoryBordspellen;
        private readonly IRepositoryGebruiker _repositoryGebruiker;
        private readonly IRepositoryEten _repositoryEten;
        public BordspellenAvondDomainService(IRepositoryEten repositoryEten, IRepositoryBordspellenAvond repositoryBordspellenAvond, IRepositoryBordspelLijst repositoryBordspelLijst, IRepositoryBordspellen repositoryBordspellen, IRepositoryGebruiker repositoryGebruiker)
        {
            _repositoryBordspelLijst = repositoryBordspelLijst;
            _repositoryBordspellenAvond = repositoryBordspellenAvond;
            _repositoryBordspellen = repositoryBordspellen;
            _repositoryGebruiker = repositoryGebruiker;
            _repositoryEten = repositoryEten;
        }

        public IEnumerable<BordspellenAvond>? GetBordspellenAvonden(Gebruiker? gebruiker)
        {
            try
            {
                if (gebruiker == null)
                {
                    throw new Exception("gebruiker is null");
                }
                else
                {
                    return _repositoryBordspellenAvond.GetBordspellenAvonden(gebruiker);
                }

            }
            catch
            {
                throw new Exception("lijst met avonden kon niet opgehaald worden");
            }
        }

        public IEnumerable<BordspellenAvond>? getBordspellenAvondMetUser(string gebruikerId)
        {
            try
            {
                return _repositoryBordspellenAvond.GetBordspellenAvondByUser(gebruikerId);
            }
            catch
            {
                throw new Exception("Geen lijsten gevonden");
            }
        }

        public BordspellenAvond getBordspellenAvondMetId(int avondId)
        {
            try
            {
                return _repositoryBordspellenAvond.GetBordspellenAvondById(avondId);
            }
            catch
            {
                throw new Exception("Avond met id kon niet opgehaald worden");
            }
        }

        public Gebruiker? getGebruikerByEmail(string identityGebruiker)
        {
            try
            {
                return _repositoryGebruiker.GetGebruikerByEmail(identityGebruiker);
            }
            catch
            {
                throw new Exception("Gebruiker is niet gevonden");
            }
        }

        public BordspellenAvond? inschrijvenGebruikerInAvond(BordspellenAvond bordspellenAvond, Gebruiker gebruiker, string identityUserId)
        {
            var deelnemendAan = getBordspellenAvondMetUser(identityUserId);
            int gebruikersInAvond = 0;
            try
            {
                if (bordspellenAvond.Gebruikers?.Count() != null)
                {
                    gebruikersInAvond = bordspellenAvond.Gebruikers.Count();
                }
                if (gebruiker != null)
                {
                    if (bordspellenAvond.AantalSpelers > gebruikersInAvond)
                    {
                        if (bordspellenAvond.AchtienPlus)
                        {
                            DateTime gebruikerLeeftijd;
                            bool parsed = DateTime.TryParse(gebruiker.Birthday.ToString(), out gebruikerLeeftijd);


                            if (!parsed)
                            {
                                throw new Exception("leeftijd is niet goed geparsed");

                            }
                            else
                            {
                                var min = DateTime.Now.AddYears(-18);
                                if (gebruikerLeeftijd > min)
                                {
                                    throw new Exception("Te jong voor deze bordspellenAvond");
                                }
                                else
                                {
                                    var datumAvond = bordspellenAvond.Planning.ToString("dd/MM/yyyy");
                                    if (deelnemendAan != null)
                                    {
                                        foreach (var x in deelnemendAan)
                                        {
                                            string datumPattern = x.Planning.ToString("dd/MM/yyyy");
                                            if (datumPattern == datumAvond)
                                            {
                                                throw new Exception("gebruiker heeft al een avond ingepland");
                                            }
                                            else
                                            {

                                            }

                                        }
                                        _repositoryBordspellenAvond.InsertGebruikerInAvond(gebruiker, bordspellenAvond.Id);
                                        _repositoryBordspellenAvond.save();
                                        return bordspellenAvond;
                                    }
                                    else
                                    {
                                        _repositoryBordspellenAvond.InsertGebruikerInAvond(gebruiker, bordspellenAvond.Id);
                                        _repositoryBordspellenAvond.save();
                                        return bordspellenAvond;
                                    }
                                }
                            }

                        }
                        else
                        {
                            var datumAvond = bordspellenAvond.Planning.ToString("dd/MM/yyyy");
                            if (deelnemendAan != null)
                            {
                                foreach (var x in deelnemendAan)
                                {
                                    string datumPattern = x.Planning.ToString("dd/MM/yyyy");
                                    if (datumPattern == datumAvond)
                                    {
                                        throw new Exception("gebruiker heeft al een avond ingepland");
                                    }
                                    else
                                    {

                                    }

                                }
                                _repositoryBordspellenAvond.InsertGebruikerInAvond(gebruiker, bordspellenAvond.Id);
                                _repositoryBordspellenAvond.save();
                                return bordspellenAvond;
                            }
                            else
                            {
                                _repositoryBordspellenAvond.InsertGebruikerInAvond(gebruiker, bordspellenAvond.Id);
                                _repositoryBordspellenAvond.save();
                                return bordspellenAvond;
                            }
                        }

                    }
                }
                return null;
            }
            catch
            {
                throw new Exception();
            }

        }

        public IEnumerable<BordspellenAvond>? GetBordspellenAvondMetGebruikerId(int gebruikerId)
        {
            try
            {
                return _repositoryBordspellenAvond.GetBordspellenAvondMetGebruiker(gebruikerId);
            }
            catch
            {
                throw new Exception("Geen lijsten gevonden");
            }
        }

        public IEnumerable<BordspellenLijst>? GetBordspellenLijstByAvond(int? AvondId)
        {
            try
            {
                return _repositoryBordspelLijst.GetBordspellenLijstByAvond(AvondId);
            }
            catch
            {
                throw new Exception("Geen bordspellenlijst gevonden");
            }
        }

        public IEnumerable<Bordspel> GetBordspellen()
        {
            try
            {
                return _repositoryBordspellen.GetBordspellen();
            }
            catch
            {
                throw new Exception("Geen bordspellen gevonden");
            }

        }

        public IEnumerable<Eten> GetEten()
        {
            try
            {
                return _repositoryEten.GetEten();
            }
            catch
            {
                throw new Exception("Geen eten gevonden");
            }
        }

        public BordspellenAvond? InsertBordspellenAvond(BordspellenAvond bordspellenAvond, Gebruiker gebruiker)
        {
            try
            {
                DateTime gebruikerLeeftijd;
                bool parsed = DateTime.TryParse(gebruiker.Birthday.ToString(), out gebruikerLeeftijd);
                var min = DateTime.Now.AddYears(-18);

                if (!parsed)
                {
                    throw new Exception("leeftijd is niet goed geparsed");
                }
                else
                {
                    if (gebruikerLeeftijd > min)
                    {
                        throw new Exception("De gebruiker moet minimaal 18 jaar zijn");
                    }
                    else
                    {
                        _repositoryBordspellenAvond.InsertBordspellenAvond(bordspellenAvond);
                        _repositoryBordspellenAvond.save();
                        return bordspellenAvond;
                    }
                }
            }
            catch
            {
                throw new Exception("Er is iets fout gegaan bij het aanmaken van een avond.");
            }
        }

        public Eten? GetEtenById(int? id)
        {
            try
            {
                return _repositoryEten.GetEtenById(id);
            }
            catch
            {
                throw new Exception("eten is niet gevonden");
            }
        }

        public Bordspel? GetBordspelById(int? id)
        {
            try
            {
                return _repositoryBordspellen.GetBordspelById(id);
            }
            catch
            {
                throw new Exception("bordspel is niet gevonden");
            }
        }

        public BordspellenAvond UpdateBordspellenAvond(BordspellenAvond bordspellenAvond)
        {
            try
            {
                _repositoryBordspellenAvond.UpdateBordspellenAvond(bordspellenAvond);
                _repositoryBordspellenAvond.save();
                return bordspellenAvond;
            }
            catch
            {
                throw new Exception("Avond kon niet upgedate worden");
            }
        }

        public bool DeleteBordspellenAvond(int id)
        {
            try
            {
                _repositoryBordspellenAvond.DeleteBordspellenAvond(id);
                _repositoryBordspellenAvond.save();
                return true;
            }
            catch
            {
                throw new Exception("Avond kon niet gedelete worden");
            };
        }

        public bool DeleteUitLijst(int bordspelId, int spelavondId)
        {
            try
            {
                _repositoryBordspelLijst.DeleteUitLijst(bordspelId, spelavondId);
                _repositoryBordspelLijst.save();
                return true;
            }
            catch
            {
                throw new Exception("Bordspel kon niet gedelete worden uit lijst");
            };
        }

        public bool InsertEtenInAvond(Eten eten, int avondId)
        {
            try
            {
                _repositoryBordspellenAvond.InsertEtenInAvond(eten, avondId);
                _repositoryBordspellenAvond.save();
                return true;
            }
            catch
            {
                throw new Exception("Eten kon niet toegevoegd worden in lijst");
            };
        }
    }
}
