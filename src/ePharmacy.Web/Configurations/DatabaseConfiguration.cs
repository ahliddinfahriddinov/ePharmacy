﻿using ePharmacy.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Web.Configurations
{

    public static class DatabaseConfigurations
    {
        public static void ConfigureDB(this WebApplicationBuilder builder)
        {

            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(connectionString));
        }
    }
}
