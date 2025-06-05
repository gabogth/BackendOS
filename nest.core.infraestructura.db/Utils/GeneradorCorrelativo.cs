using nest.core.dominio.Security.Audit;
using Microsoft.EntityFrameworkCore;

namespace nest.core.infraestructura
{
    public class GeneradorCorrelativo
    {
        public static long GetValue(DbContext context, string schema, string table)
        {
            return GetNext(context, schema, table);
        }
        public static async Task<long> GetValueAsync(DbContext context, string schema, string table, CancellationToken cancellationToken = default)
        {
            return await GetNextAsync(context, schema, table);
        }

        private static async Task<long> GetNextAsync(DbContext ctx, string esquema, string tabla)
        {
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
                    return 1;
                }
            }
            var id = correl.LastValue + 1;
            correl.LastValue = id;
            return id;
        }

        private static long GetNext(DbContext ctx, string esquema, string tabla)
        {
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
                        LastValue = 1
                    };
                    ctx.Set<CorrelativoMaestro>().Add(correl);
                    return 1;
                }
            }
            var id = correl.LastValue + 1;
            correl.LastValue = id;
            return id;
        }
    }
}
