using AutoMapper;
using nest.core.aplicacion.general.Departamentos.Commands;
using nest.core.aplicacion.general.Paises.Commands;
using nest.core.aplicacion.general.Provincias.Commands;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;
using nest.core.dominio.General.AdjuntoTipoEntities;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.PaisEntities;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.infraestructura.general.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<AdjuntoCrearDto, Adjunto>();
            CreateMap<AdjuntoConfigProviderCrearDto, AdjuntoConfigProvider>();
            CreateMap<PersonaCrearDto, Persona>();
            CreateMap<PersonaAdjuntoCrearDto, PersonaAdjunto>();
            CreateMap<DepartamentoCrearCommand, Departamento>();
            CreateMap<DepartamentoModificarCommand, Departamento>();
            CreateMap<ProvinciaCrearCommand, Provincia>();
            CreateMap<ProvinciaModificarCommand, Provincia>();
            CreateMap<DistritoCrearDto, Distrito>();
            CreateMap<DocumentoIdentidadTipoCrearDto, DocumentoIdentidadTipo>();
            CreateMap<DocumentoTipoCrearDto, DocumentoTipo>();
            CreateMap<AdjuntoTipoCrearDto, AdjuntoTipo>();
            CreateMap<LicenciaConducirCrearDto, LicenciaConducir>();
            CreateMap<PaisCrearCommand, Pais>();
            CreateMap<PaisModificarCommand, Pais>();
            CreateMap<SexoCrearDto, Sexo>();
        }
    }
}
