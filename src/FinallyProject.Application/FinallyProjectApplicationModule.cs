using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FinallyProject.Authorization;

namespace FinallyProject
{
    [DependsOn(
        typeof(FinallyProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FinallyProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FinallyProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FinallyProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
