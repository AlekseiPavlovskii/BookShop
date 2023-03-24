﻿using DatabaseProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookShopMigrations
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            string connectionString = 
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Books;Pooling=true;Integrated Security=SSPI";
            var optionalBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            optionalBuilder.UseSqlServer( connectionString, 
                assembly => assembly.MigrationsAssembly( "BookShopMigrations" ) );

            return new ApplicationContext(optionalBuilder.Options);
        }
    }
}
