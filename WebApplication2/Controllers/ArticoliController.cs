﻿using System.Web.Mvc;
using WebApplication2.WorkerServices.Content;

namespace WebApplication2.Controllers
{
    public class ArticoliController : Controller
    {
        ContentWorkerServices worker = new ContentWorkerServices();

        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(404);
            }

            var worker = new ContentWorkerServices();

            var model = worker.GetContentViewModel(id.Value); 

            return View(model);
        }

        public ActionResult Archivio(int? page, int? tagId)
        {
            if (!page.HasValue)
            {
                page = 0;
            }

            var model = worker.GetArticlesArchiveViewModel(page.Value, tagId ?? -1);

            return View(model);
        }
    }
}