using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyProject.Products.Dto
{
    public class CreateUpdateDto
    {
        [Required]
        [StringLength(Product.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [StringLength(Product.MaxImageLength)]
        public string Image { get; set; }

        [StringLength(Product.MaxCategoryLength)]
        public string Category { get; set; }
    }
}
