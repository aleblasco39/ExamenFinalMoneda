using ExamenFinalMoneda.Models.ViewModel;
using System.Data.Entity;

namespace ExamenFinalMoneda.DAL
{
    public class MonedaContext : DbContext
    {
        public MonedaContext() : base("MonedaContext")
        { }

        public DbSet<Models.ValidacionMetadataModel.Ratios> Ratios { get; set; }
        public DbSet<Models.ValidacionMetadataModel.Transaccion> Transaccion { get; set; }

        public System.Data.Entity.DbSet<VMtransactionBySku> VMtransactionBySkus { get; set; }
    }
}