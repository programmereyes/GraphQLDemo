using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("OrderDetail",Schema ="dbo")]
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(DAL.Entities.Order.OrderOrderDetailNavigation))]
        public Order OrderDetailOrderNavigation { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(DAL.Entities.Product.ProductOrderDetailNavigation))]
        public Product OrderDetailProductNavigation { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public string Quantity { get; set; }

        [Required]
        public string Discount { get; set; }

    }
}
