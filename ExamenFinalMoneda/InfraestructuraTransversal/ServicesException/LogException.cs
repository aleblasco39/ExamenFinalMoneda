using System;

namespace ExamenFinalMoneda.InfraestructuraTransversal.ServicesException
{
    public class LogException : Exception
    {
        public LogException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}