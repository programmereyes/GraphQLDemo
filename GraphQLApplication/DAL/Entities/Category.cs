using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Category
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [InverseProperty(nameof(DAL.Entities.Product.ProductCategoryNavigation))]
        public IEnumerable<Product> CategoryProductsNavigation { get; set; }
    }
}
