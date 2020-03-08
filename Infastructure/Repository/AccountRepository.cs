using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.UnitOfWork
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {

        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }



    }
}
