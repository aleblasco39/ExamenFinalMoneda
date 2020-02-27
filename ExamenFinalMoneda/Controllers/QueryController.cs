using ExamenFinalMoneda.Services.Repository.RatioRepository;
using ExamenFinalMoneda.Services.Repository.TransaccionRepository;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExamenFinalMoneda.Controllers
{
    public class QueryController : BaseController
    {
        // GET: Query
        public async Task<ActionResult> ListadoSku(string sku)
        {
            ITransaccionRepository repositoriotrans = new TransaccionRepository();
            IRatiosRepository repositoriorates = new RatiosRepository();
            var lista = repositoriotrans.ListadoTransactionBySku(sku);

            return View(lista.ToList());
        }

        public async Task<ActionResult> Sum()
        {

            ITransaccionRepository repositoriotrans = new TransaccionRepository();
            IRatiosRepository repositoriorates = new RatiosRepository();
            await repositoriotrans.DatosApi();
            await repositoriorates.DatosApi();
            var Segundalista = repositoriotrans.ListaSku();
            return View(Segundalista);
        }
    }
}