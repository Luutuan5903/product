using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FinallyProject.EntityFrameworkCore
{
    public static class FinallyProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FinallyProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FinallyProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
