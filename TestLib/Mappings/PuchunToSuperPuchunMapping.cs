using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestLib.Model;

namespace TestLib.Mappings
{
    public class PuchunToSuperPuchunMapping
    {
        public void ConfigMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Puchun, SuperPuchun>();
        }
    }
}
