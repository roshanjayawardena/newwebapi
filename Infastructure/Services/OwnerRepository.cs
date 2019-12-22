﻿using ApplicationCore.Entities;
using ApplicationCore.Entities.ExtendedEntities;
using ApplicationCore.Extentions;
using ApplicationCore.Interfaces;
using Infastructure;
using Infastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {

        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
            try
            {
                return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync();
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
           
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            try
            {
                return FindByCondition(owner => owner.Id.Equals(ownerId))
                 .DefaultIfEmpty(new Owner())
                 .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
         
        }

        public OwnerExtended GetOwnerWithDetails(Guid ownerId)
        {
            try
            {
                return new OwnerExtended(GetOwnerById(ownerId))
                {
                    Accounts = RepositoryContext.Accounts
                  .Where(a => a.OwnerId == ownerId)
                };
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
          
        }

        public void CreateOwner(Owner owner)
        {
            try
            {
                owner.Id = Guid.NewGuid();
                Create(owner);
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
          
        }
    }
}
