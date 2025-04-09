using Abp.Application.Services.Dto;
using FinallyProject.Products.Dto;
using System.Collections.Generic;

namespace FinallyProject.Web.Models.Product
{
    public class IndexViewModel
    {
        private PagedResultDto<ProductDto> products;

        public IReadOnlyList<ProductDto> Products { get; set; }
        public IReadOnlyList<CategoryDto> Categories { get; set; }

        public IndexViewModel()
        {
        }

        public IndexViewModel(IReadOnlyList<ProductDto> products, IReadOnlyList<CategoryDto> categories)
        {
            Products = products;
            Categories = categories;
        }

        public IndexViewModel(PagedResultDto<ProductDto> products)
        {
            this.products = products;
        }
    }
}
