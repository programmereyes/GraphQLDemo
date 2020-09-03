using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Required]
         public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        [InverseProperty(nameof(DAL.Entities.Supplier.SupplierProductsNavigation))]
        public Supplier ProductSupplierNavigation { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(DAL.Entities.Category.CategoryProductsNavigation))]
        public Category ProductCategoryNavigation { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public bool Discontinued { get; set; }
        [InverseProperty(nameof(DAL.Entities.OrderDetail.OrderDetailProductNavigation))]
        public OrderDetail ProductOrderDetailNavigation { get; set; }

    }
}
