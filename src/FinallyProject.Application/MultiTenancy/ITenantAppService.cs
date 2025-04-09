using Abp.Application.Services;
using FinallyProject.MultiTenancy.Dto;

namespace FinallyProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

