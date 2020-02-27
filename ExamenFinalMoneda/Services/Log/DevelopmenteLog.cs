using ExamenFinalMoneda.InfraestructuraTransversal.ServicesException;
using System;

namespace ExamenFinalMoneda.Services.Log
{
    public class DevelopmenteLog : ILog
    {
        public void WriteLog(string mensaje)
        {

            var date = DateTime.Now;

            try
            {
                Console.WriteLine($"[{date}] {mensaje}");
            }
            catch (Exception ex)
            {
                throw new LogException("No se ha podido escribir en la consola", ex);
            }
        }
    }
}