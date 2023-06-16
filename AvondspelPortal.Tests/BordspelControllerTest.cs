using Avondspel.Domain;
using Avondspel.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;
namespace Avondspel.Tests
{
    public class BordspelControllerTest
    {
        /*        private List<Bordspel> bordspelList = new List<Bordspel>{
            new Bordspel
            {
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
                        Naam = "Flamecraft",
                        Description = "Artisan dragons, the smaller and magically talented versions of their larger (and destructive) cousins, are sought by shopkeepers so that they may delight customers with their flamecraft. You are a Flamekeeper, skilled in the art of conversing with dragons, placing them in their ideal home and using enchantments to entice them to produce wondrous things. Your reputation will grow as you aid the dragons and shopkeepers, and the Flamekeeper with the most reputation will be known as the Master of Flamecraft.",
                        genre = Genre.Fantasy,
                        AchtienPlus = false,
                        foto = "idk",
                        soortSpel = SoortSpel.Bordspellen,
                        GebruikerId = "0"

                    }
        };*/
        private Bordspel bordspel = new Bordspel()
        {
            Id = 3,
            Naam = "Pesten",
            Description = "Iets met pesten",
            genre = Genre.Durven,
            AchtienPlus = false,
            foto = "idk",
            soortSpel = SoortSpel.Kaartspellen,
            GebruikerId = "0"
        };

        public IFormFile makeImage()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            return fileMock.Object;
        }
        //Model Tests---------------------------------------------------------------------------------------------------
        [Fact]
        public void Can_Change_Name_Bordspel()
        {
            //Arrange
            bordspel = new Bordspel();
            //Act
            bordspel.Naam = "New naam";
            //Assert
            Assert.Equal("New naam", bordspel.Naam);
        }
        [Fact]
        public void Can_Change_Description_Bordspel()
        {
            //Arrange
            bordspel = new Bordspel();
            //Act
            bordspel.Description = "New naam";
            //Assert
            Assert.Equal("New naam", bordspel.Description);
        }
        [Fact]
        public void Can_Change_Genre_Bordspel()
        {
            //Arrange
            bordspel = new Bordspel();
            //Act
            bordspel.genre = Genre.Avontuur;
            //Assert
            Assert.Equal(Genre.Avontuur, bordspel.genre);
        }
        [Fact]
        public void Can_Change_AchtienPlus_Bordspel()
        {
            //Arrange
            bordspel = new Bordspel();
            //Act
            bordspel.AchtienPlus = true;
            //Assert
            Assert.True(bordspel.AchtienPlus);
        }
        [Fact]
        public void Can_Change_SoortSpel_Bordspel()
        {
            //Arrange
            bordspel = new Bordspel();
            //Act
            bordspel.soortSpel = SoortSpel.Kaartspellen;
            //Assert
            Assert.Equal(SoortSpel.Kaartspellen, bordspel.soortSpel);
        }
        [Fact]
        public void Can_Change_Foto_Bordspel()
        {
            //Arrange
            bordspel = new Bordspel();
            //Act
            bordspel.foto = "New naam";
            //Assert
            Assert.Equal("New naam", bordspel.foto);
        }
        [Fact]
        public void Can_Change_GebruikerId_Bordspel()
        {
            //Arrange
            bordspel = new Bordspel();
            //Act
            bordspel.GebruikerId = "New naam";
            //Assert
            Assert.Equal("New naam", bordspel.GebruikerId);
        }

