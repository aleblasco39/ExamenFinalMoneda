using ExamenFinalMoneda.Services.Repository.TransaccionRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ExamenFinalMoneda.Tests.PruebasUnitarias.Services
{
    [TestClass]
    public class TestTransaccionRepository
    {
        private ITransaccionRepository repositorio = new TransaccionRepository();
        private Models.ValidacionMetadataModel.Transaccion _transaccion = new Models.ValidacionMetadataModel.Transaccion { Sku = "C6618", Cantidad = 33.9M, Divisa = "USD" };


        [TestMethod]
        public async Task Repositorio()
        {

            repositorio.Insert(_transaccion);
            await repositorio.Save();
            var guardado = await repositorio.GetById(_transaccion.Id);
            Assert.IsNotNull(guardado);
            Assert.AreEqual(_transaccion.Id, guardado.Id);
        }
    }
}
