using ApplicationCore.Dto;
using ApplicationCore.Entities;
using AutoMapper;

namespace MySecondWeb.Configuration.Mapping
{
    public class AutoMapping: Profile
    {
        public AutoMapping() {

            CreateMap<Owner, OwnerDto>();

        }


    }
}
