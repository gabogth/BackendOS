using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.general.PersonaUseCases
{
    public class PersonaAdjuntosUseCase
    {
        private readonly IPersonaAdjuntosRepository personaRepository;
        private readonly IPersonaAdjuntoRepository personaAdjuntoRepository;
        private readonly IUnitOfWork unitOfWork;

        public PersonaAdjuntosUseCase(
            IPersonaAdjuntosRepository personaRepository,
            IPersonaAdjuntoRepository personaAdjuntoRepository,
            IUnitOfWork unitOfWork)
        {
            this.personaRepository = personaRepository;
            this.personaAdjuntoRepository = personaAdjuntoRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<Persona> ObtenerPorId(int id) => personaRepository.ObtenerPorId(id);

        public Task<List<Persona>> ObtenerTodos() => personaRepository.ObtenerTodos();

        public async Task<Persona> Agregar(PersonaAdjuntosCrearDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));
            if (dto.Persona is null)
                throw new ArgumentNullException(nameof(dto.Persona));
            await unitOfWork.BeginTransactionAsync();
            try
            {
                Persona persona = await personaRepository.Agregar(dto.Persona);
                PersonaAdjuntoCrearDto[] adjuntos = (dto.PersonaAdjuntos ?? new List<PersonaAdjuntoCrearDto>()).ToArray();
                for (int i = 0; i < adjuntos.Length; i++)
                {
                    adjuntos[i].PersonaId = persona.Id;
                    adjuntos[i].Id = 0;
                }

                if (adjuntos.Length > 0)
                    await personaAdjuntoRepository.AgregarRange(adjuntos);

                await unitOfWork.CommitAsync();
                return await personaRepository.ObtenerPorId(persona.Id);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public async Task<Persona> Modificar(int id, PersonaAdjuntosCrearDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));
            if (dto.Persona is null)
                throw new ArgumentNullException(nameof(dto.Persona));
            await unitOfWork.BeginTransactionAsync();
            try
            {
                Persona persona = await personaRepository.Modificar(id, dto.Persona);
                persona = await personaRepository.ObtenerPorId(persona.Id);

                PersonaAdjunto[] originalesAdjuntos = persona.PersonaAdjuntos?.ToArray() ?? Array.Empty<PersonaAdjunto>();
                List<PersonaAdjuntoCrearDto> adjuntosEntrada = dto.PersonaAdjuntos ?? new List<PersonaAdjuntoCrearDto>();
                for (int i = 0; i < adjuntosEntrada.Count; i++)
                {
                    PersonaAdjuntoCrearDto current = adjuntosEntrada[i];
                    current.PersonaId = persona.Id;
                }

                (long id, PersonaAdjuntoCrearDto entry)[] adjuntosEntries = adjuntosEntrada
                    .Select(entry => (entry.Id, entry))
                    .ToArray();

                await personaAdjuntoRepository.FusionarRange(originalesAdjuntos, adjuntosEntries);

                await unitOfWork.CommitAsync();
                return await personaRepository.ObtenerPorId(persona.Id);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public async Task Eliminar(int id)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                List<PersonaAdjunto> adjuntos = await personaAdjuntoRepository.ObtenerPorPersona(id);
                if (adjuntos.Count > 0)
                {
                    long[] adjuntosIds = adjuntos.Select(x => x.Id).ToArray();
                    await personaAdjuntoRepository.EliminarRange(adjuntosIds);
                }

                await personaRepository.Eliminar(id);

                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
