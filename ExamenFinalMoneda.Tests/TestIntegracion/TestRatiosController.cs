using System.Threading.Tasks;
using System.Web.Mvc;
using ExamenFinalMoneda.Controllers;
using ExamenFinalMoneda.Services.Repository.RatioRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamenFinalMoneda.Tests.PruebasIntegracion
{
    [TestClass]
    public class TestRatiosController
    {
        RatiosController ratioController = new RatiosController();
        private IRatiosRepository repositorio = new RatiosRepository();
        private Models.ValidacionMetadataModel.Ratios _ratios = new Models.ValidacionMetadataModel.Ratios { Desde = "USD", A = "EUR", Ratio = 0.65M };

        [TestMethod]
        public async Task Index()

        {
            var resultado = await ratioController.Index();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);

        }

        [TestMethod]
        public async Task create()

        {
            repositorio.Insert(_ratios);
            await repositorio.Save();
            var guardado = await repositorio.GetById(_ratios.Id);
            Assert.IsNotNull(guardado);

        }
    }
}