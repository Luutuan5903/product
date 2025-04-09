using Abp.AspNetCore.Mvc.ViewComponents;

namespace FinallyProject.Web.Views
{
    public abstract class FinallyProjectViewComponent : AbpViewComponent
    {
        protected FinallyProjectViewComponent()
        {
            LocalizationSourceName = FinallyProjectConsts.LocalizationSourceName;
        }
    }
}
