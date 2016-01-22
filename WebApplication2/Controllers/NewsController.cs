using System.Web.Mvc;
using WebApplication2.WorkerServices.Content;

namespace WebApplication2.Controllers
{
    public class NewsController : Controller
    {
        ContentWorkerServices worker = new ContentWorkerServices();

        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(404);
            }

            var model = worker.GetContentModel(id.Value);

            return View(model);
        }

        public ActionResult Archivio(int? page, int? tagId)
        {
            if (!page.HasValue)
            {
                page = 0;
            }

            var model = worker.GetArchiveModel(page.Value, 2, tagId ?? -1);

            return View(model);
        }
    }
}