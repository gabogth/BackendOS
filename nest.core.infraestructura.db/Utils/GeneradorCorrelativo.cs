using nest.core.dominio.Security.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace nest.core.infraestructura
{
    public class GeneradorCorrelativo
    {
        private static int PRIMER_NUMERO_CONTADOR = 1;
        private static int OFFSET_CONTADOR = 1;
        public static T GetValue<T>(EntityEntry entry)
        {
            return GetNext<T>(entry);
        }
        public static async Task<T> GetValueAsync<T>(EntityEntry entry, CancellationToken cancellationToken = default)
        {
            return await GetNextAsync<T>(entry);
        }

        private static async Task<T> GetNextAsync<T>(EntityEntry entry)
        {
            string esquema = entry.Metadata.GetSchema() ?? "dbo";
            string tabla = entry.Metadata.GetTableName();
            DbContext ctx = entry.Context;

            var correl = ctx.ChangeTracker
                            .Entries<CorrelativoMaestro>()
                            .FirstOrDefault(e =>
                                   e.Entity.Schema == esquema &&
                                   e.Entity.Table == tabla)?
                            .Entity;
            if (correl == null)
            {
                correl = await ctx.Set<CorrelativoMaestro>()
                                  .FirstOrDefaultAsync(c =>c.Schema == esquema && c.Table == tabla);
                if (correl == null)
                {
                    correl = new CorrelativoMaestro
                    {
                        Schema = esquema,
                        Table = tabla,
                        LastValue = 1
                    };
                    await ctx.Set<CorrelativoMaestro>().AddAsync(correl);
                    return (T)Convert.ChangeType(PRIMER_NUMERO_CONTADOR, typeof(T));
                }
            }
            var id = correl.LastValue + OFFSET_CONTADOR;
            correl.LastValue = id;
            return (T)Convert.ChangeType(id, typeof(T));
        }

        private static T GetNext<T>(EntityEntry entry)
        {
            string esquema = entry.Metadata.GetSchema() ?? "dbo";
            string tabla = entry.Metadata.GetTableName();
            DbContext ctx = entry.Context;

            var correl = ctx.ChangeTracker
                            .Entries<CorrelativoMaestro>()
                            .FirstOrDefault(e =>
                                   e.Entity.Schema == esquema &&
                                   e.Entity.Table == tabla)?
                            .Entity;
            if (correl == null)
            {
                correl = ctx.Set<CorrelativoMaestro>()
                    .FirstOrDefault(c => c.Schema == esquema && c.Table == tabla);
                if (correl == null)
                {
                    correl = new CorrelativoMaestro
                    {
                        Schema = esquema,
                        Table = tabla,
                        LastValue = PRIMER_NUMERO_CONTADOR
                    };
                    ctx.Set<CorrelativoMaestro>().Add(correl);
                    return (T)Convert.ChangeType(PRIMER_NUMERO_CONTADOR, typeof(T));
                }
            }
            var id = correl.LastValue + OFFSET_CONTADOR;
            correl.LastValue = id;
            return (T)Convert.ChangeType(id, typeof(T));
        }
    }
}
