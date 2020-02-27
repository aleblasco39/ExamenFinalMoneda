using ExamenFinalMoneda.Services.Repository.TransaccionRepository;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExamenFinalMoneda.Controllers
{
    public class TransaccionController : BaseController
    {

        private ITransaccionRepository repositorio = null;

        public TransaccionController()
        {
            this.repositorio = new TransaccionRepository();
        }

        public TransaccionController(ITransaccionRepository repositorio)
        {
            this.repositorio = repositorio;
        }


        // GET: Transactions
        public async Task<ActionResult> Index()
        {
            await repositorio.DatosApi();
            return View(await repositorio.GetAll());
        }

        // GET: Transactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.ValidacionMetadataModel.Transaccion transaccion = await repositorio.GetById(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // A protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sku,Cantidad,Divisa")] Models.ValidacionMetadataModel.Transaccion transaccion)
        {
            if (System.Web.Mvc.ModelState.IsValid)
            {
                repositorio.Insert(transaccion);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(transaccion);
        }

        // GET: Transactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.ValidacionMetadataModel.Transaccion transaccion = await repositorio.GetById(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transactions/Edit/5
        // A protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sku,Cantidad,Divisa")] Models.ValidacionMetadataModel.Transaccion transaccion)
        {
            if (System.Web.Mvc.ModelState.IsValid)
            {
                repositorio.Update(transaccion);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(transaccion);
        }

        // GET: Transactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.ValidacionMetadataModel.Transaccion transaccion = await repositorio.GetById(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Models.ValidacionMetadataModel.Transaccion transaccion = await repositorio.GetById(id);
            await repositorio.Delete(id);
            await repositorio.Save();
            return RedirectToAction("Index");
        }

    }
}