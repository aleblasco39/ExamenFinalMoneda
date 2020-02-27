
namespace ExamenFinalMoneda.Services.Specifaction
{
    public interface IValidacionRatioSpecification
    {
        bool RatesIsSatisfiedBy(Models.ValidacionMetadataModel.Ratios registroRatios);
    }
}
