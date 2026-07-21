using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.RRHH.PersonalCargoExternoEntities
{
    public interface IPersonalCargoExternoRepository
    {
        Task<PersonalCargoExterno> ObtenerPorId(long id);
        Task<List<PersonalCargoExterno>> ObtenerTodos();
        Task<List<PersonalCargoExterno>> ObtenerPorPersonal(int personalId);
        Task<List<PersonalCargoExterno>> ObtenerPorCargo(int cargoId);
        Task<PersonalCargoExterno> Agregar(PersonalCargoExterno entidad);
        Task<PersonalCargoExterno> Modificar(PersonalCargoExterno entidad);
        Task Eliminar(long id);
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken ct);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken ct);
    }
}
