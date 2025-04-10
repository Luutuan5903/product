using Abp.Application.Services.Dto;
using FinallyProject.Products.Dto;
using System.Collections.Generic;

namespace FinallyProject.Web.Models.Product
{
    public class IndexViewModel
    {
        private PagedResultDto<ProductDto> products;

        // Danh sách sản phẩm phân trang
        public PagedResultDto<ProductDto> PagedProducts { get; set; }

        // Danh sách sản phẩm tách riêng (đã có sẵn trong PagedProducts.Items, nhưng vẫn giữ lại nếu bạn dùng cho mục đích khác)
        public IReadOnlyList<ProductDto> Products { get; set; } = new List<ProductDto>();

        // Danh sách danh mục
        public IReadOnlyList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        // Constructor mặc định
        public IndexViewModel()
        {
        }

        // Constructor truyền PagedProducts và Categories
        public IndexViewModel(PagedResultDto<ProductDto> pagedProducts, IReadOnlyList<CategoryDto> categories)
        {
            PagedProducts = pagedProducts;
            Products = pagedProducts?.Items ?? new List<ProductDto>();
            Categories = categories ?? new List<CategoryDto>();
        }

        public IndexViewModel(PagedResultDto<ProductDto> products)
        {
            this.products = products;
        }
    }
}
