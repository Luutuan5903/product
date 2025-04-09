using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FinallyProject.EntityFrameworkCore;
using FinallyProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace FinallyProject.Web.Tests
{
    [DependsOn(
        typeof(FinallyProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FinallyProjectWebTestModule : AbpModule
    {
        public FinallyProjectWebTestModule(FinallyProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FinallyProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FinallyProjectWebMvcModule).Assembly);
        }
    }
}