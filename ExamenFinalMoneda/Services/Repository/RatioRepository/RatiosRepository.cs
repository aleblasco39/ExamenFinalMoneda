using ExamenFinalMoneda.InfraestructuraTransversal.ServicesException;
using ExamenFinalMoneda.Models.ValidacionMetadataModel;
using ExamenFinalMoneda.Services.Factory;
using ExamenFinalMoneda.Services.Specifaction;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamenFinalMoneda.Services.Repository.RatioRepository
{
    public class RatiosRepository : GenericRepository<Ratios>, IRatiosRepository
    {
        public override async Task DatosApi()

        {
            IValidacionRatioSpecification validacionRatioSpecification = new ValidacionRatioSpecification();
            IRatioFactory ratiosFactory = new RatioFactory();


            using (var client = new HttpClient())
            {

                try
                {
                    HttpResponseMessage response = client.GetAsync("http://quiet-stone-2094.herokuapp.com/rates.json").Result;
                    List<Ratios> lista;
                    string contenido = response.Content.ReadAsStringAsync().Result;
                    {

                        lista = _convert.DeserializerJson(contenido);
                    }

                    table.RemoveRange(table);



                    var listaRatios = ratiosFactory.CreateRates(lista);

                    table.AddRange(listaRatios);

                    await _context.SaveChangesAsync();



                }
                catch (HttpRequestException) { }
                catch (Exception ex) { throw new RepositoryException("Fallo en el repositorio Ratios", ex); }



            }
        }
    }
}