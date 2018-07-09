namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuoteContext : DbContext
    {
        public QuoteContext()
            : base("name=QuoteContext")
        {
        }

        public virtual DbSet<Cotizaciones> Cotizaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
