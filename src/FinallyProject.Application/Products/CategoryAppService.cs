using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using FinallyProject.Products.Dto;

namespace FinallyProject.Products
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IRepository<Category, int> _categoryRepository;

        public CategoryAppService(IRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ListResultDto<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllListAsync();

            return new ListResultDto<CategoryDto>(
                ObjectMapper.Map<List<CategoryDto>>(categories)
            );
        }
    }
}
