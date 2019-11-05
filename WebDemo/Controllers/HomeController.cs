using System.Web.Mvc;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ProductCategory()
        {
            return View();
        }
        public ActionResult Start()
        {
            return View();
        } public ActionResult Dashboard()
        {
            return View();
        }
   
    }
}