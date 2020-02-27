using ExamenFinalMoneda.InfraestructuraTransversal.ServicesException;
using System;

namespace ExamenFinalMoneda.Services.Specifaction
{
    public class ValidacionRatioSpecification : IValidacionRatioSpecification
    {
        public bool RatesIsSatisfiedBy(Models.ValidacionMetadataModel.Ratios registroRatios)
        {
            try
            {
                return !registroRatios.Desde.Equals("")
                       && registroRatios.Ratio != null

                       && !registroRatios.A.Equals("")
                       && registroRatios.A != null

                       && !registroRatios.Ratio.Equals("")
                       && registroRatios.Ratio != null;
            }
            catch (Exception ex)
            {
                throw new ValidacionSpecificationException("No se han podido validar los ratios", ex);
            }
        }
    }
}
