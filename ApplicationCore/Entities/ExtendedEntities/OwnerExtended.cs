﻿using ApplicationCore.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.ExtendedEntities
{
    public class OwnerExtended: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        public OwnerExtended()
        {
        }

        public OwnerExtended(Owner owner)
        {
            //Id = owner.Id;
            Name = owner.FirstName;
           // DateOfBirth = owner.DateOfBirth;
            Address = owner.Address;
        }
    }
}
