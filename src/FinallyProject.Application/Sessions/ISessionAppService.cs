using System.Threading.Tasks;
using Abp.Application.Services;
using FinallyProject.Sessions.Dto;

namespace FinallyProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
