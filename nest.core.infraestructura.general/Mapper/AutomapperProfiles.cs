using AutoMapper;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Commands;
using nest.core.aplicacion.general.AdjuntoTipos.Commands;
using nest.core.aplicacion.general.Departamentos.Commands;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands;
using nest.core.aplicacion.general.DocumentoTipos.Commands;
using nest.core.aplicacion.general.LicenciasConducir.Commands;
using nest.core.aplicacion.general.Paises.Commands;
using nest.core.aplicacion.general.PersonaAdjuntos.Commands;
using nest.core.aplicacion.general.Provincias.Commands;
using nest.core.aplicacion.general.Sexos.Commands;
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
            CreateMap<AdjuntoConfigProviderCrearCommand, AdjuntoConfigProvider>();
            CreateMap<AdjuntoConfigProviderModificarCommand, AdjuntoConfigProvider>();
            CreateMap<DepartamentoCrearCommand, Departamento>();
            CreateMap<DepartamentoModificarCommand, Departamento>();
            CreateMap<ProvinciaCrearCommand, Provincia>();
            CreateMap<ProvinciaModificarCommand, Provincia>();
            CreateMap<DistritoCrearDto, Distrito>();
            CreateMap<AdjuntoTipoCrearCommand, AdjuntoTipo>();
            CreateMap<AdjuntoTipoModificarCommand, AdjuntoTipo>();
            CreateMap<DocumentoIdentidadTipoCrearCommand, DocumentoIdentidadTipo>();
            CreateMap<DocumentoIdentidadTipoModificarCommand, DocumentoIdentidadTipo>();
            CreateMap<DocumentoTipoCrearCommand, DocumentoTipo>();
            CreateMap<DocumentoTipoModificarCommand, DocumentoTipo>();
            CreateMap<LicenciaConducirCrearCommand, LicenciaConducir>();
            CreateMap<LicenciaConducirModificarCommand, LicenciaConducir>();
            CreateMap<PersonaAdjuntoCrearCommand, PersonaAdjunto>();
            CreateMap<PersonaAdjuntoModificarCommand, PersonaAdjunto>();
            CreateMap<PaisCrearCommand, Pais>();
            CreateMap<PaisModificarCommand, Pais>();
            CreateMap<SexoCrearCommand, Sexo>();
            CreateMap<SexoModificarCommand, Sexo>();
        }
    }
}
