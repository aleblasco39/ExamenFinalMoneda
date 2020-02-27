using ExamenFinalMoneda.Models;
using System.Collections.Generic;

namespace ExamenFinalMoneda.Services.Factory
{
    public interface ITransaccionFactory
    {
        List<Transaccion> CreateTransaction(List<Models.ValidacionMetadataModel.Transaccion> transaccion);
    }
}
