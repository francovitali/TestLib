using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestLib.Dto;
using TestLib.Mappings;
using TestLib.Model;

namespace TestLib
{
    public class MyMapper
    {
        private readonly IMapper mapper;

        public MyMapper()
        {
            // Mapping implementations
            var orderToOrderDtoMapping = new OrderToOrderDtoMapping();
            var puchunToSuperPuchunMapping = new PuchunToSuperPuchunMapping();
            // ...

            // Automapper configuration
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                orderToOrderDtoMapping.ConfigMapping(config);
                puchunToSuperPuchunMapping.ConfigMapping(config);
                // ...
            });
            
            // Mapper Creation (with previous config)
            mapper = mapperConfiguration.CreateMapper();
        }

        public OrderDto Map(Order order)
        {
            return mapper.Map<OrderDto>(order);
        }

        public SuperPuchun Map(Puchun puchun)
        {
            return mapper.Map<SuperPuchun>(puchun);
        }
    }
}
