using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FinallyProject.Authorization.Roles;
using FinallyProject.Authorization.Users;
using FinallyProject.MultiTenancy;
using FinallyProject.Products;

namespace FinallyProject.EntityFrameworkCore
{
    public class FinallyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, FinallyProjectDbContext>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public FinallyProjectDbContext(DbContextOptions<FinallyProjectDbContext> options)
            : base(options)
        {
        }
    }
}
