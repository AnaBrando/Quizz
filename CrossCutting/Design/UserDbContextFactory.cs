using CrossCutting.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Design
{
    class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            
            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDb;Initial Catalog=NetworkLearning;Integrated Security=True");

            return new UserDbContext(optionsBuilder.Options);
        }

    }
}
