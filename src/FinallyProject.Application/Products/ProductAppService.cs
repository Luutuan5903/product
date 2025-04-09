using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FinallyProject.Products.Dto;

namespace FinallyProject.Products
{
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IRepository<Product, int> _productRepository;

        public ProductAppService(IRepository<Product, int> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResultDto<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllListAsync();

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.Image,
                Category = p.Category
            }).ToList();

            return new PagedResultDto<ProductDto>(
                result.Count, // totalCount
                result        // items
            );
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                Category = product.Category
            };
        }

        public async Task<ProductDto> CreateAsync(CreateUpdateDto input)
        {
            var product = new Product
            {
                Name = input.Name,
                Price = input.Price,
                Image = input.Image,
                Category = input.Category
            };

            var newProductId = await _productRepository.InsertAndGetIdAsync(product);

            return new ProductDto
            {
                Id = newProductId,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                Category = product.Category
            };
        }

        public async Task<ProductDto> UpdateAsync(int id, CreateUpdateDto input)
        {
            var product = await _productRepository.GetAsync(id);

            product.Name = input.Name;
            product.Price = input.Price;
            product.Image = input.Image;
            product.Category = input.Category;

            await _productRepository.UpdateAsync(product);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                Category = product.Category
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        
    }
}
