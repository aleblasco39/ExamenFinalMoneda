using System;
using System.IO;

namespace ExamenFinalMoneda.Services.Log
{
    public class ProductionLog : ILog
    {
        private readonly string _path;

        public ProductionLog()
        {
            _path = AppDomain.CurrentDomain.BaseDirectory + "LogGenerado";
            Directory.CreateDirectory(_path);
        }

        public void WriteLog(string mensaje)
        {
            var fecha = DateTime.Now.ToString("dd/MM/yyyy");
            var hora = DateTime.Now.ToString("HH:mm:ss");

            using (var sw = new StreamWriter(_path + "/log.txt", true))
            {
                sw.WriteLine("[" + fecha + " " + hora + "] " + mensaje);
            }
        }
    }
}