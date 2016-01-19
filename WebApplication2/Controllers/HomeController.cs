using System.Web.Mvc;
using WebApplication2.WorkerServices.Home;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = HomeWorkerServices.GetHomeModel();

            return View(model);
        }

        public ActionResult SupportUs()
        {
            return View();
        }

        public ActionResult Legalese()
        {
            return View();
        }

        public ActionResult CookiePolicy()
        {
            return View();
        }
    }
}