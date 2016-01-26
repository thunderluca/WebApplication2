using System.Web.Mvc;
using WebApplication2.WorkerServices.Home;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        HomeWorkerServices worker = new HomeWorkerServices();

        public ActionResult Index()
        {
            var model = worker.GetIndexViewModel();

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