using ApplicationCore.Entities;
using Infastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Interfaces
{
    public interface IOwnerService
    {
        Task<List<OwnerDto>> GetAllOwners();
        Task<OwnerDto> GetOwnerById(int ownerId);


    }
}
