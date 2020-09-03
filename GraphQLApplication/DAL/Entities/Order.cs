using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(DAL.Entities.Customer.CustomerOrdersNavigation))]
        public Customer OrderCustomerNavigation { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(DAL.Entities.Employee.EmployeeOrdersNavigation))]
        public Employee OrderEmployeeNavigation { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipperId { get; set; }

        [ForeignKey(nameof(ShipperId))]
        [InverseProperty(nameof(DAL.Entities.Shipper.ShipperOrderNavigation))]
        public Shipper OrderShipperNavigation { get; set; }

        [Required]
        public decimal Freight { get; set; }

        [Required]
        [StringLength(40)]
        public string ShipName { get; set; }

        [Required]
        [StringLength(60)]
        public string ShipAddress { get; set; }

        [Required]
        [StringLength(15)]
        public string Shipcity { get; set; }

        [StringLength(15)]
        public string ShipRegion { get; set; }

        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        [Required]
        [StringLength(15)]
        public string ShipCountry { get; set; }

       [InverseProperty(nameof(DAL.Entities.OrderDetail.OrderDetailOrderNavigation))]
        public OrderDetail OrderOrderDetailNavigation { get; set; }
    }
}
