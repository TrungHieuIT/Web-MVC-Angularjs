using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult ListCustomer()
        {
            return View();
        }
        public ActionResult EditCustomer()
        {
            return View();
        }
        public ActionResult CreateCustomer()
        {
            return View();
        }
    }
}