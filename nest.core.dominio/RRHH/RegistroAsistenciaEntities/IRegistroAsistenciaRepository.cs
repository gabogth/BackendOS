using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.dominio.RRHH.RegistroAsistenciaEntities
{
    public interface IRegistroAsistenciaRepository
    {
        Task<RegistroAsistencia> ObtenerPorId(long id);
        Task<List<RegistroAsistencia>> ObtenerTodos();
        Task<List<RegistroAsistencia>> BuscarPorRangoFecha(int personalId, DateTime fechaInicio, DateTime fechaFin);
        Task<RegistroAsistencia> Agregar(RegistroAsistenciaCrearDto entidad);
        Task<RegistroAsistencia> Modificar(long id, RegistroAsistenciaCrearDto entidad);
        Task Eliminar(long id);
    }
}
