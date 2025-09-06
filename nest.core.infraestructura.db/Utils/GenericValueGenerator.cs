using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura
{
    public class GenericValueGenerator<T> : ValueGenerator<T>
    {
        public override bool GeneratesTemporaryValues => false;
        public override T Next(EntityEntry entry) => GeneradorCorrelativo.GetValue<T>(entry);
        public override async ValueTask<T> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync<T>(entry, null, cancellationToken);
    }
}
