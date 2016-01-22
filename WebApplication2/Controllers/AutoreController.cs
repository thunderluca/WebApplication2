using System.Web.Mvc;
using WebApplication2.WorkerServices.Autore;

namespace WebApplication2.Controllers
{
    public class AutoreController : Controller
    {
        AutoreWorkerServices worker = new AutoreWorkerServices();

        // GET: Author
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(404);
            }

            var model = worker.GetAutoreViewModel(id.Value);

            return View(model);
        }
    }
}