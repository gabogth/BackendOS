using System.Collections.Generic;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonaServices
{
    public class GrupoTrabajoPersonaService
    {
        private readonly IGrupoTrabajoPersonaRepository repository;

        public GrupoTrabajoPersonaService(IGrupoTrabajoPersonaRepository repository)
        {
            this.repository = repository;
        }

        public Task<GrupoTrabajoPersona> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<GrupoTrabajoPersona>> ObtenerTodos() => repository.ObtenerTodos();

        public Task<List<GrupoTrabajoPersona>> ObtenerPorGrupoTrabajo(long grupoTrabajoId) =>
            repository.ObtenerPorGrupoTrabajo(grupoTrabajoId);

        public Task<GrupoTrabajoPersona> Agregar(GrupoTrabajoPersonaCrearDto entry) => repository.Agregar(entry);

        public Task<GrupoTrabajoPersona> Modificar(long id, GrupoTrabajoPersonaCrearDto entry) =>
            repository.Modificar(id, entry);

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
