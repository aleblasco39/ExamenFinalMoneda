using ExamenFinalMoneda.Models;

namespace ExamenFinalMoneda.Services.Specifaction
{
    public interface IValidacionTransaccionSpecification
    {
        bool TransactionIsSatisfiedBy(Transaccion registroTransaccion);

    }
}
