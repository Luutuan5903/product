using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using FinallyProject.Controllers;

namespace FinallyProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : FinallyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
