using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Customer
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(30)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(30)]
        public string ContactTitle { get; set; }

        [Required]
        [StringLength(60)]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(15)]
        public string Country { get; set; }

        [Required]
        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }
        [InverseProperty(nameof(DAL.Entities.Order.OrderCustomerNavigation))]
        public List<Order> CustomerOrdersNavigation { get; set; }
    }

}
