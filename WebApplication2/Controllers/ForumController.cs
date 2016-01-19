using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Thread(int? index)
        {
            if (!index.HasValue)
            {
                return new HttpStatusCodeResult(404);
            }

            return View();
        }
    }
}