using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace FinallyProject.Products.Dto
{
    public class CategoryDto : EntityDto<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
