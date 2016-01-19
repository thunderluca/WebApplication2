using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class EventiController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(404);
            }

            return View();
        }

        public ActionResult Archivio(int? page)
        {
            if (!page.HasValue)
            {
                page = 0;
            }

            return View();
        }
    }
}