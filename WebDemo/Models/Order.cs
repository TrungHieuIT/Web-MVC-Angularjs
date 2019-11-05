using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    [Table("Orders")]
    public class Order
    {
        public Order()
        {
           // OrderDetail = new List<OrderDetail>();
        }
        public int Id { get; set; }
        public int CustomerID {get;set;}
        public decimal TotalMoney { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public string CustomerName { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }
        public virtual IList<OrderDetail> OrderDetail { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
