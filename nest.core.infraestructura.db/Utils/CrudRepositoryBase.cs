using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
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
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }

        protected virtual async Task<IEnumerable<TEntity>> AddRangeAsync(List<TCreateDto> dtos)
        {
            var entities = dtos.Select(dto => mapper.Map<TEntity>(dto));
            await context.Set<TEntity>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
            foreach (var entity in entities)
                await context.Entry(entity).ReloadAsync();
            return entities;
        }

        protected virtual async Task<TEntity> UpdateAsync(TKey id, TCreateDto dto)
        {
            var entity = await context.Set<TEntity>().FindAsync(id)
                         ?? throw new RegistroNoEncontradoException<TEntity>(id!.ToString()!);
            mapper.Map(dto, entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }

        protected virtual async Task<IEnumerable<TEntity>> UpdateRangeAsync(List<(TKey key, TCreateDto dto)> entries)
        {
            List<TKey> ids = entries.Select(e => e.key).ToList();
            var entities = await context.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToListAsync();
            if(ids.Count != entities.Count)
                throw new RegistroNoEncontradoException<TEntity, TKey>(ids);
            List<(TKey key, TCreateDto dto, TEntity entity)> compiled = new List<(TKey key, TCreateDto dto, TEntity entity)>();
            foreach(var entry in entries)
                compiled.Add((entry.key, entry.dto, entities.First(x => x.Id.Equals(entry.key))));
            compiled.ForEach(x => mapper.Map(x.dto, x.entity));
            await context.SaveChangesAsync();
            foreach (var entity in entities)
                await context.Entry(entity).ReloadAsync();
            return entities;
        }

        protected virtual async Task DeleteAsync(TKey id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id)
                         ?? throw new RegistroNoEncontradoException<TEntity>(id!.ToString()!);

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        protected virtual async Task DeleteRangeAsync(List<TKey> ids)
        {
            var entities = await context.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToListAsync();
            if (ids.Count != entities.Count)
                throw new RegistroNoEncontradoException<TEntity, TKey>(ids);
            context.Set<TEntity>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        protected virtual async Task<IEnumerable<TEntity>> MergeRangeAsync(List<TEntity> originalEntities, List<(TKey key, TCreateDto dto)> entries)
        {
            List<TEntity> compiledEntities = new List<TEntity>();
            var entiesDb = originalEntities.ToDictionary(p => p.Id);
            var entiesDto = entries;

            var personasInsertar = entiesDto
                    .Where(p => !entiesDb.ContainsKey(p.key))
                    .Select(x => x.dto)
                    .ToList();
            var personasActualizar = entiesDto
                .Where(p => entiesDb.ContainsKey(p.key))
                .ToList();
            var personasEliminar = entiesDb.Values
                .Where(p => !entiesDto.Any(dto => dto.key.ToString() == p.Id.ToString()))
                .Select(p => p.Id)
                .ToList();

            IEnumerable<TEntity> inserted = await AddRangeAsync(personasInsertar);
            IEnumerable<TEntity> updated = await UpdateRangeAsync(personasActualizar);
            await DeleteRangeAsync(personasEliminar);
            compiledEntities.AddRange(inserted);
            compiledEntities.AddRange(updated);

            return compiledEntities;
        }
    }
}
