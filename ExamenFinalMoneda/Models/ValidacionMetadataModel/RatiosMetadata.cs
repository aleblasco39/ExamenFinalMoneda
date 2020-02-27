using System.ComponentModel.DataAnnotations;

namespace ExamenFinalMoneda.Models.ValidacionMetadataModel
{

    public class RatiosMetadata
        {

            public int Id { get; set; }
            [Required]
            public string Desde { get; set; }
            [Required]
            public string A { get; set; }
            [Required]
            public string Ratio { get; set; }
        }

        [MetadataType(typeof(RatiosMetadata))]
        public partial class Ratios
        {
            public string Desde { get; set; }
            public object Ratio { get; set; }
            public string A { get; set; }
            public object Id { get; set; }
         
        }
    }
