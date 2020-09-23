using System;
using System.Data.SqlClient;

using Core.Interface;
using Infrastructure.SQL;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolution
{
    public static class SqlRegistrationModule
    {
        public static void AddSql(this IServiceCollection service, IConfiguration configuration)
        {
            string dataSource = configuration[$"SqlConnectionString:DataSource"];
            string initialCatalog = configuration[$"SqlConnectionString:InitialCatalog"];
            bool integratedSecurity = Convert.ToBoolean(configuration[$"SqlConnectionString:IntegratedSecurity"]);

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = initialCatalog,
                IntegratedSecurity = integratedSecurity
            };

            service.AddSingleton(scsb.ConnectionString);
            service.AddSingleton<ISqlRepository, SqlRepository>();
        }
    }
}
