using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class AdeventureWorksDbContextDesignTimeFactory : IDesignTimeDbContextFactory<AdventureWorksDbContext>
    {
        public AdventureWorksDbContext CreateDbContext(string[] args)
        {
            //only for local development
            DbContextOptionsBuilder<AdventureWorksDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<AdventureWorksDbContext>();
            dbContextOptionsBuilder.UseSqlServer("server=.;database=GraphQLDBtest;integrated security=true");
            return new AdventureWorksDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
