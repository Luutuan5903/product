using System.Threading.Tasks;
using FinallyProject.Configuration.Dto;

namespace FinallyProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
