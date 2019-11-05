using Shop.Data;
using System.Collections.Generic;
using System.Linq;
using WebDemo.Models;

namespace WebDemo.ViewModels
{
    public class EditProductViewModel
    {
        public int ProductID { get; set; }
        public string NameProduct { get; set; }
        public int CategoryID { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }

        public void GetCategories()
        {
            ShopDbContext db = new ShopDbContext();
            ProductCategories = db.ProductCategories.ToList().AsEnumerable();
        }
    }
}