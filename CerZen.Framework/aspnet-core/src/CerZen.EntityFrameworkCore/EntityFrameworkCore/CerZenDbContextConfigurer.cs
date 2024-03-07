using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CerZen.EntityFrameworkCore
{
    public static class CerZenDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CerZenDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            builder.UseMySql(connectionString, serverVersion);
        }

        public static void Configure(DbContextOptionsBuilder<CerZenDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            var serverVersion = ServerVersion.AutoDetect(connection.ConnectionString);
            builder.UseMySql(connection, serverVersion);
        }
    }
}
