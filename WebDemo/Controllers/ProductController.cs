using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDemo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult AllProduct()
        {
            return View();
        }
        public ActionResult EditProduct()
        {
            return View();
        }
        public ActionResult CreateProduct()
        {
            return View();
        }
    }
}