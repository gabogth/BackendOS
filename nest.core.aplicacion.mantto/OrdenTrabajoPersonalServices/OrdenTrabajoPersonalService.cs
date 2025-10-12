using System.Collections.Generic;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonalServices
{
    public class OrdenTrabajoPersonalService
    {
        private readonly IOrdenTrabajoPersonalRepository repository;

        public OrdenTrabajoPersonalService(IOrdenTrabajoPersonalRepository repository)
        {
            this.repository = repository;
        }

        public Task<OrdenTrabajoPersonal> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenTrabajoPersonal>> ObtenerPorIds(List<long> ids) => repository.ObtenerPorIds(ids);

        public Task<List<OrdenTrabajoPersonal>> ObtenerPorCabecera(long ordenTrabajoCabeceraId) => repository.ObtenerPorCabecera(ordenTrabajoCabeceraId);

        public Task<OrdenTrabajoPersonal> Agregar(OrdenTrabajoPersonalCrearDto entry) => repository.Agregar(entry);

        public Task<OrdenTrabajoPersonal[]> AgregarRange(OrdenTrabajoPersonalCrearDto[] entries) => repository.AgregarRange(entries);

        public Task<OrdenTrabajoPersonal> Modificar(long id, OrdenTrabajoPersonalCrearDto entry) => repository.Modificar(id, entry);

        public Task<OrdenTrabajoPersonal[]> ModificarRange((long id, OrdenTrabajoPersonalCrearDto entry)[] entries) => repository.ModificarRange(entries);

        public Task Eliminar(long id) => repository.Eliminar(id);

        public Task EliminarRange(long[] ids) => repository.EliminarRange(ids);

        public Task<OrdenTrabajoPersonal[]> FusionarRange(OrdenTrabajoPersonal[] originalEntities, (long id, OrdenTrabajoPersonalCrearDto entry)[] entries) => repository.FusionarRange(originalEntities, entries);
    }
}
