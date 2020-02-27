using System.Threading.Tasks;
using ExamenFinalMoneda.Services.Repository.RatioRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamenFinalMoneda.Tests.PruebasUnitarias.Services
{
    [TestClass]
    public class TestRatioRepository
    {
        private IRatiosRepository repositorio = new RatiosRepository();
        private Models.ValidacionMetadataModel.Ratios _ratios = new Models.ValidacionMetadataModel.Ratios { Desde = "USD", A = "EUR", Ratio = 0.65M };


        [TestMethod]
        public async Task Repositorio()
        {

            repositorio.Insert(_ratios);
            await repositorio.Save();
            var guardado = await repositorio.GetById(_ratios.Id);
            Assert.IsNotNull(guardado);
            Assert.AreEqual(_ratios.Id, guardado.Id);
        }
    }
}
