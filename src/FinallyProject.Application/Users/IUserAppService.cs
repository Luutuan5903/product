using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FinallyProject.Roles.Dto;
using FinallyProject.Users.Dto;

namespace FinallyProject.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
