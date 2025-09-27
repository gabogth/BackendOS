using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaServices
{
    public class RegistroAsistenciaService
    {
        private readonly IRegistroAsistenciaRepository repository;

        public RegistroAsistenciaService(IRegistroAsistenciaRepository repository)
        {
            this.repository = repository;
        }

        public Task<RegistroAsistencia> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<RegistroAsistencia>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<RegistroAsistencia>> BuscarPorRangoFecha(int personalId, DateTime fechaInicio, DateTime fechaFin) => repository.BuscarPorRangoFecha(personalId, fechaInicio, fechaFin);
        public Task<RegistroAsistencia> Agregar(RegistroAsistenciaCrearDto entry) => repository.Agregar(entry);
        public Task<RegistroAsistencia> Modificar(long id, RegistroAsistenciaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
