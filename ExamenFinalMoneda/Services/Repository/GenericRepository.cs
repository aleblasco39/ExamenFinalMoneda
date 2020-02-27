using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ExamenFinalMoneda.DAL;
using ExamenFinalMoneda.Services.JsonConvert;

namespace ExamenFinalMoneda.Services.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public MonedaContext _context = null;
        public DbSet<T> table = null;

        public IJsonConvert<T> _convert = null;

        public GenericRepository()
        {
            this._convert = new JsonConvert<T>();

            this._context = new MonedaContext();
            table = _context.Set<T>();
        }

        public GenericRepository(MonedaContext context)
        {
            this._convert = new JsonConvert<T>();
            this._context = context;
            table = _context.Set<T>();
        }

        public GenericRepository(MonedaContext context, IJsonConvert<T> converter)
        {
            this._convert = converter;
            this._context = context;
            table = _context.Set<T>();
        }




        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }

        public virtual void Insert(T obj)
        {
            table.Add(obj);
        }

        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }


        public virtual async Task<IEnumerable<Models.ValidacionMetadataModel.Ratios>> ListaRates()
        {
            return await _context.Ratios.ToListAsync();
        }


        public virtual async Task<IEnumerable<Models.ValidacionMetadataModel.Transaccion>> ListaTransaction()
        {
            return await _context.Transaccion.ToListAsync();
        }

        public abstract Task DatosApi();
        //public abstract Task DatosTransactionApi();

    }
}