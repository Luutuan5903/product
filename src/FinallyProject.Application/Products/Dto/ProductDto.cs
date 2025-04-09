using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace FinallyProject.Products.Dto
{
    public class ProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image {  get; set; }
        public string Category { get; set; }

    }
}
