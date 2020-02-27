using ExamenFinalMoneda.Services.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamenFinalMoneda.Tests.PruebasUnitarias.Services
{
    [TestClass]
    public class LogServicesTest
    {
        public string Contain = "";
        private readonly ILog _log = new ProductionLog();

        [TestInitialize]
        public void LogServiceInit()
        {
            Contain = "¡Testeando si esto funciona!";
            _log.WriteLog(Contain);
        }

        [TestMethod]
        public void LogWrite()
        {
            _log.WriteLog(Contain);
        }
    }
}
