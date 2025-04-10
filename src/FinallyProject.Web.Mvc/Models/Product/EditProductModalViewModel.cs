using FinallyProject.Products.Dto;
using System.Collections.Generic;

public class EditProductModalViewModel
{
    public ProductDto Product { get; set; }
    public List<CategoryDto> Categories { get; set; }

    public EditProductModalViewModel(ProductDto product, List<CategoryDto> categories)
    {
        Product = product;
        Categories = categories;
    }
}
