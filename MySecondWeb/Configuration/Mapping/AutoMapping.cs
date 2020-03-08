using ApplicationCore.Entities;
using AutoMapper;
using Infastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySecondWeb.Configuration.Mapping
{
    public class AutoMapping: Profile
    {
        public AutoMapping() {

            CreateMap<Owner, OwnerDto>();

        }


    }
}
