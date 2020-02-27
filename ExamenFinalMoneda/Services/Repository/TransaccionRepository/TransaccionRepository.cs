using ExamenFinalMoneda.InfraestructuraTransversal.ServicesException;
using ExamenFinalMoneda.Models.ValidacionMetadataModel;
using ExamenFinalMoneda.Models.ViewModel;
using ExamenFinalMoneda.Services.Factory;
using ExamenFinalMoneda.Services.Specifaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamenFinalMoneda.Services.Repository.TransaccionRepository
{
    public class TransaccionRepository : GenericRepository<Transaccion>, ITransaccionRepository
    {
        public override async Task DatosApi()

        {
            IValidacionTransaccionSpecification validacionTransaccionSpecification = new ValidacionTransaccionSpecification();
            ITransaccionFactory transaccionFactory = new TransaccionFactory();


            using (var client = new HttpClient())
            {

                try
                {
                    HttpResponseMessage response = client.GetAsync("http://quiet-stone-2094.herokuapp.com/transactions.json").Result;
                    List<Transaccion> lista;
                    string contenido = response.Content.ReadAsStringAsync().Result;
                    {

                        lista = _convert.DeserializerJson(contenido);
                    }

                    table.RemoveRange(table);

                    List<Models.Transaccion> listaTransaction = transaccionFactory.CreateTransaction(lista);

                    table.AddRange(listaTransaction);


                    await _context.SaveChangesAsync();



                }
                catch (HttpRequestException) { }
                catch (Exception ex) { throw new RepositoryException("Fallo en el repositorio Transaccion", ex); }
            }
        }

        public IQueryable<Transaccion> ListadoTransactionBySku(string numeroTransaction)
        {
            var query = _context.Transaccion.Where(j => j.Sku == numeroTransaction);

            return query;
        }

        public List<VMtransactionBySku> ListaSku()
        {
            {
                var nuevaLista = new List<VMtransactionBySku>();
                var SegundaQuery = (from j in _context.Transaccion
                                    group j by j.Sku
                    into transaction
                                    select new
                                    {
                                        Nombre = transaction.Key,
                                        Suma = transaction.Sum(m => m.Cantidad as int?),

                                    });


                foreach (var item in SegundaQuery)
                {
                    var nuevoTx = new VMtransactionBySku();
                    nuevoTx.Suma = (decimal) item.Suma;
                    nuevoTx.Currency = "EUR";
                    nuevaLista.Add(nuevoTx);
                }

                return nuevaLista;
            }
        }

    }
}