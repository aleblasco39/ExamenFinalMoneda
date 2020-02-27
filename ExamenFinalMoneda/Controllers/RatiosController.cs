using ExamenFinalMoneda.InfraestructuraTransversal.ControllerException;
using ExamenFinalMoneda.Services.Repository.RatioRepository;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExamenFinalMoneda.Controllers
{
    public class RatiosController : Controller
    {
        private IRatiosRepository repositorio = null;

        public RatiosController()
        {
            this.repositorio = new RatiosRepository();
        }

        public RatiosController(IRatiosRepository repositorio)
        {
            this.repositorio = repositorio;
        }


        // GET: Ratios
        public async Task<ActionResult> Index()
        {
            try
            {
                await repositorio.DatosApi();
                return View(await repositorio.GetAll());
            }
            catch (Exception ex)
            {
                throw new ControllerException("Error en task ActionResult Get", ex);
            }
        }

        // GET: Ratios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.ValidacionMetadataModel.Ratios ratios = await repositorio.GetById(id);
            if (ratios == null)
            {
                return HttpNotFound();
            }
            return View(ratios);
        }

        // GET: Ratios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ratios/Create
        // A protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,De,A,Ratio")] Models.ValidacionMetadataModel.Ratios ratios)
        {
            if (System.Web.Mvc.ModelState.IsValid)
            {
                repositorio.Insert(ratios);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(ratios);
        }

        // GET: Ratios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.ValidacionMetadataModel.Ratios ratios = await repositorio.GetById(id);
            if (ratios == null)
            {
                return HttpNotFound();
            }
            return View(ratios);
        }

        // POST: Ratios/Edit/5
        // A protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,from,to,rate")] Models.ValidacionMetadataModel.Ratios ratios)
        {
            if (System.Web.Mvc.ModelState.)
            {
                repositorio.Update(ratios);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(ratios);
        }

        // GET: Ratios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.ValidacionMetadataModel.Ratios ratios = await repositorio.GetById(id);
            if (ratios == null)
            {
                return HttpNotFound();
            }
            return View(ratios);
        }

        // POST: Ratios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Models.ValidacionMetadataModel.Ratios ratios = await repositorio.GetById(id);
            await repositorio.Delete(id);
            await repositorio.Save();
            return RedirectToAction("Index");
        }
    }
}