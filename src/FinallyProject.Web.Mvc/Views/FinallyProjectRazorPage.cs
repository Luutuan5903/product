using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace FinallyProject.Web.Views
{
    public abstract class FinallyProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected FinallyProjectRazorPage()
        {
            LocalizationSourceName = FinallyProjectConsts.LocalizationSourceName;
        }
    }
}
