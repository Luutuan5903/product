using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using FinallyProject.Controllers;

namespace FinallyProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : FinallyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
