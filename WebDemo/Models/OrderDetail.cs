using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDemo.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductID { set; get; }
        public int OrderID { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public string ProductName { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { set; get; }
        
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
    }
}