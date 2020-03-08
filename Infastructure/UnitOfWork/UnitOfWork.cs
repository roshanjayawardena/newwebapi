﻿using ApplicationCore.Interfaces;
using ApplicationCore.Repository;

namespace Infastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private RepositoryContext _repoContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IOwnerRepository Owner
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new OwnerRepository(_repoContext);
                }

                return _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
            }
        }

       

        public void Save()
        {
            _repoContext.SaveChanges();
        }

    }

    }
