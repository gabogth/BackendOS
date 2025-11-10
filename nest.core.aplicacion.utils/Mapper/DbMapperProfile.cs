using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace nest.core.aplicacion.utils.Mapper
{
    public class DbMapperProfile : Profile
    {
        public DbMapperProfile(DbContext db)
        {
            var model = db.Model.GetEntityTypes();

            foreach (var et in model)
            {
                var clr = et.ClrType;
                var map = CreateMap(clr, clr);
                foreach (var nav in et.GetNavigations())
                    map.ForMember(nav.Name, opt => opt.Ignore());
                foreach (var skip in et.GetSkipNavigations())
                    map.ForMember(skip.Name, opt => opt.Ignore());
            }
        }
    }
}
