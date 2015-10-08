using System;
using System.Threading;
using System.Web.Mvc;

namespace WebApiTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Wait()
        {
            Thread.Sleep(TimeSpan.FromSeconds(30));
            return new ContentResult()
            {
                Content = "Done at " + DateTime.Now
            };
        }
    }
}
