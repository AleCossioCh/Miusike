//using System;
//using System.Collections.Generic;
//using System.Text;
using AutoMapper;
using Moq;
using ProyectoMiusike.Data;
using ProyectoMiusike.Data.Entity;
using ProyectoMiusike.Data.Repository;
using ProyectoMiusike.Exceptions;
using ProyectoMiusike.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace xUnitPrueba1
{
    public class UnitTest2
    {
        [Fact]
        public async Task Test1Async()
        {
            int cancionId = 69;
            var MoqlibraryRespository = new Mock<IWindAppRepository>();
            var cancionEntity = new CacionEntity() { Id = 1, Nombre = "PabloGaspar", Duracio = 5, Votacion = 12, Ventas = 94, Genero= "Masculino"};
            MoqlibraryRespository.Setup(m => m.GetCancionAsync(cancionId, false)).Returns(Task.FromResult(cancionEntity));

            var myProfile = new WindAppProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            var cancionService = new CancionService(MoqlibraryRespository.Object, mapper);
            //act 
            await Assert.ThrowsAsync<NotFoundException>(() => cancionService.ObtenerCancionAsync(1,69));
        }
    }
}
