using FinallyProject.Products.Dto;
using System.Collections.Generic;

namespace FinallyProject.Web.Models.Product
{
    public class ProductCreateViewModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }

        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }

}
