using Avondspel.Domain;
using Avondspel.Domain.Enum;
using Avondspel.Services;
using Avondspel.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Avondspel.Tests
{
    public class BordspellenAvondDomainServiceTests : TestDatabase
    {
        //--------------------------------Bordspellen Avond-----------------------------------
        private List<BordspellenAvond> bordspellenAvonden = new List<BordspellenAvond> {
            new BordspellenAvond
            {
                Id = 1,
                Planning = new DateTime(12/12/2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true
            },
            new BordspellenAvond
            {
                Id = 2,
                Planning = new DateTime(8/12/2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 2,
                AchtienPlus = false,
                PotLuck = false,
            },
            new BordspellenAvond
            {
                Id = 3,
                Planning = new DateTime(10/12/2222),
                GebruikerId = "2",
                Straat = "s",
                Stad = "s",
                Huisnummer = "2",
                AantalSpelers = 3,
                AchtienPlus = true,
                PotLuck = false
            },
            new BordspellenAvond
            {
                Id = 4,
                Planning = new DateTime(6/12/2222),
                GebruikerId = "1",
                Straat = "s",
                Stad = "s",
                Huisnummer = "3",
                AantalSpelers = 4,
                AchtienPlus = false,
                PotLuck = true
            },
            new BordspellenAvond
            {
                Id = 5,
                Planning = new DateTime(5/12/2222),
                GebruikerId = "1",
                Straat = "s",
                Stad = "s",
                Huisnummer = "3",
                AantalSpelers = 3,
                AchtienPlus = false,
                PotLuck = false
            },

        };
        private BordspellenAvond bordspellenAvond = new BordspellenAvond
        {
            Id = 1,
            Planning = new DateTime(2 / 12 / 2222),
            GebruikerId = "0",
            Straat = "s",
            Stad = "s",
            Huisnummer = "1",
            AantalSpelers = 4,
            AchtienPlus = false,
            PotLuck = false
        };

        //--------------------------------Eten lijst------------------------------------------
        private List<Eten> lijstMetEten = new List<Eten>
        {
            new Eten
                    {
                        Name = "Taart",
                        Lactose = true,
                        Notenallergie = true,

                    },
                    new Eten
                    {
                        Name = "Chips"

                    },
                    new Eten
                    {
                        Name = "Winegums",
                        Vega = true

                    },
                    new Eten
                    {
                        Name = "Chocolate chips koekjes",
                        Lactose = true,
                        Notenallergie = true,

                    },
                    new Eten
                    {
                        Name = "Mini snacks",
                        Vega = true,
                    },
                    new Eten
                    {
                        Name = "Cola"

                    },
                    new Eten
                    {
                        Name = "Wijn",
                        Alcohol = true,

                    },
                    new Eten
                    {
                        Name = "Bier",
                        Alcohol = true,

                    },
                    new Eten
                    {
                        Name = "Thee"

                    }
        };
        private Eten eten = new Eten()
        {
            Name = "Taart",
        };

        //--------------------------------Bordspellen lijst-----------------------------------
        private List<Bordspel> LijstMetBordspellen = new List<Bordspel>{
            new Bordspel
            {
                Id = 1,
                Naam = "Patchwork",
                Description = "Schattige panda's bij jou in de buurt",
                genre = Genre.Fantasy,
                AchtienPlus = false,
                foto = "idk",
                soortSpel = SoortSpel.Bordspellen,
                GebruikerId = "0"

            },
                    new Bordspel
                    {
                        Id = 2,
                        Naam = "Flamecraft",
                        Description = "Artisan dragons, the smaller and magically talented versions of their larger (and destructive) cousins, are sought by shopkeepers so that they may delight customers with their flamecraft. You are a Flamekeeper, skilled in the art of conversing with dragons, placing them in their ideal home and using enchantments to entice them to produce wondrous things. Your reputation will grow as you aid the dragons and shopkeepers, and the Flamekeeper with the most reputation will be known as the Master of Flamecraft.",
                        genre = Genre.Fantasy,
                        AchtienPlus = false,
                        foto = "idk",
                        soortSpel = SoortSpel.Bordspellen,
                        GebruikerId = "0"

                    },

                    new Bordspel
                    {
                        Id = 3,
                        Naam = "Cards Against Humanity",
                        Description = "Cards against humanity is a fill-in-the-blank party game that turns your awkward personality and lackluster social skills into hours of fun!",
                        genre = Genre.Actie,
                        AchtienPlus = true,
                        foto = "idk",
                        soortSpel = SoortSpel.Kaartspellen,
                        GebruikerId = "0"

                    }
        };

        //--------------------------------Gebruiker Lijst-------------------------------------
        private List<Gebruiker> gebruikers = new List<Gebruiker>
        {
            new Gebruiker{
                Id = 0,
                Name = "Amber",
                Email = "amber@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday =  new DateTime(17 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "1",
                Vega = true,
                OuderDanAchtien = true
            },
            new Gebruiker{
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday =  new DateTime(18 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            },
            new Gebruiker{
                Name = "blauw",
                Email = "blauw@mail.com",
                Gender = Geslacht.Onzijdig,
                Birthday =  new DateTime(17 / 09 / 2006),
                Street = "s",
                City = "s",
                HouseNumber = "3",
                Lactose = true,
                OuderDanAchtien = false
            },
        };
        private Gebruiker gebruiker = new Gebruiker()
        {
            Id = 1,
            Name = "blauw",
            Email = "blauw@mail.com",
            Gender = Geslacht.Onzijdig,
            Birthday = new DateTime(17 / 09 / 2006),
            Street = "s",
            City = "s",
            HouseNumber = "3",
            OuderDanAchtien = false
        };

        private string identityString = "0";

        //Model tests Eten--------------------------------------------------------------------
        [Fact]
        public void Can_Change_Name_Eten()
        {
            //Arrange
            eten = new Eten();
            //Act
            eten.Name = "New naam";
            //Assert
            Assert.Equal("New naam", eten.Name);
        }
        [Fact]
        public void Can_Change_Lactose_Eten()
        {
            //Arrange
            eten = new Eten();
            //Act
            eten.Lactose = true;
            //Assert
            Assert.True(eten.Lactose);
        }
        [Fact]
        public void Can_Change_Notenallergie_Eten()
        {
            //Arrange
            eten = new Eten();
            //Act
            eten.Notenallergie = true;
            //Assert
            Assert.True(eten.Notenallergie);
        }
        [Fact]
        public void Can_Change_Vega_Eten()
        {
            //Arrange
            eten = new Eten();
            //Act
            eten.Vega = false;
            //Assert
            Assert.False(eten.Vega);
        }
        [Fact]
        public void Can_Change_Alcohol_Eten()
        {
            //Arrange
            eten = new Eten();
            //Act
            eten.Alcohol = true;
            //Assert
            Assert.True(eten.Alcohol);
        }

        //Model tests Gebruiker---------------------------------------------------------------
        [Fact]
        public void Can_Change_Name_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.Name = "New naam";
            //Assert
            Assert.Equal("New naam", gebruiker.Name);
        }
        [Fact]
        public void Can_Change_Email_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.Email = "New naam";
            //Assert
            Assert.Equal("New naam", gebruiker.Email);
        }
        [Fact]
        public void Can_Change_Street_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.Street = "New naam";
            //Assert
            Assert.Equal("New naam", gebruiker.Street);
        }
        [Fact]
        public void Can_Change_City_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.City = "New naam";
            //Assert
            Assert.Equal("New naam", gebruiker.City);
        }
        [Fact]
        public void Can_Change_HouseNumber_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.HouseNumber = "New naam";
            //Assert
            Assert.Equal("New naam", gebruiker.HouseNumber);
        }
        [Fact]
        public void Can_Change_OuderDanAchtien_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.OuderDanAchtien = true;
            //Assert
            Assert.True(gebruiker.OuderDanAchtien);
        }
        [Fact]
        public void Can_Change_Gender_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.Gender = Geslacht.Onzijdig;
            //Assert
            Assert.Equal(Geslacht.Onzijdig, gebruiker.Gender);
        }
        [Fact]
        public void Can_Change_Lactose_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.Lactose = true;
            //Assert
            Assert.True(gebruiker.Lactose);
        }
        [Fact]
        public void Can_Change_Notenallergie_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.Notenallergie = true;
            //Assert
            Assert.True(gebruiker.Notenallergie);
        }
        [Fact]
        public void Can_Change_Vega_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.Vega = false;
            //Assert
            Assert.False(gebruiker.Vega);
        }
        [Fact]
        public void Can_Change_Alcohol_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.Alcohol = true;
            //Assert
            Assert.True(gebruiker.Alcohol);
        }
        [Fact]
        public void Can_Change_Birthday_Gebruiker()
        {
            //Arrange
            gebruiker = new Gebruiker();
            //Act
            gebruiker.Birthday = new DateTime(12 / 12 / 2001);
            //Assert
            Assert.Equal(new DateTime(12 / 12 / 2001), gebruiker.Birthday);
        }


        //Model tests BordspellenAvond--------------------------------------------------------
        [Fact]
        public void Can_Change_Street_Avond()
        {
            //Arrange
            bordspellenAvond = new BordspellenAvond();
            //Act
            bordspellenAvond.Straat = "New naam";
            //Assert
            Assert.Equal("New naam", bordspellenAvond.Straat);
        }
        [Fact]
        public void Can_Change_City_Avond()
        {
            //Arrange
            bordspellenAvond = new BordspellenAvond();
            //Act
            bordspellenAvond.Stad = "New naam";
            //Assert
            Assert.Equal("New naam", bordspellenAvond.Stad);
        }
        [Fact]
        public void Can_Change_HouseNumber_Avond()
        {
            //Arrange
            bordspellenAvond = new BordspellenAvond();
            //Act
            bordspellenAvond.Huisnummer = "New naam";
            //Assert
            Assert.Equal("New naam", bordspellenAvond.Huisnummer);
        }
        [Fact]
        public void Can_Change_GebruikerId_Avond()
        {
            //Arrange
            bordspellenAvond = new BordspellenAvond();
            //Act
            bordspellenAvond.GebruikerId = "New naam";
            //Assert
            Assert.Equal("New naam", bordspellenAvond.GebruikerId);
        }
        [Fact]
        public void Can_Change_AantalSpelers_Avond()
        {
            //Arrange
            bordspellenAvond = new BordspellenAvond();
            //Act
            bordspellenAvond.AantalSpelers = 8;
            //Assert
            Assert.Equal(8, bordspellenAvond.AantalSpelers);
        }
        [Fact]
        public void Can_Change_AchtienPlus_Avond()
        {
            //Arrange
            bordspellenAvond = new BordspellenAvond();
            //Act
            bordspellenAvond.AchtienPlus = true;
            //Assert
            Assert.True(bordspellenAvond.AchtienPlus);
        }
        [Fact]
        public void Can_Change_Potluck_Avond()
        {
            //Arrange
            bordspellenAvond = new BordspellenAvond();
            //Act
            bordspellenAvond.PotLuck = false;
            //Assert
            Assert.False(bordspellenAvond.PotLuck);
        }
        [Fact]
        public void Can_Change_Planning_Avond()
        {
            //Arrange
            bordspellenAvond = new BordspellenAvond();
            //Act
            bordspellenAvond.Planning = new DateTime(15 / 09 / 2222);
            //Assert
            Assert.Equal(new DateTime(15 / 09 / 2222), bordspellenAvond.Planning);
        }

        //BordspellenAvond Repository---------------------------------------------------------
        //GetBordspellenAvonden//-----------------------------------------------------------------------------------------------------------------------------------------------------
        [Fact]
        public void Can_use_Repository_To_GetAvonden()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            mockAvond.Setup(m => m.GetBordspellenAvonden(gebruiker)).Returns(bordspellenAvonden.ToArray());

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            //Act
            IEnumerable<BordspellenAvond> result = domainService.GetBordspellenAvonden(gebruiker).ToList();

            //Assert
            BordspellenAvond[] avondArray = result?.ToArray() ?? Array.Empty<BordspellenAvond>();
            Assert.True(avondArray.Length == 5);
            Assert.Equal(new DateTime(12 / 12 / 2222), bordspellenAvonden[0].Planning);
            Assert.Equal(new DateTime(8 / 12 / 2222), bordspellenAvonden[1].Planning);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //getBordspellenAvondMetUser--------------------------------------------------------------------------------------------------------------------------------------------------
        [Fact]
        public void Can_use_Repository_To_GetBordspellenAvondMetUser()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            var metGebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = new DateTime(18 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };

            var bordspellenAvondMetGebruiker1 = new BordspellenAvond
            {
                Id = 4,
                Planning = new DateTime(6 / 12 / 2222),
                GebruikerId = "1",
                Straat = "s",
                Stad = "s",
                Huisnummer = "3",
                AantalSpelers = 4,
                AchtienPlus = false,
                PotLuck = true,
                Gebruikers = new List<Gebruiker>
                {
                    metGebruiker
                }
            };
            var bordspellenAvondMetGebruiker2 = new BordspellenAvond
            {
                Id = 5,
                Planning = new DateTime(7 / 12 / 2222),
                GebruikerId = "1",
                Straat = "s",
                Stad = "s",
                Huisnummer = "3",
                AantalSpelers = 4,
                AchtienPlus = false,
                PotLuck = true,
                Gebruikers = new List<Gebruiker>
                {
                    metGebruiker
                }
            };
            var bordspellenAvondMetGebruiker3 = new BordspellenAvond
            {
                Id = 6,
                Planning = new DateTime(8 / 12 / 2222),
                GebruikerId = "1",
                Straat = "s",
                Stad = "s",
                Huisnummer = "3",
                AantalSpelers = 4,
                AchtienPlus = false,
                PotLuck = true,
                Gebruikers = new List<Gebruiker>
                {
                    metGebruiker
                }
            };

            var avondenMetGebruiker = new List<BordspellenAvond> { bordspellenAvondMetGebruiker1, bordspellenAvondMetGebruiker2, bordspellenAvondMetGebruiker3 };

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            mockAvond.Setup(m => m.GetBordspellenAvondMetGebruiker(gebruiker.Id)).Returns(avondenMetGebruiker.ToArray());


            //Act
            IEnumerable<BordspellenAvond> result = domainService.GetBordspellenAvondMetGebruikerId(gebruiker.Id).ToList();

            //Assert
            BordspellenAvond[] avondArray = result?.ToArray() ?? Array.Empty<BordspellenAvond>();
            Assert.True(avondArray.Length == 3);
            Assert.Equal(new DateTime(6 / 12 / 2222), avondenMetGebruiker[0].Planning);
            Assert.Equal(avondenMetGebruiker[0].Gebruikers.FirstOrDefault(), metGebruiker);
            Assert.Equal(new DateTime(7 / 12 / 2222), avondenMetGebruiker[1].Planning);
            Assert.Equal(avondenMetGebruiker[1].Gebruikers.FirstOrDefault(), metGebruiker);
            Assert.Equal(new DateTime(8 / 12 / 2222), avondenMetGebruiker[2].Planning);
            Assert.Equal(avondenMetGebruiker[2].Gebruikers.FirstOrDefault(), metGebruiker);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //getBordspellenAvondMetId//--------------------------------------------------------------------------------------------------------------------------------------------------
        [Fact]
        public void Can_use_Repository_To_GetBordspellenAvondMetId()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            mockAvond.Setup(m => m.GetBordspellenAvondById(bordspellenAvonden[0].Id)).Returns(bordspellenAvonden[0]);

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            //Act
            var result = domainService.getBordspellenAvondMetId(bordspellenAvonden[0].Id);

            //Assert
            Assert.Equal(result.Planning, bordspellenAvonden[0].Planning);
            Assert.Equal(result.Id, bordspellenAvonden[0].Id);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //inschrijvenGebruikerInAvond-------------------------------------------------------------------------------------------------------------------------------------------------
        [Fact]
        public void Can_use_Repository_To_InschrijvenGebruikerInAvond()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var gebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = new DateTime(18 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };

            var bordspellenAvond = new BordspellenAvond
            {
                Id = 0,
                Planning = new DateTime(12 / 12 / 2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true,
            };


            var bordspellenAvondMetGebruiker = new BordspellenAvond
            {
                Id = 0,
                Planning = new DateTime(12 / 12 / 2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true,
            };

            bordspellenAvondMetGebruiker.Gebruikers = new List<Gebruiker>
            {
                gebruiker
            };

            mockAvond.Setup(m => m.InsertBordspellenAvond(bordspellenAvond)).Returns(bordspellenAvond);
            mockAvond.Setup(m => m.InsertGebruikerInAvond(gebruiker, bordspellenAvond.Id)).Returns(bordspellenAvondMetGebruiker);
            mockAvond.Setup(m => m.GetBordspellenAvondById(bordspellenAvond.Id)).Returns(bordspellenAvondMetGebruiker);

            //Act
            var insertedAvond = domainService.InsertBordspellenAvond(bordspellenAvond, gebruikers[0]);
            var insertGebruiker = domainService.inschrijvenGebruikerInAvond(bordspellenAvond, gebruiker, identityString);
            var result = domainService.getBordspellenAvondMetId(0);

            //Assert
            Assert.Equal(gebruiker, result.Gebruikers[0]);
        }
        [Fact]
        public void Cannot_use_Repository_To_InschrijvenGebruikerInAvond_met_max_aantal()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var gebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = new DateTime(18 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };

            var bordspellenAvond = new BordspellenAvond
            {
                Id = 0,
                Planning = new DateTime(12 / 12 / 2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 0,
                AchtienPlus = true,
                PotLuck = true,
            };


            var bordspellenAvondMetGebruiker = new BordspellenAvond
            {
                Id = 0,
                Planning = new DateTime(12 / 12 / 2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true,
            };

            mockAvond.Setup(m => m.InsertBordspellenAvond(bordspellenAvond)).Returns(bordspellenAvond);
            mockAvond.Setup(m => m.InsertGebruikerInAvond(gebruiker, bordspellenAvond.Id)).Returns(bordspellenAvondMetGebruiker);
            mockAvond.Setup(m => m.GetBordspellenAvondById(bordspellenAvond.Id)).Returns(bordspellenAvondMetGebruiker);

            //Act
            var insertedAvond = domainService.InsertBordspellenAvond(bordspellenAvond, gebruikers[0]);
            var insertGebruiker = domainService.inschrijvenGebruikerInAvond(bordspellenAvond, gebruiker, identityString);
            var result = domainService.getBordspellenAvondMetId(0);

            //Assert
            Assert.Null(insertGebruiker);
            Assert.Null(result.Gebruikers);
        }
        [Fact]
        public void Cannot_use_Repository_To_InschrijvenGebruikerInAvond_leeftijd_te_jong()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);
            DateTime date;
            object value = "18 / 09 / 2006";
            bool parsed = DateTime.TryParse(value.ToString(), out date);
            var gebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = date,
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };

            var bordspellenAvond = new BordspellenAvond
            {
                Id = 0,
                Planning = new DateTime(12 / 12 / 2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true,
            };


            var bordspellenAvondMetGebruiker = new BordspellenAvond
            {
                Id = 0,
                Planning = new DateTime(12 / 12 / 2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true,
            };

            mockAvond.Setup(m => m.InsertBordspellenAvond(bordspellenAvond)).Returns(bordspellenAvond);
            mockAvond.Setup(m => m.InsertGebruikerInAvond(gebruiker, bordspellenAvond.Id)).Returns(bordspellenAvondMetGebruiker);
            mockAvond.Setup(m => m.GetBordspellenAvondById(bordspellenAvond.Id)).Returns(bordspellenAvondMetGebruiker);

            //Act
            var insertedAvond = domainService.InsertBordspellenAvond(bordspellenAvond, gebruikers[0]);
            try
            {
                var insertGebruiker = domainService.inschrijvenGebruikerInAvond(bordspellenAvond, gebruiker, identityString);
                Assert.True(false, "Should have thrown the error");
            }
            catch
            {
                Assert.True(true, "Gebruiker is te jong om zich aan te melden voor deze avond");
            }

            var result = domainService.getBordspellenAvondMetId(0);

            //Assert
            Assert.Null(result.Gebruikers);
        }
        [Fact]
        public void Cannot_use_Repository_To_InschrijvenGebruikerInAvond_al_ingeschreven_op_datum()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            DateTime date;
            object value = "18 / 09 / 2222";
            bool parsed = DateTime.TryParse(value.ToString(), out date);

            DateTime date2;
            object value2 = "18 / 09 / 2223";
            bool parsed2 = DateTime.TryParse(value2.ToString(), out date2);

            var gebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = new DateTime(18 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };
            string identityString = "2";
            var bordspellenAvond = new BordspellenAvond
            {
                Id = 0,
                Planning = date,
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true,
            };
            var bordspellenAvondMetGebruiker = new BordspellenAvond
            {
                Id = 0,
                Planning = date,
                GebruikerId = "2",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true,
            };
            var gebruikerNeemtDeelAan = new List<BordspellenAvond>
            {
                new BordspellenAvond
            {
                Id = 2,
                Planning = date,
                GebruikerId = "2",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true,
            },
                new BordspellenAvond
            {
                Id = 3,
                Planning = date2,
                GebruikerId = "2",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 1,
                AchtienPlus = true,
                PotLuck = true,
            },
        };
            mockAvond.Setup(m => m.InsertBordspellenAvond(bordspellenAvond)).Returns(bordspellenAvond);
            mockAvond.Setup(m => m.GetBordspellenAvondByUser(identityString)).Returns(gebruikerNeemtDeelAan);
            mockAvond.Setup(m => m.InsertGebruikerInAvond(gebruiker, bordspellenAvond.Id)).Returns(bordspellenAvondMetGebruiker);
            mockAvond.Setup(m => m.GetBordspellenAvondById(bordspellenAvond.Id)).Returns(bordspellenAvondMetGebruiker);

            //Act
            var insertedAvond = domainService.InsertBordspellenAvond(bordspellenAvond, gebruikers[0]);
            try
            {
                var insertGebruiker = domainService.inschrijvenGebruikerInAvond(bordspellenAvond, gebruiker, identityString);
                Assert.True(false, "Should have thrown the error");
            }
            catch
            {
                Assert.True(true, "Gebruiker is al op deze datum ingeschreven bij een andere avond");
            }


            var result = domainService.getBordspellenAvondMetId(0);

            //Assert
            Assert.Null(result.Gebruikers);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //GetBordspellenAvondMetGebruikerId//-----------------------------------------------------------------------------------------------------------------------------------------
        [Fact]
        public void Can_use_Repository_To_GetBordspellenAvondMetGebruikerIdentityString()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var bordspellenAvondGebruikerId = new List<BordspellenAvond>
            {
                new BordspellenAvond
                {
                    Id = 3,
                    Planning = new DateTime(10/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = false
                },
                new BordspellenAvond
                {
                    Id = 4,
                    Planning = new DateTime(12/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = true
                }
            };

            mockAvond.Setup(m => m.GetBordspellenAvondByUser("2")).Returns(bordspellenAvondGebruikerId.ToArray());

            //Act
            IEnumerable<BordspellenAvond> result = domainService.getBordspellenAvondMetUser("2").ToList();

            //Assert
            BordspellenAvond[] avondArray = result?.ToArray() ?? Array.Empty<BordspellenAvond>();
            Assert.True(avondArray.Length == 2);
            Assert.Equal(new DateTime(10 / 12 / 2222), bordspellenAvondGebruikerId[0].Planning);
            Assert.Equal(bordspellenAvondGebruikerId[0].GebruikerId, "2");
            Assert.Equal(new DateTime(12 / 12 / 2222), bordspellenAvondGebruikerId[1].Planning);
            Assert.Equal(bordspellenAvondGebruikerId[0].GebruikerId, "2");
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //UpdateBordspellenAvond//----------------------------------------------------------------------------------------------------------------------------------------------------
        [Fact]
        public void Can_use_repository_To_UpdateBordspellenAvond()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var bordspellenAvondUpdate = new List<BordspellenAvond>
            {
                new BordspellenAvond
                {
                    Id = 3,
                    Planning = new DateTime(10/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = false
                },
                new BordspellenAvond
                {
                    Id = 4,
                    Planning = new DateTime(12/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = true
                }
            };
            var avondToUpdate = new BordspellenAvond
            {
                Id = 3,
                Planning = new DateTime(20 / 12 / 2222),
                GebruikerId = "2",
                Straat = "straat",
                Stad = "straat",
                Huisnummer = "2",
                AantalSpelers = 3,
                AchtienPlus = true,
            };

            var metGebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = new DateTime(18 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };

            mockAvond.Setup(m => m.GetBordspellenAvonden(metGebruiker)).Returns(bordspellenAvondUpdate.ToArray());
            mockAvond.Setup(m => m.UpdateBordspellenAvond(avondToUpdate)).Returns(avondToUpdate);
            mockAvond.Setup(m => m.GetBordspellenAvondById(bordspellenAvondUpdate[0].Id)).Returns(avondToUpdate);

            //Act
            IEnumerable<BordspellenAvond> resultList = domainService.GetBordspellenAvonden(metGebruiker).ToList();
            var resultUpdate = domainService.UpdateBordspellenAvond(avondToUpdate);
            var resultAfterUpdate = domainService.getBordspellenAvondMetId(avondToUpdate.Id);

            //Assert
            BordspellenAvond[] avondArray = resultList?.ToArray() ?? Array.Empty<BordspellenAvond>();
            Assert.NotEqual(avondArray[0].Straat, resultAfterUpdate.Straat);
            Assert.NotEqual(avondArray[0].Stad, resultAfterUpdate.Stad);
            Assert.Equal(resultUpdate, resultAfterUpdate);


        }

        [Fact]
        public void Cannot_use_repository_To_UpdateBordspellenAvond_if_users_are_invited()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var bordspellenAvondUpdate = new List<BordspellenAvond>
            {
                new BordspellenAvond
                {
                    Id = 3,
                    Planning = new DateTime(10/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = false,
                    Gebruikers = gebruikers
                },
                new BordspellenAvond
                {
                    Id = 4,
                    Planning = new DateTime(12/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = true
                }
            };
            var avondToUpdate = new BordspellenAvond
            {
                Id = 3,
                Planning = new DateTime(20 / 12 / 2222),
                GebruikerId = "2",
                Straat = "straat",
                Stad = "straat",
                Huisnummer = "2",
                AantalSpelers = 3,
                AchtienPlus = true,
            };

            var metGebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = new DateTime(18 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };

            mockAvond.Setup(m => m.GetBordspellenAvonden(metGebruiker)).Returns(bordspellenAvondUpdate.ToArray());
            mockAvond.Setup(m => m.UpdateBordspellenAvond(avondToUpdate)).Returns(avondToUpdate);
            mockAvond.Setup(m => m.GetBordspellenAvondById(bordspellenAvondUpdate[0].Id)).Returns(bordspellenAvondUpdate[0]);

            //Act
            IEnumerable<BordspellenAvond> resultList = domainService.GetBordspellenAvonden(metGebruiker).ToList();
            var resultUpdate = domainService.UpdateBordspellenAvond(avondToUpdate);
            var resultAfterUpdate = domainService.getBordspellenAvondMetId(avondToUpdate.Id);

            //Assert
            BordspellenAvond[] avondArray = resultList?.ToArray() ?? Array.Empty<BordspellenAvond>();
            Assert.Equal(avondArray[0].Straat, resultAfterUpdate.Straat);
            Assert.Equal(avondArray[0].Stad, resultAfterUpdate.Stad);
            Assert.NotEqual(resultUpdate, resultAfterUpdate);


        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //DeleteBordspellenAvond//----------------------------------------------------------------------------------------------------------------------------------------------------
        [Fact]
        public void Can_use_repository_To_DeleteBordspellenAvond()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var bordspellenAvondDelete = new List<BordspellenAvond>
            {
                new BordspellenAvond
                {
                    Id = 3,
                    Planning = new DateTime(10/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = false
                },
                new BordspellenAvond
                {
                    Id = 4,
                    Planning = new DateTime(12/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = true
                }
            };
            var bordspellenAvondDeleted = new List<BordspellenAvond>
            {
                new BordspellenAvond
                {
                    Id = 4,
                    Planning = new DateTime(12/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = true
                }
            };
            var metGebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = new DateTime(18 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };

            mockAvond.Setup(m => m.GetBordspellenAvonden(metGebruiker)).Returns(bordspellenAvondDelete.ToArray());
            IEnumerable<BordspellenAvond> resultList1 = domainService.GetBordspellenAvonden(metGebruiker).ToList();
            BordspellenAvond[] avondArrayBefore = resultList1?.ToArray() ?? Array.Empty<BordspellenAvond>();
            Assert.True(avondArrayBefore.Length == 2);

            mockAvond.Setup(m => m.DeleteBordspellenAvond(bordspellenAvondDelete[0].Id)).Returns(true);
            mockAvond.Setup(m => m.GetBordspellenAvonden(metGebruiker)).Returns(bordspellenAvondDeleted.ToArray());

            //Act
            var resultdelete = domainService.DeleteBordspellenAvond(bordspellenAvondDelete[0].Id);
            IEnumerable<BordspellenAvond> resultList2 = domainService.GetBordspellenAvonden(metGebruiker).ToList();

            //Assert
            BordspellenAvond[] avondArrayAfter = resultList2?.ToArray() ?? Array.Empty<BordspellenAvond>();
            Assert.True(avondArrayAfter.Length == 1);
            Assert.True(resultdelete);
        }
        [Fact]
        public void Cannot_use_repository_To_DeleteBordspellenAvond_if_users_are_invited()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var bordspellenAvondDelete = new List<BordspellenAvond>
            {
                new BordspellenAvond
                {
                    Id = 3,
                    Planning = new DateTime(10/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = false,
                    Gebruikers = gebruikers
                },
                new BordspellenAvond
                {
                    Id = 4,
                    Planning = new DateTime(12/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = true,
                    PotLuck = true
                }
            };
            var metGebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = new DateTime(18 / 09 / 2001),
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };

            mockAvond.Setup(m => m.GetBordspellenAvonden(metGebruiker)).Returns(bordspellenAvondDelete.ToArray());
            IEnumerable<BordspellenAvond> resultList1 = domainService.GetBordspellenAvonden(metGebruiker).ToList();
            BordspellenAvond[] avondArrayBefore = resultList1?.ToArray() ?? Array.Empty<BordspellenAvond>();
            Assert.True(avondArrayBefore.Length == 2);

            mockAvond.Setup(m => m.DeleteBordspellenAvond(bordspellenAvondDelete[0].Id)).Returns(false);
            mockAvond.Setup(m => m.GetBordspellenAvonden(metGebruiker)).Returns(bordspellenAvondDelete.ToArray());

            //Act
            var resultdelete = domainService.DeleteBordspellenAvond(bordspellenAvondDelete[0].Id);
            IEnumerable<BordspellenAvond> resultList2 = domainService.GetBordspellenAvonden(metGebruiker).ToList();

            //Assert
            BordspellenAvond[] avondArrayAfter = resultList2?.ToArray() ?? Array.Empty<BordspellenAvond>();
            Assert.True(avondArrayAfter.Length == 2);
            Assert.True(resultdelete);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //CreateBordspellenAvond------------------------------------------------------------------------------------------------------------------------------------------------------
        [Fact]
        public void Can_use_repository_To_CreateBordspellenAvond()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);
            DateTime date;
            object value = "18 / 09 / 2001";
            bool parsed = DateTime.TryParse(value.ToString(), out date);
            var bordspellenAvondCreate = new List<BordspellenAvond>
            {
                new BordspellenAvond
                {
                    Id = 4,
                    Planning = new DateTime(12/12/2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = false,
                    PotLuck = true,
                }
            };
            var bordspellenLijst = new BordspellenLijst
            {
                SpelAvondId = 4,
                BordspelId = 2,
                GebruikerId = "2"
            };
            var bordspellenAvondToCreate =
                new BordspellenAvond
                {
                    Id = 4,
                    Planning = new DateTime(12 / 12 / 2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = false,
                    PotLuck = true,
                };

            var metGebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = date,
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = true
            };


            mockAvond.Setup(m => m.InsertBordspellenAvond(bordspellenAvondToCreate)).Returns(bordspellenAvondToCreate);
            mockAvond.Setup(m => m.GetBordspellenAvonden(metGebruiker)).Returns(bordspellenAvondCreate);


            //Act
            var insertedBordspellenAvond = domainService.InsertBordspellenAvond(bordspellenAvondToCreate, metGebruiker);
            IEnumerable<BordspellenAvond> resultList = domainService.GetBordspellenAvonden(metGebruiker).ToList();
            BordspellenAvond[] avondArray = resultList?.ToArray() ?? Array.Empty<BordspellenAvond>();

            //Assert
            Assert.True(avondArray.Length == 1);
            Assert.Equal(avondArray[0].AchtienPlus, insertedBordspellenAvond.AchtienPlus);
            Assert.Equal(avondArray[0].Id, insertedBordspellenAvond.Id);
        }
        [Fact]
        public void Cannot_use_repository_To_CreateBordspellenAvond_if_under_eighteen()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);
            DateTime date;
            object value = "18 / 09 / 2006";
            bool parsed = DateTime.TryParse(value.ToString(), out date);
            var bordspellenAvondCreate = new List<BordspellenAvond>
            {
            };
            var bordspellenLijst = new BordspellenLijst
            {
                SpelAvondId = 4,
                BordspelId = 2,
                GebruikerId = "2"
            };
            var bordspellenAvondToCreate =
                new BordspellenAvond
                {
                    Id = 4,
                    Planning = new DateTime(12 / 12 / 2222),
                    GebruikerId = "2",
                    Straat = "s",
                    Stad = "s",
                    Huisnummer = "2",
                    AantalSpelers = 3,
                    AchtienPlus = false,
                    PotLuck = true,
                };

            var metGebruiker = new Gebruiker
            {
                Id = 2,
                Name = "Geel",
                Email = "geel@mail.com",
                Gender = Geslacht.LieverNiet,
                Birthday = date,
                Street = "s",
                City = "s",
                HouseNumber = "2",
                Alcohol = true,
                OuderDanAchtien = false
            };


            mockAvond.Setup(m => m.InsertBordspellenAvond(bordspellenAvondToCreate)).Returns(bordspellenAvondToCreate);
            mockAvond.Setup(m => m.GetBordspellenAvonden(metGebruiker)).Returns(bordspellenAvondCreate);


            //Act
            try
            {
                var insertedBordspellenAvond = domainService.InsertBordspellenAvond(bordspellenAvondToCreate, metGebruiker);
                Assert.True(false, "Should have thrown the exception");
            }
            catch
            {
                Assert.True(true, "gebruiker heeft geen avond aan kunnen maken");
            }


            IEnumerable<BordspellenAvond> resultList = domainService.GetBordspellenAvonden(metGebruiker).ToList();
            BordspellenAvond[] avondArray = resultList?.ToArray() ?? Array.Empty<BordspellenAvond>();

            //Assert
            Assert.True(avondArray.Length == 0);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Bordspellenlijst is zichtbaar-----------------------------------------------------------------------------------------------------------------------------------------------werkt nog niet
        [Fact]
        public void Can_use_repository_To_getBordspellen_in_avond()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var bordspellen = new List<BordspellenLijst>
            {
                new BordspellenLijst
                {
                    SpelAvondId = 1,
                    BordspelId =1,
                    GebruikerId = "1"
                },
                new BordspellenLijst
                {
                    SpelAvondId = 1,
                    BordspelId = 2,
                    GebruikerId = "1"
                },
                new BordspellenLijst
                {
                    SpelAvondId = 1,
                    BordspelId = 3,
                    GebruikerId = "1"
                },
                new BordspellenLijst
                {
                    SpelAvondId = 1,
                    BordspelId = 4,
                    GebruikerId = "1"
                },
            };

            var bordspel = new Bordspel
            {
                Id = 1,
                Naam = "Patchwork",
                Description = "Schattige panda's bij jou in de buurt",
                genre = Genre.Fantasy,
                AchtienPlus = false,
                foto = "idk",
                soortSpel = SoortSpel.Bordspellen,
                GebruikerId = "1"
            };

            mockBordspelLijst.Setup(m => m.GetBordspellenLijstByAvond(1)).Returns(bordspellen);
            mockBordspel.Setup(m => m.GetBordspelById(1)).Returns(bordspel);

            //Act
            IEnumerable<BordspellenLijst> result = domainService.GetBordspellenLijstByAvond(1).ToList();
            var bordspelInLijst = domainService.GetBordspelById(1);

            //Assert
            BordspellenLijst[] bordspelArray = result?.ToArray() ?? Array.Empty<BordspellenLijst>();
            Assert.True(bordspelArray.Length == 4);
            Assert.Equal(bordspelArray[0].BordspelId, bordspel.Id);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //lijst met eten is zichtbaar-------------------------------------------------------------------------------------------------------------------------------------------------werkt nog niet
        [Fact]
        public void Can_use_repository_To_getEten_in_avond()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var avond = new BordspellenAvond
            {
                Id = 1,
                Planning = new DateTime(2 / 12 / 2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 4,
                AchtienPlus = false,
                PotLuck = false,
                EtenLijst = lijstMetEten
            };

            mockAvond.Setup(m => m.GetBordspellenAvondById(1)).Returns(avond);

            //Act
            var avondEten = domainService.getBordspellenAvondMetId(1);

            //Assert
            Assert.Equal(avondEten.EtenLijst.Count(), lijstMetEten.Count());
            Assert.Equal(avondEten.EtenLijst[0], lijstMetEten[0]);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //insert eten-----------------------------------------------------------------------------------------------------------------------------------------------------------------werkt nog niet
        [Fact]
        public void Can_use_repository_To_insertEten_in_avond()
        {
            //Arrange
            Mock<IRepositoryBordspellenAvond> mockAvond = new Mock<IRepositoryBordspellenAvond>();
            Mock<IRepositoryBordspellen> mockBordspel = new Mock<IRepositoryBordspellen>();
            Mock<IRepositoryBordspelLijst> mockBordspelLijst = new Mock<IRepositoryBordspelLijst>();
            Mock<IRepositoryGebruiker> mockGebruiker = new Mock<IRepositoryGebruiker>();
            Mock<IRepositoryEten> mockEten = new Mock<IRepositoryEten>();

            BordspellenAvondDomainService domainService = new BordspellenAvondDomainService(mockEten.Object, mockAvond.Object, mockBordspelLijst.Object, mockBordspel.Object, mockGebruiker.Object);

            var avond = new BordspellenAvond
            {
                Id = 1,
                Planning = new DateTime(2 / 12 / 2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 4,
                AchtienPlus = false,
                PotLuck = false
            };
            var avondAfter = new BordspellenAvond
            {
                Id = 1,
                Planning = new DateTime(2 / 12 / 2222),
                GebruikerId = "0",
                Straat = "s",
                Stad = "s",
                Huisnummer = "1",
                AantalSpelers = 4,
                AchtienPlus = false,
                PotLuck = false,
                EtenLijst = new List<Eten>
                {
                    eten
                }
            };
            mockAvond.Setup(m => m.InsertBordspellenAvond(avond)).Returns(avond);

            mockAvond.Setup(m => m.InsertEtenInAvond(eten, avond.Id)).Returns(true);

            mockAvond.Setup(m => m.GetBordspellenAvondById(avond.Id)).Returns(avondAfter);

            //Act
            var bordspellenAvond = domainService.InsertBordspellenAvond(avond, gebruiker);
            var etenInAvond = domainService.InsertEtenInAvond(eten, avond.Id);
            var getAvond = domainService.getBordspellenAvondMetId(avond.Id);

            //Assert
            Assert.NotEqual(bordspellenAvond, getAvond);
            Assert.Equal(bordspellenAvond.Id, getAvond.Id);
            Assert.True(getAvond.EtenLijst.Count() == 1);
            Assert.Equal(getAvond.EtenLijst.FirstOrDefault(), eten);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Eten Repository---------------------------------------------------------------------
        //GetEten
        //GetEtenById
        //InsertEtenInAvond

        //Bordspellen Repository--------------------------------------------------------------
        //GetBordspellenLijstByAvond
        //GetBordspellen
        //GetBordspelById
        //DeleteUitLijst

        //Gebruiker Repository----------------------------------------------------------------
        //getGebruikerByEmail
    }

}