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
    [Table("AppCategories")]
    public class Category : AuditedEntity<int>
    {
        public const int MaxNameLength = 100;
        public const int MaxDescriptionLength = 255;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
