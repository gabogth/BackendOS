using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.PersonaEntities;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general.Extensiones
{
    public class PersonaAdjuntosRepository : PersonaRepository, IPersonaAdjuntosUseCaseRepository
    {
        public PersonaAdjuntosRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Persona> Query()
        {
            return base.Query()
                .Include(x => x.PersonaAdjuntos)
                .ThenInclude(x => x.Adjunto)
                .Include(x => x.PersonaAdjuntos)
                .ThenInclude(x => x.AdjuntoTipo);
        }
    }
}
