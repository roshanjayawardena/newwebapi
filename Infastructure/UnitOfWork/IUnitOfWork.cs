using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.UnitOfWork
{
   public interface IUnitOfWork
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }
        void Save();

    }
}
