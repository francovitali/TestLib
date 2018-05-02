using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestLib.Dto;
using TestLib.Model;

namespace TestLib.Mappings
{
    public class OrderToOrderDtoMapping
    {
        public void ConfigMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Order, OrderDto>()
                /*
                .ForMember(target => target.Id,
                    opts => opts.MapFrom(source => source.Id))
                .ForMember(target => target.Date,
                    opts => opts.MapFrom(source => source.Date))
                */
                .ForMember(target => target.Price,
                    opts => opts.MapFrom(source => source.OriginalPrice * ((100 - source.Discount) / 100)))
                .ForMember(target => target.Token,
                    opts => opts.Ignore());
        }
    }
}
