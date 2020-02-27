using ExamenFinalMoneda.InfraestructuraTransversal.ServicesException;
using ExamenFinalMoneda.Models;
using System;

namespace ExamenFinalMoneda.Services.Specifaction
{
    public class ValidacionTransaccionSpecification : IValidacionTransaccionSpecification
    {
        public bool TransactionIsSatisfiedBy(Transaccion registroTransaccion)
        {
            try
            {
                return !registroTransaccion.Sku.Equals("")
                       && registroTransaccion.Sku != null

                       && !registroTransaccion.Cantidad.Equals("")
                       && registroTransaccion.Cantidad != null

                       && !registroTransaccion.Divisa.Equals("")
                       && registroTransaccion.Divisa != null;
            }
            catch (Exception ex)
            {
                throw new ValidacionSpecificationException("No se han podido validar las transaction", ex);
            }

        }

    }
}
