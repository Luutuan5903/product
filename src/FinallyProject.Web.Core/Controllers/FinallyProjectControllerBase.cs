using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FinallyProject.Controllers
{
    public abstract class FinallyProjectControllerBase: AbpController
    {
        protected FinallyProjectControllerBase()
        {
            LocalizationSourceName = FinallyProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
