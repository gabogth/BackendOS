using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.db.Utils
{
    public abstract class CrudRepositoryBase<TEntity, TCreateDto, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly NestDbContext context;
        protected readonly IMapper mapper;
        protected CrudRepositoryBase(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected virtual IQueryable<TEntity> Query() =>
            context.Set<TEntity>().AsNoTracking();
        protected virtual async Task<TEntity?> GetByIdAsync(TKey id) => await Query().FirstOrDefaultAsync(e => e.Id!.Equals(id));

        protected virtual async Task<List<TEntity>> GetAllAsync() => await Query().ToListAsync();


        protected virtual async Task<TEntity> AddAsync(TCreateDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TKey id, TCreateDto dto)
        {
            var entity = await context.Set<TEntity>().FindAsync(id)
                         ?? throw new RegistroNoEncontradoException<TEntity>(id!.ToString()!);

            mapper.Map(dto, entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id)
                         ?? throw new RegistroNoEncontradoException<TEntity>(id!.ToString()!);

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
