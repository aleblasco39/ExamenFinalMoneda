using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamenFinalMoneda.Tests.PruebasUnitarias.Model
{
    [TestClass]
    public class TestRatioModel
    {
        [TestMethod]
        public void RatesCorrecto()
        {

            Models.ValidacionMetadataModel.Ratios ratios = new Models.ValidacionMetadataModel.Ratios { Desde = "USD", A = "EUR", Ratio = 0.65M };
            Assert.IsNotNull(ratios);

        }

        [TestMethod]
        public void RatesPrimeroVacio()
        {

            Models.ValidacionMetadataModel.Ratios ratios = new Models.ValidacionMetadataModel.Ratios { Desde = "", A = "EUR", Ratio = 0.65M };
            Assert.IsTrue(string.IsNullOrEmpty(ratios.Desde));


        }

        [TestMethod]
        public void RatesSegundoVacio()
        {

            Models.ValidacionMetadataModel.Ratios ratios = new Models.ValidacionMetadataModel.Ratios { Desde = "USD", A = "", Ratio = 0.65M };
            Assert.IsTrue(string.IsNullOrEmpty(ratios.A));


        }

        [TestMethod]
        public void RatesTercerNumerico()
        {

            Models.ValidacionMetadataModel.Ratios ratios = new Models.ValidacionMetadataModel.Ratios { Desde = "USD", A = "", Ratio = 0.65M };
            Assert.IsNotNull(ratios.Ratio);


        }

    }
}
