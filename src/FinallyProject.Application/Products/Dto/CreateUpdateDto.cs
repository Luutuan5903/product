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
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Image { get; set; }

        public int? CategoryId { get; set; } // Dropdown dùng Id
    }
}
