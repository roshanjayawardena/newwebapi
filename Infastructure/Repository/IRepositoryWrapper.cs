using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Repository
{
   public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }
        void Save();

    }
}
