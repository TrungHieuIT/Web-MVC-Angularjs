
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDemo.Models;
using WebDemo.ViewModels;

namespace WebDemo.API
{
    public class OrderController : ApiController
    {
        private ShopDbContext db = new ShopDbContext();
        
        [HttpGet]
        public IEnumerable<OrderViewModel> GetAllOrder([FromUri] string search)
        {
            var result = db.Orders
                .Where(s=> string.IsNullOrEmpty(search)|| (s.CustomerName.Contains(search)))
                .OrderByDescending(x=>x.Id)
                .Select(x => new OrderViewModel()
            {
                Id = x.Id,
                CustomerID = x.CustomerID,
                TotalMoney = x.TotalMoney,
                DateOrder = x.DateOrder,
                DateCreated = x.DateCreated,
                CustomerName = x.Customer.CustomerName,
                Note = x.Note,
            });
            return result.ToList();

        }
        [HttpGet]
        public OrderViewModel GetOrderById(int Id)
        {
            var data = db.Orders.Include("OrderDetail").Include("Customer").Include("OrderDetail.Product").FirstOrDefault(x=>x.Id == Id);
            if (data != null)
            {
                OrderViewModel order = new OrderViewModel();
                order.Id = data.Id;
                order.CustomerID = data.CustomerID;
                order.DateOrder = data.DateOrder;
                order.DateCreated = data.DateCreated;
                order.Note = data.Note;
                order.TotalMoney = data.TotalMoney;
                order.CustomerName = data.Customer.CustomerName;
                order.OrderDetail = data.OrderDetail.AsQueryable().Include("OrderDetail.Product").Select(x => new OrderDetailViewModel()
                {
                    Id = x.Id,
                    ProductID = x.ProductID,
                    OrderID = x.OrderID,
                    Quantity =x.Quantity,
                    Price =x.Price,
                    ProductName =x.Product.Name,

                }).ToList();
                return order;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }
        [HttpPost]
        public IHttpActionResult AddOrder (OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (orderViewModel != null)
            {
                if (orderViewModel.OrderDetail.Count == 0 || orderViewModel.CustomerID == 0)
                {
                    return BadRequest();
                }
                Order order = new Order
                {
                    CustomerID = orderViewModel.CustomerID,
                    TotalMoney = orderViewModel.TotalMoney,
                    DateOrder = orderViewModel.DateOrder,
                    DateCreated = orderViewModel.DateCreated,
                    Status = orderViewModel.Status,
                    Note = orderViewModel.Note,
                  

                    OrderDetail = new List<OrderDetail>(),
                };
                foreach (var item in orderViewModel.OrderDetail)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        ProductID = item.ProductID,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        ProductName = item.ProductName,
                    };
                    order.OrderDetail.Add(orderDetail);
                }
                db.Orders.Add(order);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult UpdateOrder(OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var order = db.Orders.Where(i => i.Id == model.Id).SingleOrDefault();//Lay ra order
            order.OrderDetail = db.OrderDetails.Where(i => i.OrderID == model.Id).ToList(); //Lay ra list chi tiet order cũ  a={1,2,3,4,5,6,7}
            order.DateOrder = model.DateOrder;
            order.DateCreated = DateTime.Now;
            order.TotalMoney = model.TotalMoney;
            order.CustomerID = model.CustomerID;
            order.CustomerName = model.CustomerName;
            
            var ids = model.OrderDetail.Select(s => s.Id).ToList();//list item mới truyền lên //list ids chứa phần tử số // list orderdetail đã thay đổi ở client . Vd a ={2,4,5}
            List<OrderDetail> itemRemoves = order.OrderDetail.Where(x => !ids.Contains(x.Id)).ToList(); // so sánh list orderDetail trong order với cái list ids những Id nếu không tồn tại trong ids thì xóa những phần tử có Id =1,3,6,7  
            foreach (var i in itemRemoves)
            {
                db.OrderDetails.Remove(i);
            }
            foreach (var item in model.OrderDetail)//duyệt list items mới truyền lên chưa có thì thêm vào db có rồi thì update propety
            {
                var orderDetail = db.OrderDetails.Where(i => i.Id == item.Id).FirstOrDefault();// lấy 1 chi tiết có id sản phẩm = id sản phẩm truyền lên

                if (orderDetail != null)
                {
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.Price = item.Price;
                    orderDetail.ProductName = item.ProductName;
                    orderDetail.ProductID = item.ProductID;
                }
                else
                {
                    OrderDetail ord = new OrderDetail
                    {
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        Price = item.Price,
                        Quantity = item.Quantity
                    };
                    order.OrderDetail.Add(ord);
                }

            }
            db.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult DeleteItem (int id)
        {
            if (id <= 0)
                return BadRequest();
            var order = db.Orders
                .Where(s => s.Id == id)
                .FirstOrDefault();
            db.Orders.Remove(order);
            db.SaveChanges();
            return Ok();
        }
    }
}
