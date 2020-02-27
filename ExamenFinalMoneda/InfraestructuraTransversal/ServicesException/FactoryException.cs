using System;

namespace ExamenFinalMoneda.InfraestructuraTransversal.ServicesException
{
    public class FactoryException : Exception
    {
        public FactoryException(string message) : base(message)
        {
        }

        public FactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}