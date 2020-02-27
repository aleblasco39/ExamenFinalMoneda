using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamenFinalMoneda.Tests.PruebasUnitarias.Model
{
    [TestClass]
    public class TestTransaccionModel
    {
        [TestMethod]
        public void TransactionCorrecto()
        {

            Models.ValidacionMetadataModel.Transaccion transaccion = new Models.ValidacionMetadataModel.Transaccion { Sku = "C6618", Cantidad= 33.9M, Divisa = "USD" };
            Assert.IsNotNull(transaccion);


        }
    }
}
