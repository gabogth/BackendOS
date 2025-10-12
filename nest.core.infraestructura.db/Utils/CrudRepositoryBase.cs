using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio;
using nest.core.dominio.Transaccional;
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
        protected virtual async Task<List<TEntity?>> GetByIdsAsync(List<TKey> ids) => await Query().Where(e => ids.Contains(e.Id)).ToListAsync();
        protected virtual async Task<List<TEntity>> GetAllAsync() => await Query().ToListAsync();
        protected virtual async Task<TEntity> AddAsync(TCreateDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }

        // El orden de los entities estan garantizados
        protected virtual async Task<TEntity[]> AddRangeAsync(TCreateDto[] dtos)
        {
            if (dtos.Length == 0)
                return Array.Empty<TEntity>();
            var entities = dtos.Select(dto => mapper.Map<TEntity>(dto)).ToList();
            await context.Set<TEntity>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
            foreach (var entity in entities)
                await context.Entry(entity).ReloadAsync();
            return entities.ToArray();
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

        protected virtual async Task<TEntity[]> UpdateRangeAsync((TKey key, TCreateDto dto)[] entries)
        {
            if (entries.Length == 0)
                return Array.Empty<TEntity>();
            List<TKey> ids = entries.Select(e => e.key).ToList();
            var entities = await context.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToListAsync();
            if(ids.Count != entities.Count)
                throw new RegistroNoEncontradoException<TEntity, TKey>(ids);
            (TKey key, TCreateDto dto, TEntity entity)[] compiled = new (TKey key, TCreateDto dto, TEntity entity)[entries.Length];
            TEntity[] finalIndex = new TEntity[entries.Length];
            for (int i = 0; i < entries.Length; i++)
            {
                TKey currentKey = entries[i].key;
                TCreateDto currentDto = entries[i].dto;
                TEntity currentEntity = entities.First(x => x.Id.Equals(currentKey));
                mapper.Map(currentDto, currentEntity);
                compiled[i] = (currentKey, currentDto, currentEntity);
                finalIndex[i] = currentEntity;
            }
            await context.SaveChangesAsync();
            foreach (var entity in finalIndex)
                await context.Entry(entity).ReloadAsync();
            return finalIndex;
        }

        protected virtual async Task DeleteAsync(TKey id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id)
                         ?? throw new RegistroNoEncontradoException<TEntity>(id!.ToString()!);

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        protected virtual async Task DeleteRangeAsync(TKey[] ids)
        {
            var entities = await context.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToArrayAsync();
            if (ids.Length != entities.Length)
                throw new RegistroNoEncontradoException<TEntity, TKey>(ids.ToList());
            context.Set<TEntity>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        protected virtual async Task<TEntity[]> MergeRangeAsync(TEntity[] originalEntities, (TKey key, TCreateDto dto)[] entries)
        {
            TEntity[] finalEntities = new TEntity[entries.Length];
            var entiesDb = originalEntities.ToDictionary(p => p.Id);

            Dictionary<int, int> keysInsertar = new();
            Dictionary<int, int> keysModificar = new();
            int countPersonasInsertarTemp = 0;
            int countPersonasActualizarTemp = 0;
            List<TCreateDto> personasInsertarTemp = new List<TCreateDto>();
            List<(TKey key, TCreateDto dto)> personasActualizarTemp = new List<(TKey key, TCreateDto dto)>();
            for (int i = 0; i < entries.Length; i++) 
            {
                var currEntry = entries[i];
                if (entiesDb.ContainsKey(currEntry.key))
                {
                    personasActualizarTemp.Add(currEntry);
                    keysModificar.Add(i, countPersonasActualizarTemp);
                    countPersonasActualizarTemp++;
                }
                else
                {
                    personasInsertarTemp.Add(currEntry.dto);
                    keysInsertar.Add(i, countPersonasInsertarTemp);
                    countPersonasInsertarTemp++;
                }
            }

            var personasEliminar = entiesDb.Values
                .Where(p => !entries.Any(dto => dto.key.ToString() == p.Id.ToString()))
                .Select(p => p.Id)
                .ToArray();

            TCreateDto[] personasInsertar = personasInsertarTemp.ToArray();
            (TKey key, TCreateDto dto)[] personasActualizar = personasActualizarTemp.ToArray();

            TEntity[] inserted = await AddRangeAsync(personasInsertar);
            TEntity[] updated = await UpdateRangeAsync(personasActualizar);
            await DeleteRangeAsync(personasEliminar);

            for (int x = 0; x < entries.Length; x++)
                finalEntities[x] = keysInsertar.ContainsKey(x) ? inserted[keysInsertar[x]] : updated[keysModificar[x]];

            return finalEntities;
        }

        protected TEntity[] GetOrderedArrayFrom(IEnumerable<TEntity> arrayDesordenado, TEntity[] arrayOrdenado)
        {
            TEntity[] ordered = new TEntity[arrayOrdenado.Length];
            Dictionary<TKey, TEntity> index = arrayDesordenado.ToDictionary(e => e.Id);
            for (int i = 0; i < arrayOrdenado.Length; i++)
                ordered[i] = index[arrayOrdenado[i].Id];
            return ordered;
        }
    }
}
