using ApplicationCore.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOwnerService
    {
        Task<List<OwnerDto>> GetAllOwners();
        Task<OwnerDto> GetOwnerById(int ownerId);


    }
}
