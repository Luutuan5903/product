using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace FinallyProject.Products
{
    [Table("AppProducts")]
    public class Product : AuditedEntity<int>
    {
        public const int MaxNameLength = 100;
        public const int MaxImageLength = 255;
        public const int MaxCategoryLength = 50;


        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [StringLength(MaxImageLength)]
        public string Image { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }  // Có thể null nếu chưa gán danh mục

        public virtual Category Category { get; set; }



        public Product()
        {
        }

        public Product(tring name, decimal price, string image = null, int? categoryId = null)
        {
            Name = name;
            Price = price;
            Image = image;
            CategoryId = categoryId;

        }
    }
}
