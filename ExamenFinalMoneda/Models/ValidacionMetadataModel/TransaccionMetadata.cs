using System.ComponentModel.DataAnnotations;

namespace ExamenFinalMoneda.Models.ValidacionMetadataModel
{
    public class TransaccionMetadata
    {
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string Cantidad { get; set; }
        [Required]
        public string Divisa { get; set; }
    }

    [MetadataType(typeof(TransaccionMetadata))]
    public partial class Transaccion
    {
        public object Sku { get; set; }
        public object Cantidad { get; set; }
        public object Divisa { get; set; }
        public object Id { get; set; }
    }
}
