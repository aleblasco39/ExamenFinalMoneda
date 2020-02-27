using ExamenFinalMoneda.InfraestructuraTransversal.ServicesException;
using ExamenFinalMoneda.Models;
using ExamenFinalMoneda.Services.Specifaction;
using System;
using System.Collections.Generic;

namespace ExamenFinalMoneda.Services.Factory
{
    public class TransaccionFactory : ITransaccionFactory
    {
        private Transaccion _transaccion;


        private IValidacionTransaccionSpecification _validacionTransaccionSpecification = new ValidacionTransaccionSpecification();
        private List<Transaccion> ListaTransaction = new List<Transaccion>();
        public List<Transaccion> CreateTransaction(List<Models.ValidacionMetadataModel.Transaccion> transaccion)
        {
            try
            {

                foreach (var item in transaccion)
                {
                    if (_validacionTransaccionSpecification.TransactionIsSatisfiedBy(item) == true)
                    {
                        ListaTransaction.Add(item);
                    }
                    else { throw new FactoryException("No se ha podido crear el objeto transaccion "); }

                }

            }
            catch (Exception ex)
            {
                throw new FactoryException("No se ha podido crear el objeto de transaccion", ex)
                    ;
            }
            return ListaTransaction;
            ;
        }
    }
}