namespace ExamenFinalMoneda.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Cantidad { get; set; }
        public string Divisa { get; set; }
    }
}