using System.ComponentModel.DataAnnotations;

namespace ExamenFinalMoneda.Models.ViewModel
{
    public class VMtransactionBySku
    {
        [Key]
        public string Sku { get; set; }
        public string Currency { get; set; }
        public decimal Suma { get; set; }

    }
}