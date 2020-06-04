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
            
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NetworkLearning;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new UserDbContext(optionsBuilder.Options);
        }

    }
}
