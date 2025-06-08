﻿using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.SexoEntities;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.GrupoHorarioEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalConfiguracionEntities;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<GrupoHorario> GrupoHorarios { get; set; }
        public DbSet<HorarioCabecera> HorarioCabeceras { get; set; }
        public DbSet<HorarioDetalle> HorarioDetalles { get; set; }
        public DbSet<PersonalConfiguracion> PersonalesConfiguracion { get; set; }
        public DbSet<Personal> Personales { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
    }
}
