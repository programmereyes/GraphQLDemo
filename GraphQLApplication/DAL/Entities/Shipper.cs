using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Shipper
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(24)]
        public string Phone { get; set; }
        [InverseProperty(nameof(DAL.Entities.Order.OrderShipperNavigation))]
        public List<Order> ShipperOrderNavigation { get; set; }
    }
}
