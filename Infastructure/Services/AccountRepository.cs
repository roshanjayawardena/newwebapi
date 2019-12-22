using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Services
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {

        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }



    }
}
