using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Employee", Schema = "dbo")]
    public class Employee
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(10)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(25)]
        public string TitleOfCourtesy { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public DateTime Hiredate { get; set; }

        [Required]
        [StringLength(60)]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string Postalcode { get; set; }

        [Required]
        [StringLength(15)]
        public string Country { get; set; }

        [Required]
        [StringLength(24)]
        public string Phone { get; set; }
        public int? Managerid { get; set; }
        [InverseProperty(nameof(DAL.Entities.Order.OrderEmployeeNavigation))]
        public List<Order> EmployeeOrdersNavigation { get; set; }
    }
}
