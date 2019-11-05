using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    [Table("AutoIdOrders")]
    public class AutoIdOrder
    {
        public int Id { get; set; }
    }
}