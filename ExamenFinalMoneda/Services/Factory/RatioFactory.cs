using ExamenFinalMoneda.InfraestructuraTransversal.ServicesException;
using ExamenFinalMoneda.Models;
using ExamenFinalMoneda.Services.Specifaction;
using System;
using System.Collections.Generic;

namespace ExamenFinalMoneda.Services.Factory
{
    public class RatioFactory : IRatioFactory
    {
        private Ratios _ratios;


        private IValidacionRatioSpecification _validacionRatioSpecification = new ValidacionRatioSpecification();
        private List<Ratios> ListaRates = new List<Ratios>();
        public List<Ratios> CreateRates(List<Models.ValidacionMetadataModel.Ratios> ratios)
        {
            try
            {

                foreach (Models.ValidacionMetadataModel.Ratios item in ratios)
                {
                    if (_validacionRatioSpecification.RatesIsSatisfiedBy(item) == true)
                    {
                        ListaRates.Add(item);
                    }
                    else { throw new FactoryException("No se ha podido crear el objeto ratios "); }

                }

            }
            catch (Exception ex)
            {
                throw new FactoryException("No se ha podido crear el objeto ratios", ex);

            }
            return ListaRates;
        }
    }
}