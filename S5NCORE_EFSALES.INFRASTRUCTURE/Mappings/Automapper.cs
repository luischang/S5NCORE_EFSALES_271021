using AutoMapper;
using S5NCORE_EFSALES.CORE.DTOs;
using S5NCORE_EFSALES.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.INFRASTRUCTURE.Mappings
{
    public class Automapper: Profile
    {
        public Automapper()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Customer, CustomerCountryDTO>();
                //.ForMember(dest=>dest.Country, opt=>opt.MapFrom(src=>src.Pais));
            CreateMap<CustomerCountryDTO, Customer>();

            CreateMap<Customer, CustomerPostDTO>();
            CreateMap<CustomerPostDTO, Customer>();
        }



    }
}
