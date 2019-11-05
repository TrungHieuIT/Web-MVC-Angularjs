using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo.Models;

namespace WebDemo.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalMoney { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }
        public string CustomerName { get; set; }
        public IList<OrderDetailViewModel> OrderDetail { get; set; } 

        public CustomerViewModel Customer { get; set; }
    }
}