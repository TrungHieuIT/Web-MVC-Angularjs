using Shop.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebDemo.Models;
using WebDemo.ViewModels;

namespace WebDemo.API
{
    public class CustomerController : ApiController
    {
        private ShopDbContext db = new ShopDbContext();

        [HttpGet]
        public IHttpActionResult GetCustomer([FromUri] string search)
        {
            var data = db.Customers
                .Where(s => string.IsNullOrEmpty(search) || ( s.CustomerName.Contains(search) 
                || s.Email.Contains(search)
                || s.Country.Contains(search)))
                .OrderByDescending(x=>x.Id)
                .Select(x => new CustomerViewModel
            {
                ID = x.Id,
                CustomerName = x.CustomerName,
                Address = x.Address,
                Country = x.Country,
                Phone = x.Phone,
                Email = x.Email,
            });
          
          return Ok(data);
       
        }
        [HttpGet]
        public CustomerViewModel GetById (int id)
        {
            var data = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                CustomerViewModel customer = new CustomerViewModel();
                customer.ID = data.Id;
                customer.CustomerName = data.CustomerName;
                customer.Address = data.Address;
                customer.Country = data.Country;
                customer.Phone = data.Phone;
                customer.Email = data.Email;
                return customer;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }


        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Khong co du lieu");
            var data = db.Customers.Where(x => x.Id == customer.ID).FirstOrDefault<Customer>();
            data.CustomerName = customer.CustomerName;
            data.Address = customer.Address;
            data.Country = customer.Country;
            data.Email = customer.Email;
            data.Phone = customer.Phone;
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Khong co du lieu");
            db.Customers.Add(new Customer()
            {
                Id = customer.ID,
                CustomerName = customer.CustomerName,
                Address = customer.Address,
                Country = customer.Country,
                Email = customer.Email,
                Phone = customer.Phone,
               
            });
            db.SaveChanges();
            return Ok(customer);
        }

        [ResponseType(typeof(CustomerViewModel))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id khong ton tai");
            }
            var data = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            db.Customers.Remove(data);
            db.SaveChanges();
            return Ok();
        }

    }
}