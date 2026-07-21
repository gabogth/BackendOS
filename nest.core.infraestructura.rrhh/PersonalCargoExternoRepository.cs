using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh
{
    public class PersonalCargoExternoRepository : CrudRepositoryBase<PersonalCargoExterno, long>, IPersonalCargoExternoRepository
    {
        private readonly NestDbContext context;

        public PersonalCargoExternoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
        }

        public async Task<PersonalCargoExterno> ObtenerPorId(long id) => await GetByIdAsync(id);
        public async Task<List<PersonalCargoExterno>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<PersonalCargoExterno>> ObtenerPorPersonal(int personalId) => await context.Set<PersonalCargoExterno>().Where(x => x.PersonalId == personalId).ToListAsync();
        public async Task<List<PersonalCargoExterno>> ObtenerPorCargo(int cargoId) => await context.Set<PersonalCargoExterno>().Where(x => x.CargoId == cargoId).ToListAsync();
        public Task<PersonalCargoExterno> Agregar(PersonalCargoExterno entry) => AddAsync(entry);
        public async Task<PersonalCargoExterno> Modificar(PersonalCargoExterno entry)
        {
            var response = await UpdateAsync(entry);
            return await ObtenerPorId(response.Id);
        }
        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
