﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace FinallyProject.Products
{
    [Table("AppCategories")]
    public class Category : Entity<int>
    {
        public const int MaxNameLength = 100;
        

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        

        // Quan hệ 1 - n: Một danh mục có thể có nhiều sản phẩm
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }

}
