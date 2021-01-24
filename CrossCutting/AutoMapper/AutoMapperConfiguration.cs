using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new DomainToDtoMappingProfile());
                ps.AddProfile(new DtoToDomainMappingProfile());
            });
        }
    }
}
