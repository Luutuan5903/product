using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FinallyProject.Products.Dto;

namespace FinallyProject.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<PagedResultDto<ProductDto>> GetAllAsync();
        Task<ProductDto> GetAsync(int id);
        Task<ProductDto> CreateAsync(CreateUpdateDto input);
        Task<ProductDto> UpdateAsync(int id, CreateUpdateDto input);
        Task DeleteAsync(int id);
    }
}
