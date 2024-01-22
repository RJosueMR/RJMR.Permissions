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
            CreateMap<Permission, PermissionDTO>().ReverseMap();
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
