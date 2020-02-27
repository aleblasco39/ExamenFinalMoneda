using System.Collections.Generic;

namespace ExamenFinalMoneda.Services.JsonConvert
{
    public interface IJsonConvert<T> where T : class
    {

        List<T> DeserializerJson(string contenido);
    }
}
