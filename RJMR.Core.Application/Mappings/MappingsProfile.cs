using AutoMapper;
using RJMR.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Core.Application.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() 
        {
            CreateMap<Permission, PermissionDTO>().ReverseMap()
                .ForMember(destino => destino.Id, origen => origen.MapFrom(orgDTO => orgDTO.Id))
                .ForMember(destino => destino.NombreEmpleado, origen => origen.MapFrom(orgDTO => orgDTO.NombreEmpleado))
                .ForMember(destino => destino.ApellidoEmpleado, origen => origen.MapFrom(orgDTO => orgDTO.ApellidoEmpleado))
                .ForMember(destino => destino.TípoPermiso, origen => origen.MapFrom(orgDTO => orgDTO.TípoPermiso))
                .ForMember(destino => destino.FechaPermiso, origen => origen.MapFrom(orgDTO => DateOnly.FromDateTime(orgDTO.FechaPermiso)));
            CreateMap<PermissionType, PermissionTypeDTO>().ReverseMap();
        }

        public static IMapper GetMapper()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingsProfile());
            });
            return mappingConfig.CreateMapper();
        }
    }
}
