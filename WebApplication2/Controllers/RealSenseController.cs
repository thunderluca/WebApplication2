using System.Collections;
using System.IO;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class RealSenseController : Controller
    {
        [HttpPost]
        public JsonResult Login()
        {
            var viewHtml = RenderRazorViewToString("RealSense", null);

            var hashtable = new Hashtable
            {
                ["viewHtml"] = viewHtml
            };

            return Json(hashtable);
        }

        private string RenderRazorViewToString(string viewName, object model)
        {
            if (model != null)
                ViewData.Model = model;

            using (var stringWriter = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, stringWriter);
                viewResult.View.Render(viewContext, stringWriter);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}