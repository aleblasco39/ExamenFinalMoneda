using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamenFinalMoneda.Services.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        Task Delete(object id);
        Task Save();

        Task DatosApi();
        //Task DatosTransactionApi();


    }
}
