using Abp.Application.Services.Dto;
using FinallyProject.Products.Dto;
using System.Collections.Generic;

namespace FinallyProject.Web.Models.Product
{
    public class IndexViewModel
    {
        private PagedResultDto<ProductDto> products;

        public IReadOnlyList<ProductDto> Products { get; }

        public IndexViewModel(IReadOnlyList<ProductDto> products)
        {
            Products = products;
        }

        public IndexViewModel(PagedResultDto<ProductDto> products)
        {
            this.products = products;
        }

        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
