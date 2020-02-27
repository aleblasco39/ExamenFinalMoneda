using System.Threading.Tasks;
using System.Web.Mvc;
using ExamenFinalMoneda.Controllers;
using ExamenFinalMoneda.Services.Repository.TransaccionRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamenFinalMoneda.Models;

namespace ExamenFinalMoneda.Tests.PruebasIntegracion
{
    [TestClass]
    public class TestTransaccionController
    {
        private TransaccionController transaccionController = new TransaccionController();
        private ITransaccionRepository repositorio = new TransaccionRepository();
        private Models.ValidacionMetadataModel.Transaccion _transaccion = new Models.ValidacionMetadataModel.Transaccion { Sku = "C6618", Cantidad = 33.9M, Divisa = "USD" };

        [TestMethod]
        public async Task Index()

        {
            var resultado = await transaccionController.Index();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);

        }

        [TestMethod]
        public async Task create()

        {
            repositorio.Insert(_transaccion);
            await repositorio.Save();
            var guardado = await repositorio.GetById(_transaccion.Id);
            Assert.IsNotNull(guardado);

        }
    }
}