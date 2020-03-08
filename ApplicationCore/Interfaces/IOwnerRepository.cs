using ApplicationCore.Entities;
using ApplicationCore.Entities.ExtendedEntities;
using Infastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        Task<IEnumerable<Owner>> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);
       // OwnerExtended GetOwnerWithDetails(Guid ownerId);
      //  void CreateOwner(Owner owner);

        //Task<IQueryable<Owner>> GetAllOwnersNew();
    }
}
