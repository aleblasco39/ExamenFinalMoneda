using System;

namespace ExamenFinalMoneda.InfraestructuraTransversal.ServicesException
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}