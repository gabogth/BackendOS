using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.dominio.Finanzas.FinancieroLogisticaEntities;
using nest.core.dominio.Finanzas.FinancieroOrdenServicioEntities;
using nest.core.dominio.Finanzas.MonedaEntities;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<CuentaCorriente> CuentaCorriente { get; set; }
        public DbSet<EntidadFinanciera> EntidadFinanciera { get; set; }
        public DbSet<FinancieroCabecera> FinancieroCabecera { get; set; }
        public DbSet<FinancieroDetalle> FinancieroDetalle { get; set; }
        public DbSet<FinancieroLogistica> FinancieroLogistica { get; set; }
        public DbSet<FinancieroOrdenServicio> FinancieroOrdenServicio { get; set; }
        public DbSet<Moneda> Moneda { get; set; }
        public DbSet<OrigenFinanciero> OrigenFinanciero { get; set; }
        public DbSet<PuntoFinanciero> PuntoFinanciero { get; set; }
        public DbSet<Tercero> Tercero { get; set; }
    }
}
