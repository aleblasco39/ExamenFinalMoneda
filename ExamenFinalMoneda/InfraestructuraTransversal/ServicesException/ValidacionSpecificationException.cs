using System;

namespace ExamenFinalMoneda.InfraestructuraTransversal.ServicesException
{
    public class ValidacionSpecificationException : Exception
    {
        public ValidacionSpecificationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}