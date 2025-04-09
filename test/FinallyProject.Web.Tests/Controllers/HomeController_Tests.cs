using System.Threading.Tasks;
using FinallyProject.Models.TokenAuth;
using FinallyProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace FinallyProject.Web.Tests.Controllers
{
    public class HomeController_Tests: FinallyProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}