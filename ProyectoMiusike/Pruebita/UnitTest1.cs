using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoMiusike.Data;
using ProyectoMiusike.Data.Entity;
using ProyectoMiusike.Data.Repository;
using ProyectoMiusike.Exceptions;
using ProyectoMiusike.Services;
using System.Threading.Tasks;

namespace Pruebita
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            int artistaId = 69;
            var MoqlibraryRespository = new Mock<IWindAppRepository>();
            var artistaEntity = new ArtistaEntity() { Id = 1, edad = 22, nombre = "S-kap", biografia = "mas progresivos que la palabra", imgPath = "http"};
            MoqlibraryRespository.Setup(m => m.GetArtistasAsync(artistaId, false)).Returns(Task.FromResult(artistaEntity));

            var myProfile = new WindAppProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            var artistaService = new ArtistaService(MoqlibraryRespository.Object, mapper);
            //act 
            await Assert.ThrowsExceptionAsync<NotFoundException>(() => artistaService.ObtenerArtistaAsync(1, false));
        }
    }
}
