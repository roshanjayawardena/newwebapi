using ApplicationCore.Dto;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Extentions;
using ApplicationCore.Interfaces;
using AutoMapper;
using Infastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Services
{
   // public class OwnerService : RepositoryBase<Owner>, IOwnerService
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //public OwnerService(RepositoryContext repositoryContext, IUnitOfWork unitOfWork, IMapper mapper)
        //   : base(repositoryContext)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //}

        public OwnerService(IUnitOfWork unitOfWork, IMapper mapper)     
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //   public OwnerService(RepositoryContext repositoryContext, IMapper mapper)
        //: base(repositoryContext)
        //   {           
        //       _mapper = mapper;
        //   }

        public async Task<List<OwnerDto>> GetAllOwners()
        {
            try
            {
                var ownerdomaindetails = await _unitOfWork.Owner.FindAll().OrderBy(ow => ow.FirstName).ToListAsync();
                var ownerDtoDetails = ownerdomaindetails.Select(w => _mapper.Map<OwnerDto>(w)).ToList();               
                return ownerDtoDetails;
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task<OwnerDto> GetOwnerById(int ownerId)
        {
            try
            {
                var ownerdetails = await _unitOfWork.Owner.FindByCondition(owner => owner.Id.Equals(ownerId)).DefaultIfEmpty(new Owner()).FirstOrDefaultAsync();
                if (ownerdetails.IsNull())
                {
                    throw new RecordNotFoundException("owner detail could not found.");
                }
                var ownerDtoDetails = _mapper.Map<OwnerDto>(ownerdetails);
                return ownerDtoDetails;              
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }

        }


    }
}
