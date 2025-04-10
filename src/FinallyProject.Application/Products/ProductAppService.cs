using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FinallyProject.Products.Dto;
using Microsoft.EntityFrameworkCore;

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
            var products = await _productRepository
                .GetAllIncluding(p => p.Category)
                .ToListAsync();

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.Image,
                CategoryName = p.Category?.Name
            }).ToList();

            return new PagedResultDto<ProductDto>(
                result.Count,
                result
            );
        }



        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await _productRepository
                .GetAllIncluding(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                
            };
        }

        public async Task<ProductDto> CreateAsync(CreateUpdateDto input)
        {
            var product = new Product
            {
                Name = input.Name,
                Price = input.Price,
                Image = input.Image,
                CategoryId = input.CategoryId
            };

            await _productRepository.InsertAsync(product);
            await CurrentUnitOfWork.SaveChangesAsync();

            // Tải lại để lấy cả thông tin category
            var createdProduct = await _productRepository
                .GetAllIncluding(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            return new ProductDto
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Price = createdProduct.Price,
                Image = createdProduct.Image,
                CategoryId = createdProduct.CategoryId?.ToString(),
                CategoryName = createdProduct.Category?.Name 
            };
        }

        public async Task<ProductDto> UpdateAsync(int id, CreateUpdateDto input)
        {
            var product = await _productRepository.GetAsync(id);

            product.Name = input.Name;
            product.Price = input.Price;
            product.Image = input.Image;
            product.CategoryId = input.CategoryId;

            await _productRepository.UpdateAsync(product);

            
            var updatedProduct = await _productRepository
                .GetAllIncluding(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            return new ProductDto
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Price = updatedProduct.Price,
                Image = updatedProduct.Image,
                
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}

