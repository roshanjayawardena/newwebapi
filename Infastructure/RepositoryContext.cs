
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infastructure
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}
