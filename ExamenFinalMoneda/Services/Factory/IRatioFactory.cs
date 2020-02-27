using ExamenFinalMoneda.Models;
using System.Collections.Generic;

namespace ExamenFinalMoneda.Services.Factory
{
    public interface IRatioFactory
    {
        List<Ratios> CreateRates(List<Models.ValidacionMetadataModel.Ratios> ratios);
    }
}
