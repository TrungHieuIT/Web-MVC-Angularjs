using Shop.Data;

using System.Data;
using System.Web.Http;
using System.Linq;
using System.Net;


using System.Web.Http.Description;

using WebDemo.Models;
using WebDemo.ViewModels;
using System.Net.Http;

namespace WebDemo.Controllers
{
    public class ProductsController : ApiController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: api/Products
        [HttpGet]
        public IHttpActionResult GetProduct([FromUri] string search)
        {
            var data = db.Products
                .Include("ProductCategory")
                .Where (s => string.IsNullOrEmpty(search) || (s.Name.Contains(search)
                || s.Alias.Contains(search) 
                || s.CategoryName.Contains(search)) )
                .OrderByDescending(x=> x.ID)
                .Select(p => new ProductViewModel
            {
                Id = p.ID,
                Name = p.Name,
                CategoryID = p.CategoryID,
                Description =p.Description,
                Alias =p.Alias,
                Invetory =p.Invetory,
                OriginalPrice = p.OriginalPrice,
                Price = p.Price,
                Status = p.Status,
                PromotionPrice =p.PromotionPrice,
                CategoryName = p.ProductCategory.Name,

            }) ;

            return Ok(data);
        }

        [HttpPut]
        // GET: api/Products/5
        public ProductViewModel GetProduct(int id)
        {
            var data = db.Products.Where(x=>x.ID == id).FirstOrDefault();
           if(data != null)
                {
                ProductViewModel product = new ProductViewModel();

                product.Id = data.ID;
                product.Name = data.Name;
                product.Alias = data.Alias;
                product.Price = data.Price;
                product.PromotionPrice = data.PromotionPrice;
                product.Description = data.Description;
                product.Invetory = data.Invetory;
                product.OriginalPrice = data.OriginalPrice;
                product.CategoryID = data.CategoryID;
                product.Status = data.Status;
            
                return product;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        // PUT: api/Products/5
        [HttpPut]
        public IHttpActionResult UpdateProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Khong có dữ liệu trong model ");

            var data = db.Products.Where(s => s.ID == product.Id).FirstOrDefault();

            data.Name = product.Name;
            data.Alias = product.Alias;
            data.Price = product.Price;
            data.PromotionPrice = product.PromotionPrice;
            data.Description = product.Description;
            data.Invetory = product.Invetory;
            data.OriginalPrice = product.OriginalPrice;
            data.CategoryID = product.CategoryID;
            data.Status = product.Status;
            db.SaveChanges();

            return Ok();
        }

        // POST: api/Products
        [ResponseType(typeof(ProductViewModel))]
        public IHttpActionResult AddProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Không có dữ liệu !");
            }
            db.Products.Add(new Product()
            {
                ID = product.Id,
                Name = product.Name,
                Alias = product.Alias,
                Price = product.Price,
                PromotionPrice = product.PromotionPrice,
                Description = product.Description,
                Invetory = product.Invetory,
                OriginalPrice = product.OriginalPrice,
                CategoryID = product.CategoryID,
                Status = product.Status,
            });
            db.SaveChanges();
           
            return Ok(product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(ProductViewModel))]
        public IHttpActionResult DeleteProduct(int id)
        {
            if (id <= 0)
                return BadRequest("Khong co id nay!");
            var product = db.Products
                .Where(s => s.ID == id)
                .FirstOrDefault();

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ID == id) > 0;
        }
    
    }
}