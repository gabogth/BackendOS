using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
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
        Task<RegistroAsistencia> BuscarPorRangoFecha(int personalId, DateTime fechaInicio, DateTime fechaFin, HorarioDetalleEventoTipoEnum tipoMarca);
        Task<RegistroAsistencia> Agregar(RegistroAsistenciaCrearDto entidad);
        Task<RegistroAsistencia> Modificar(long id, RegistroAsistenciaCrearDto entidad);
        Task Eliminar(long id);
    }
}
