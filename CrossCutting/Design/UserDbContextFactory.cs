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
            
            optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,1433;Database=Quizz;UID=SA;PWD=Diobrando0510*");

            return new UserDbContext(optionsBuilder.Options);
        }

    }
}