        //Repository----------------------------------------------------------------------------------------------------
        //----------GetAll-------------------------------------
        /*[Fact]
        public void Can_Use_Repository_To_GetBordspellen()
        {
            //Arrange
            Mock<IRepositoryBordspellen> mock = new Mock<IRepositoryBordspellen>();
            mock.Setup(m => m.GetBordspellen()).Returns(bordspelList.ToArray());

            BordspelController controller = new BordspelController(mock.Object);

            //Act
            IEnumerable<Bordspel>? result = (controller.Index() as ViewResult)?
                .ViewData.Model as IEnumerable<Bordspel>;

            //Assert
            Bordspel[] bordspelArray = result?.ToArray() ?? Array.Empty<Bordspel>();
            Assert.True(bordspelArray.Length == 2);
            Assert.Equal("Patchwork", bordspelArray[0].Naam);
            Assert.Equal("Flamecraft", bordspelArray[1].Naam);

        }
*/
        //----------Create-------------------------------------
        /*[Fact]
        public void Can_Use_Repository_To_CreateBordspel()
        {
            //Kijk hier later nog een keer naar. De moq wordt nu vergeleken zoals bij get by id
            //Arrange
            Mock<IRepositoryBordspellen> mock = new Mock<IRepositoryBordspellen>();
            var id = bordspel.Id;
            var file = makeImage();
            mock.Setup(x => x.InsertBordspel(bordspel));
            //mock.Setup(x => x.GetBordspelById(id)).Returns(bordspel);

            //Act
            BordspelController controller = new BordspelController(mock.Object);
            controller.Create(bordspel, file);
            //var bordspelCreated = controller.Details(bordspel.Id);

            
            //Assert
            //Assert.Same(bordspel,bordspelCreated.Model);

        }*/

        //----------Get By Id----------------------------------
        /*[Fact]
        public void Can_Use_Repository_To_GetBordspelById()
        {
            //Arrange
            var id = bordspel.Id;
            Mock<IRepositoryBordspellen> mock = new Mock<IRepositoryBordspellen>();
            mock.Setup(x => x.GetBordspelById(id)).Returns(bordspel);

            //Act
            var controller = new BordspelController(mock.Object);
            var actual = controller.Details(id);

            //Assert
            Assert.Same(bordspel, actual.Model);
        }*/

        //----------Update By Id-----------------------------
        /*[Fact]
        public void Can_Use_Repository_To_UpdateBordspelById()
        {
            //Arrange
            Mock<IRepositoryBordspellen> mock = new Mock<IRepositoryBordspellen>();



            var id = bordspel.Id;
            var file = makeImage();

            //Deep copy
            var bordspelVoor = new Bordspel { Naam = bordspel.Naam, genre = bordspel.genre, Id = bordspel.Id, foto = bordspel.foto, AchtienPlus =bordspel.AchtienPlus, Description = bordspel.Description, soortSpel = bordspel.soortSpel };
            mock.Setup(x => x.InsertBordspel(bordspel));
            mock.Setup(x => x.UpdateBordspel(bordspel));
            mock.Setup(x => x.GetBordspelById(id)).Returns(bordspel);
            
            //Act
            BordspelController controller = new BordspelController(mock.Object);
            controller.Edit(bordspel, file);
            var bordspelCreated = controller.Details(bordspel.Id);

            //Assert
            Assert.NotSame(bordspelVoor, bordspel);
        }*/

        //----------Delete By Id------------------------------
        /*[Fact]
        public void Can_Use_Repository_To_DeleteBordspelById()
        {
            //voegt niet een echt object toe wanneer setup insert wordt gedaan.
            //Arrange
            Mock<IRepositoryBordspellen> mock = new Mock<IRepositoryBordspellen>();
            var id = bordspel.Id;
            var file = makeImage();

            mock.Setup(x => x.InsertBordspel(bordspel));

            BordspelController controller = new BordspelController(mock.Object);
            IEnumerable<Bordspel>? result = (controller.Index() as ViewResult)?
                .ViewData.Model as IEnumerable<Bordspel>;


            mock.Setup(x => x.DeleteBordspel(id));

            //Act
            controller.DeleteConfirmed(id);
            
            //Assert
            Bordspel[] bordspelArray = result?.ToArray() ?? Array.Empty<Bordspel>();
            Assert.True(bordspelArray.Length == 0);
        }*/
    }
}
