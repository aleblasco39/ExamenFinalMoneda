using ExamenFinalMoneda.Models.ValidacionMetadataModel;
using ExamenFinalMoneda.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ExamenFinalMoneda.Services.Repository.TransaccionRepository
{
    public interface ITransaccionRepository : IGenericRepository<Transaccion>
    {
        IQueryable<Transaccion> ListadoTransactionBySku(string numeroTransaction);
        List<VMtransactionBySku> ListaSku();
    }
}
