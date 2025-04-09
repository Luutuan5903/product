using Abp.Application.Services.Dto;
using Abp.Application.Services;
using FinallyProject.Products.Dto;
using System.Threading.Tasks;

namespace FinallyProject.Products
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<ListResultDto<CategoryDto>> GetAllAsync();
    }
}