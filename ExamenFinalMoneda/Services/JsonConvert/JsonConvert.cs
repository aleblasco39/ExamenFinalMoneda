using System.Collections.Generic;

namespace ExamenFinalMoneda.Services.JsonConvert
{
    public class JsonConvert<T> : IJsonConvert<T> where T : class
    {
        public List<T> DeserializerJson(string contenido)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(contenido);
        }
    }
}