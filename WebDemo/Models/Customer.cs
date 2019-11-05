using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDemo.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string CustomerName { get; set; }
        public string Address { set; get; }
        public string Country { set; get; }
        public int Phone { get; set; }
        public string Email { get; set; }

    }
}